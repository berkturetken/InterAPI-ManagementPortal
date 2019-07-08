using InterAPI_Project.Models.EntityFramework;
using InterAPI_Project.Services;
using InterAPI_Project.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterAPI_Project.Controllers
{
    public class ReportController : Controller
    {
        APIDashboardEntities db = new APIDashboardEntities();
        public ActionResult Index(MethodPermissionViewModel mpvm)
        {
            //class'a al
            var model = new MethodPermissionViewModel()
            {
                Methods = db.Methods.ToList(),
                Applications = db.Applications.ToList()
            };
            return View(model);

            //var ax = db.MethodLogs.Where(x => x.ApplicationId == id).ToList();
            //int id=1;
            //var userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            //var model = new MethodPermissionViewModel()
            //{
            //    ApplicationId = id,
            //    Methods = db.Methods.ToList(),
            //    Applications = new ApplicationService().GetApplications(userId),
            //    MethodLogs = db.MethodLogs.Where(x => x.ApplicationId == id).ToList()
            //};

        }

        public ActionResult ListLogs(MethodPermissionViewModel model)
        {
            //var model = new MethodPermissionViewModel()
            //{
            //    MethodLogs = db.MethodLogs.Where(x => x.ApplicationId == method.ApplicationId).ToList()
            //};
            //var temp = new MethodService().ViewMethods(model.ApplicationId);
            var currMethodName = new MethodService().GetMethodName(model.MethodId);     //taking the current method name according to the given applications and methods
            
            model.MethodLogs = db.MethodLogs.Where(x => x.ApplicationId == model.ApplicationId && x.MethodName == currMethodName).ToList();       //methodu'a göre bakmayı da ekle
            //2 defa database'den çekiyoruz alt tarafta -> zaman kalırsa değiştir
            model.Methods = db.Methods.ToList();
            model.Applications = db.Applications.ToList();

            return View("Index", model);
        }

        public ActionResult Detail(int id)
        {
            MethodLog model = new MethodLog();
            model = db.MethodLogs.FirstOrDefault(x => x.Id == id);


            dynamic parsedJson = JsonConvert.DeserializeObject(model.Request);
            model.Request = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

            dynamic parsedJson2 = JsonConvert.DeserializeObject(model.Response);
            model.Response = JsonConvert.SerializeObject(parsedJson2, Formatting.Indented);

            return View(model);
        }


    }
}