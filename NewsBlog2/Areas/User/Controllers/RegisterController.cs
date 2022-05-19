﻿using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MernisService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<UserPerson> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        public RegisterController(UserManager<UserPerson> userManager, RoleManager<UserRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {
            if (ModelState.IsValid)
            {
                UserPerson user = new UserPerson()
                {
                    UserName = userRegisterVM.UserName,
                    FirstName = userRegisterVM.FirstName,
                    LastName = userRegisterVM.LastName,
                    IdentityNumber = userRegisterVM.IdentityNumber,
                    Birthday = userRegisterVM.Birthday,
                    Email = userRegisterVM.Mail,
                };

                UserValidator validations = new UserValidator();
                ValidationResult validationResult = validations.Validate(user);
                var client = new MernisService.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
                var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(userRegisterVM.IdentityNumber), userRegisterVM.FirstName, userRegisterVM.LastName, userRegisterVM.Birthday.Year);
                var kimlikNoResult = response.Body.TCKimlikNoDogrulaResult;
                if(kimlikNoResult == true)
                {
                    if (validationResult.IsValid)
                    {
                        var result = await _userManager.CreateAsync(user, userRegisterVM.Password);
                        var defaultrole = _roleManager.FindByNameAsync("User").Result;
                        if (defaultrole != null)
                        {
                            IdentityResult roleresult = await _userManager.AddToRoleAsync(user, defaultrole.Name);
                            if (result.Succeeded && roleresult.Succeeded)
                            {
                                return RedirectToAction("Login", "Login");
                            }
                        }
                        else
                        {
                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError("", item.Description);
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in validationResult.Errors)
                        {
                            ModelState.AddModelError("", item.ErrorMessage.ToString());
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("","Bilgilerinizi kontrol edin!");
                }
                

            }
            return View(userRegisterVM);
        }
    }
}
