using InterAPI_Project.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterAPI_Project.ViewModels
{
    public class MethodPermissionViewModel
    {
        APIDashboardEntities db = new APIDashboardEntities();

        public List<Method> Methods { get; set; }
        public List<Application> Applications { get; set; }
        public List<MethodLog> MethodLogs { get; set; }
        public int ApplicationId { get; set; }
        public int MethodId { get; set; }
        public string MethodName { get; set; }      //gereksiz

        
        //public List<Method> GetMethods()
        //{
        //    var methods = db.Methods.Where(x => x.Id > 0).ToList();
        //    return methods;
        //    //Methods = db.Methods.ToList();
        //    //return Methods;
        //}

    }
}