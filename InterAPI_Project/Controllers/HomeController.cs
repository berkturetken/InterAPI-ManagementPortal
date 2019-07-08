using InterAPI_Project.Models.EntityFramework;
using InterAPI_Project.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterAPI_Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        APIDashboardEntities db = new APIDashboardEntities();
        public ActionResult Index()
        {
            var model = db.Users.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddUser()
        {
            return View();
        }
    }
}