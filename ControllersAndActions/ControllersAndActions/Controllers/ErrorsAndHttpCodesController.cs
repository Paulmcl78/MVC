using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ErrorsAndHttpCodesController : Controller
    {

        /// <summary>
        /// There is no controller helper method for this, so you must instantiate the class directly.
        /// The constructor takes in a numerical status and an optional diescription.
        /// This can be achived with a more convenient HttpNotFoundResult class - see below
        /// </summary>
        /// <returns></returns>
        public HttpStatusCodeResult StatusCode()
        {
            return new HttpStatusCodeResult(404, "Url cannot be serviced");
        }

        /// <summary>
        /// The HttpNotFoundResult class is derived from the HttpStatusCodeResult and can be created using
        /// the controller HttpNotFound convenience method
        /// 
        /// This can take in an option description
        /// </summary>
        /// <returns></returns>
        public HttpStatusCodeResult notFound()
        {
            return HttpNotFound();
        }

        /// <summary>
        /// For returing 401 (not authorised) we can use another helper method in the controller
        /// called HttpUnauthorizedResult which will take in an optional description.
        /// </summary>
        /// <returns></returns>
        public HttpStatusCodeResult NotAuthorized()
        {
            return new HttpUnauthorizedResult();
        }

    }
}
