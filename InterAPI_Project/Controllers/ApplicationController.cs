using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterAPI_Project.Models.EntityFramework;
using InterAPI_Project.Services;
using InterAPI_Project.ViewModels;

namespace InterAPI_Project.Controllers
{

    [Authorize]
    public class ApplicationController : Controller
    {

        APIDashboardEntities db = new APIDashboardEntities();

        // GET: Application
        public ActionResult Index()
        {
            var userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            var model = new ApplicationService().GetApplications(userId);

            return View(model);
        }

        [HttpGet]
        public ActionResult AddApp()
        {
            Application application = new Application();
            application.AppKey = Guid.NewGuid().ToString("N");
            return View("EditApp", application);
        }

        [HttpPost]
        public ActionResult Save(Application application)
        {
            if (application.Id == 0)
            {
                var userId = Convert.ToInt32(HttpContext.User.Identity.Name);
                ApplicationService applicationService = new ApplicationService();
                applicationService.AddApplication(userId, application);
            }
            else
            {
                var Id = application.Id;
                ApplicationService applicationService = new ApplicationService();
                applicationService.UpdateApplication(Id, application);
            }

            return RedirectToAction("Index", "Application");
        }

        //ekstra, düzeltilecek
        public ActionResult UpdateApp(int Id)
        {
            var model = db.Applications.Find(Id);
            if (model == null)
                return HttpNotFound();
            return View("EditApp", model);
        }

        public ActionResult NewMethods(int id)
        {
            //class'a al
            var model = new MethodPermissionViewModel()
            {
                Methods = db.Methods.ToList(),
                ApplicationId = id
            };

            return View(model);
        }


        public ActionResult AddMethods(MethodPermissionViewModel method)
        {
            ApplicationMethodPermission model = new ApplicationMethodPermission();
            MethodService methodService = new MethodService();
            methodService.AddMethod(method, model);
            return RedirectToAction("Index", "Application");
        }

        public ActionResult ViewMethods(int Id)
        {
            var model = new MethodService().ViewMethods(Id);
            return View(model);
        }

    }
}