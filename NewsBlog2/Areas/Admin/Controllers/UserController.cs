using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsBlog2.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[action]/{id?}")]
    [Authorize(Roles ="Moderator")]
    public class UserController : Controller
    {
        UserManager1 _userManager = new UserManager1(new UserRepository());
        private readonly UserManager<UserPerson> userManager;
        private readonly SignInManager<UserPerson> signInManager;

        public UserController(UserManager<UserPerson> userManager, SignInManager<UserPerson> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Users()
        {
            var users =_userManager.TGetList();
            return View(users);
        }
        [HttpGet]
        public IActionResult UserDetail(int id)
        {
            var users = _userManager.TGetByID(id);
            UserUpdateVM userUpdate = new UserUpdateVM
            {
                Id = id,
                FirstName = users.FirstName,
                LastName = users.LastName,
                Status = users.Status
            };
            return View(userUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> UserDetail(UserUpdateVM updateUser)
        {
            if (ModelState.IsValid)
            {                
                var getUser = _userManager.TGetByID(updateUser.Id);
                bool getRole = await userManager.IsInRoleAsync(getUser, "Moderator");
                if(getRole == true)
                {
                    ViewBag.Error = "Bu kullanıcı için işlem yapılamaz";
                }
                getUser.FirstName = updateUser.FirstName;
                getUser.LastName = updateUser.LastName;
                getUser.Status = updateUser.Status;
                _userManager.TUpdate(getUser);
            }
            
            return View(updateUser);

        }
    }
}
