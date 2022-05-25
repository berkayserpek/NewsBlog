using EntityLayer.Concrete;
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
    public class LoginController : Controller
    {
        private readonly SignInManager<UserPerson> _signInManager;
        private readonly UserManager<UserPerson> _userManager;

        public LoginController(SignInManager<UserPerson> signInManager, UserManager<UserPerson> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(userLoginVM.UserName).Result;
                var getAdmin = _userManager.IsInRoleAsync(user, "User").Result;
                if(user.Status == true)
                {
                    ModelState.AddModelError("", "Hesabınız askıya alınmıştır..");
                }
                else
                {
                    if (getAdmin)
                    {
                        var result = await _signInManager.PasswordSignInAsync(userLoginVM.UserName, userLoginVM.Password, false, true);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
                        }

                    }
                }
            }
            return View();
        }
    }
}
