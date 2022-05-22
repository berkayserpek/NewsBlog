using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.ViewComponents.Header
{
    public class Header : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new CategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = categoryManager.TGetList();
            return View(values);
        }
    }
}
