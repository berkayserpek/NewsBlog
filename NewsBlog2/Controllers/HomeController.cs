using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsBlog2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        NewManager newManager = new NewManager(new NewRepository());
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public PartialViewResult Header()
        {
            return PartialView();
        }
        public PartialViewResult Description()
        {
            var values = newManager.TGetList();
            return PartialView(values);
        }
        public PartialViewResult TopDescription()
        {
            var values = newManager.TGetList();
            return PartialView(values);
        }
        public PartialViewResult BotDescription()
        {
            return PartialView();
        }
        public PartialViewResult MainDescription()
        {
            var values = newManager.TGetList();
            return PartialView(values);
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }

        public IActionResult GetNewsByCategoryID(int id)
        {
            var values = newManager.GetListByCategoryID(id);
            return View(values);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
