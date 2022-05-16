using BusinessLayer.ValidationRules;
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
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;

        public RegisterController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

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
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
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
