﻿using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Areas.User.Controllers
{
    [Route("User/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<UserPerson> _userManager;
        private readonly RoleManager<UserRole> _roleManager;

        public RegisterController(UserManager<UserPerson> userManager, RoleManager<UserRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Area("User")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
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
                if (validationResult.IsValid)
                {
                    var result = await _userManager.CreateAsync(user, userRegisterVM.Password);
                    var defaultrole = _roleManager.FindByNameAsync("User").Result;
                    if (defaultrole != null)
                    {
                        IdentityResult roleresult = await _userManager.AddToRoleAsync(user, defaultrole.Name);
                        if (result.Succeeded && roleresult.Succeeded)
                        {
                            return RedirectToAction("Index", "Login");
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
            return View(userRegisterVM);
        }
    }
}
