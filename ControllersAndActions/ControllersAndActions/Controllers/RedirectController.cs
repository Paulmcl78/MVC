using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class RedirectController : Controller
    {
        
        /// <summary>
        /// Redirecting to a Literal URL
        /// </summary>
        /// <returns></returns>
        public RedirectResult Redirect()
        {
            return Redirect("/Example/Index");
        }

        /// <summary>
        /// Routed redirections
        /// </summary>
        /// <returns></returns>
        public RedirectToRouteResult RedirectToRoute()
        {
            return RedirectToRoute(new { controller = "Example", action = "Index", ID = "MyId" });
        }

        /// <summary>
        /// Redirecting to an action method
        /// If you do not specify a controller this will assume you are using
        /// a action in your current controller
        /// </summary>
        /// <returns></returns>
        public RedirectToRouteResult RedirectToActionMethod()
        {
            //Passing in a controller
            //return RedirectToAction("Index","Example");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Temp data can be used to persist data accross a redirect. Temp data is different from
        /// session data as this is marked for deletion when they are read and are removed when the
        /// request has been processed, this is ideal for short lived data that you want to presist
        /// accross a redirection.
        /// </summary>
        /// <returns></returns>
        public RedirectToRouteResult RedirectWithTempData()
        {
            TempData["Message"] = "Hello";
            TempData["Date"] = DateTime.Now;

            return RedirectToAction("Index");
        }

        public ViewResult Index()
        {
            // this can be setup in a data bag or a more direct approcah would be to read the temp
            // data from the view iteself with @TempData["Message"].
            ViewBag.Message = TempData["Message"];


            // To get data from the temp data without marking it for deletion you can use a peek 
            ViewBag.Date = TempData.Peek("Date");
            return View();
        }

    }
}
