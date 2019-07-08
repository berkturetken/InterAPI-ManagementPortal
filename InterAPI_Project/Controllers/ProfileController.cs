using InterAPI_Project.Models.EntityFramework;
using InterAPI_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterAPI_Project.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            var userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            var user = new UserService().GetUser(userId);

            return View(user);
        }

        public ActionResult Update()
        {
            var userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            var user = new UserService().GetUser(userId);

            return View(user);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            var userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            UserService userService = new UserService();
            userService.UpdateUser(userId, user);

            return RedirectToAction("Index", "Profile");
        }

    }
}