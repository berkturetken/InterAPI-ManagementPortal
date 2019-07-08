using InterAPI_Project.Models.EntityFramework;
using InterAPI_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterAPI_Project.Services
{


    public class MethodService
    {
        APIDashboardEntities db = new APIDashboardEntities();

        //APIDashboardEntities db = new APIDashboardEntities();
        //public List<Method> GetMethods()
        //{
        //    var methods = db.Methods.Where(x => x.Id > 0).ToList();
        //    return methods;
        //}

        public void AddMethod(MethodPermissionViewModel method, ApplicationMethodPermission model)      //ismi değiştirilebilir --> PermissionedMethod...
        {
            model.ApplicationId = method.ApplicationId;
            model.MethodId = method.MethodId;
            model.CreateTime = DateTime.Now;
            db.ApplicationMethodPermissions.Add(model);
            db.SaveChanges();
        }

        public List<ApplicationMethodPermission> ViewMethods (int applicationId)
        {
            var authorizedMethods = db.ApplicationMethodPermissions.Where(x => x.ApplicationId == applicationId).ToList();
            return authorizedMethods;
        }


        public string GetMethodName(int methodId)
        {
            var intendedMethod = db.Methods.FirstOrDefault(x => x.Id == methodId);
            string str = intendedMethod.Name;
            return str;
        }

        //public string GetMethodName (int id)
        //{
        //    var ran = db.ApplicationMethodPermissions.FirstOrDefault(x => x.MethodId == id);
        //    string wanted = 
            

        //}
       

    }
} 