using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Areas.User.Controllers
{
    [Route("User/[action]")]
    public class LoginController : Controller
    {
        [Area("User")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
