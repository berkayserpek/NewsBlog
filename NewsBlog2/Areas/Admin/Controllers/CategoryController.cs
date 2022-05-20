using BusinessLayer.Concrete;
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
    public class CategoryController : Controller
    {
        private readonly UserManager<UserPerson> _userManager;
        CategoryManager categoryManager = new CategoryManager(new CategoryRepository());
        public CategoryController(UserManager<UserPerson> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Categories()
        {
            var values = categoryManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            categoryManager.TAdd(p);
            return RedirectToAction("Categories", "Category");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {         
            var valeus = categoryManager.TGetByID(id);
            return View(valeus);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category p)
        {
            //var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            //p.CategoryID = user.Id;
            categoryManager.TUpdate(p);
            return RedirectToAction("Categories", "Category");
        }
        public IActionResult DeleteCategory(int id)
        {
            var values = categoryManager.TGetByID(id);
            categoryManager.TDelete(values);
            return RedirectToAction("Categories", "Category");
        }

    }
}
