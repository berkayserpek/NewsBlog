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
    [Route("User/[action]/{id?}")]
    public class ProfileController : Controller
    {
        private readonly UserManager<UserPerson> _userManager;

        public ProfileController(UserManager<UserPerson> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateVM userUpdateVM = new UserUpdateVM();
            userUpdateVM.FirstName = values.FirstName;
            userUpdateVM.LastName = values.LastName;
            userUpdateVM.Birthday = values.Birthday;
            return View(userUpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserUpdateVM userUpdateVM)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.FirstName = userUpdateVM.FirstName;
            values.LastName = userUpdateVM.LastName;
            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("News", "New");
            }
            return View();
        }
    }
}
