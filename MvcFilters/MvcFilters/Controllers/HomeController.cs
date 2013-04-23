using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFilters.Infractructure;

namespace MvcFilters.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This filter uses the base AuthorizeAttribute with the addition bypass is the user is local on 
        /// the server machine.
        /// </summary>
        /// <returns></returns>
        [OrAuthorization(Users="adam,steve,bob",Roles="admin")]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The MVC framework includes a very useful built-in authorization filter called
        /// AuthorizeAttribute.  We can specify our authorization policy using two public
        /// properties.
        /// 
        /// Users - usernames that are allowed to access the action method
        /// Roles - To access the action method the user must be in at least one of these roles.
        /// </summary>
        /// <returns></returns>
        [Authorize(Users="adam,steve,bob",Roles="admin")]
        public ActionResult BuiltInAuthFilter()
        {
            return View();
        }

        /// <summary>
        /// Using the custom defined filter
        /// </summary>
        /// <returns></returns>
        [CustomAuth("adam", "steve", "bob")]
        public ActionResult CustomFilter()
        {
            return View();
        }

    }
}
