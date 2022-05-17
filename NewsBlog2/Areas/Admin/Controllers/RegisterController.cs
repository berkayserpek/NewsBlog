using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NewsBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Controllers
{
    [Route("Admin/[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        public RegisterController(UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Area("Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM userRegisterVM)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
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
                    var roleManager = await _roleManager.RoleExistsAsync("Admin");                   
                    if (result.Succeeded && roleManager == true)
                    {
                        var result1 = _userManager.AddToRoleAsync(user, "Admin");
                        if (result1.IsCompletedSuccessfully)
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
