using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authentication.Domain;

namespace Authentications.Controllers
{
    public class HomeController : Controller
    {
        public IUserRepo Repo;

        public HomeController(IUserRepo userRepo)
        {
            Repo = userRepo;
        }

        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
