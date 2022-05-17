using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Controllers
{
    public class NewController : Controller
    {
        Context context = new Context();
        NewManager newManager = new NewManager(new NewRepository());

        public NewController(Context context, NewManager newManager)
        {
            this.context = context;
            this.newManager = newManager;
        }

        public IActionResult Index()
        {
            var values = newManager.TGetList();
            return View(values);
        }
        [HttpPost]
        public IActionResult AddNew(New news)
        {
            //ViewBag.CategoryList = new SelectList(context.Categories, "CategoryID", "CategoryName");
            newManager.TAdd(news);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            //ViewBag.CategoryList = new SelectList(context.Categories, "CategoryID", "CategoryName");
            return View();
        }
    }
}
