using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Controllers
{
    public class TestController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new CategoryRepository());
        public IActionResult Index()
        {
            var values = categoryManager.TGetList();
            return View(values);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            categoryManager.TAdd(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        public IActionResult DeleteCategory(int id)
        {
            var values = categoryManager.TGetByID(id);
            categoryManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = categoryManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            categoryManager.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
