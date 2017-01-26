using RememberMeBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RememberMeBackend.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Title = "Home Page";
            MemoriesInitializer initializer = new MemoriesInitializer();
            initializer.TestSeed(new MemoryDbContext());
            return View();
        }
    }
}
