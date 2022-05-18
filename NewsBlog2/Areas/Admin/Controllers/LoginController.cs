using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Areas.Admin.Controllers
{
    [Route("Admin/[action]")]
    public class LoginController : Controller
    {
        [Area("Admin")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
