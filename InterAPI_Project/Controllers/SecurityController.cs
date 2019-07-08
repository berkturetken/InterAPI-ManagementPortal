using InterAPI_Project.Models.EntityFramework;
using InterAPI_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InterAPI_Project.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            UserService userService = new UserService();

            var userId = userService.Login(user.Username, user.Password);

            if (userId > 0)
            {
                //ViewBag["userInDb"] = userInDb;
                FormsAuthentication.SetAuthCookie(userId.ToString(), false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Password", "Username or password is invalid!");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}