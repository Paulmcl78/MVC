using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LoginPage.Domain;

namespace LoginPage.Controllers
{
    public class AuthenticationController : Controller
    {
        #region Private Member

        private ICoreRepo _repo;
        #endregion

        public AuthenticationController(ICoreRepo coreRepo)
        {
            _repo = coreRepo;
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return View("Login");
        }

        public ActionResult Login()
        {
            if (Session["AuthenticatedUser"] != null && (bool)Session["AuthenticatedUser"])
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User authUser = _repo.users.FirstOrDefault(u => u.UserName == user.UserName);

            if (authUser == null || !authUser.Password.Equals(user.Password))
            {
                user.UserName = "";
                user.Password = "";
                ModelState.Clear();
                ModelState.AddModelError("", "The user name or password provided is incorrect.");

                return View();
            }

            Session["AuthenticatedUser"] = true;
            Session["User"] = user.UserName;
            Session["LoginTime"] = DateTime.Now;

            return RedirectToAction("Index", "Home");


        }

    }
}
