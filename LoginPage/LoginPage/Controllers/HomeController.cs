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

            Model.UserName = (string)Session["User"];
            Model.LoginTime = (DateTime.Now - (DateTime) Session["LoginTime"]).Minutes;

            return View(Model);

            
        }

    }
}
