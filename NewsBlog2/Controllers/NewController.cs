using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Controllers
{
    //[Route("[action]/{id?}")]
    public class NewController : Controller
    {
        NewManager newManager = new NewManager(new NewRepository());
        public IActionResult NewDetails(int id)
        {
            Context context = new Context();
            var categories = context.Categories.ToList();
            if (categories != null)
            {
                ViewBag.Category = categories;
            }
            var valeus = newManager.TGetByID(id);
            return View(valeus);
        }
    }
}
