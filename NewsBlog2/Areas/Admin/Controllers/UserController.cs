using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult Users()
        {
            var users =_userManager.TGetList();
            return View(users);
        }
    }
}
