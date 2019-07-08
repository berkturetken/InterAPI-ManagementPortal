using InterAPI_Project.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterAPI_Project.ViewModels
{
    public class DetailModelView
    {
        public Application Name { get; set; }
        public Application Key { get; set; }
        public Application CreateTime { get; set; }
        public List<ApplicationMethodPermission> PermissonMethods { get; set; }
        public int ApplicationId { get; set; }
    }
}