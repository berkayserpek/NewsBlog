using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[action]/{id?}")]
    public class NewController : Controller
    {
        private readonly UserManager<UserPerson> _userManager;
        NewManager newManager = new NewManager(new NewRepository());

        public NewController(UserManager<UserPerson> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult News()
        {
            Context context = new Context();
            var categories = context.Categories.ToList();
            if (categories != null)
            {
                ViewBag.Category = categories;
            }
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var values = newManager.GetListByUserID(user.Id);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddNews()
        {
            Context context = new Context();
            var categories = context.Categories.ToList();
            if(categories != null)
            {
                ViewBag.Category = categories;
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddNews(New p)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            p.UserID = user.Id;
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            //0 onay beklediğini ifade eder.
            p.Status = 0;
            newManager.TAdd(p);
            return RedirectToAction("News", "New");
        }
        [HttpGet]
        public IActionResult UpdateNews(int id)
        {
            //var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            //user.News.Select(x => x.NewID == id);
            Context context = new Context();
            var categories = context.Categories.ToList();
            if (categories != null)
            {
                ViewBag.Category = categories;
            }
            var valeus = newManager.TGetByID(id);
            return View(valeus);
        }
        [HttpPost]
        public IActionResult UpdateNews(New p)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            p.UserID = user.Id;
            newManager.TUpdate(p);
            return RedirectToAction("News", "New");
        }
        public IActionResult DeleteNews(int id)
        {
            var values = newManager.TGetByID(id);
            newManager.TDelete(values);
            return RedirectToAction("News", "New");
        }
    }
}
