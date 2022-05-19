using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Controllers
{
    public class LogOutController : Controller
    {
        private readonly SignInManager<UserPerson> _signInManager;

        public LogOutController(SignInManager<UserPerson> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
