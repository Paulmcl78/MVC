using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        //
        // GET: /Example/

        public ViewResult Index()
        {
            DateTime date = DateTime.Now;

            return View(date);
        }

        public ViewResult forTest()
        {
            return View((object)"Hello, world");
        }

        public ViewResult ViewBagTest()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;

            return View();
        }

    }
}
