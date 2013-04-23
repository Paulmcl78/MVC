using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        //
        // GET: /Derived/

        public void Index()
        {
            string controller = (string)RouteData.Values["controller"];
            string action = (string)RouteData.Values["action"];

            Response.Write(string.Format("Controller : {0}, Action : {1}",controller,action));

        }

        public ActionResult Redirect()
        {
            return new RedirectResult("/Derived/Index");
        }

        public ViewResult ForTest()
        {
            return View("Homepage");
        }

        //public ActionResult Index()
        //{
        //    ViewBag.Message = "Hello from the derived controller index method";
        //    return View("MyView");

            
        //}

        /// <summary>
        /// An Action method using context objects to get information about a request
        /// </summary>
        /// <returns></returns>
        public ActionResult RenameProduct()
        {
            string userName = User.Identity.Name;
            string serverName = Server.MachineName;
            string clientIP = Request.UserHostAddress;
            DateTime datestamp = HttpContext.Timestamp;

            string oldProductName = Request.Form["OldName"];
            string newProductName = Request.Form["NewName"];

            return View();
        }

    }
}
