using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginPage.Models;

namespace LoginPage.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            
            IndexViewModel Model = new IndexViewModel();

            return View(Model);

            
        }

    }
}
