using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[action]/{id?}")]
    public class NewController : Controller
    {
        private readonly UserManager<UserPerson> _userManager;
        NewManager newManager = new NewManager(new NewRepository());

        public NewController(UserManager<UserPerson> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            Context context = new Context();
            var categories = context.Categories.ToList();
            if (categories != null)
            {
                ViewBag.Category = categories;
            }
            var values = newManager.TGetList();
            return View(values);
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
            return RedirectToAction("Index", "New");
        }
        public IActionResult DeleteNews(int id)
        {
            var values = newManager.TGetByID(id);
            newManager.TDelete(values);
            return RedirectToAction("Index", "New");
        }
        public IActionResult AcceptNews(int id)
        {
            var values = newManager.TGetByID(id);
            values.Status = 1;
            newManager.TUpdate(values);
            return RedirectToAction("Index", "New");
        }
        public IActionResult RejectNews(int id)
        {
            var values = newManager.TGetByID(id);
            values.Status = 2;
            newManager.TUpdate(values);
            return RedirectToAction("Index", "New");
        }
    }
}
