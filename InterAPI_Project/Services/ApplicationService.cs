using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InterAPI_Project.Models.EntityFramework;

namespace InterAPI_Project.Services
{ 
    public class ApplicationService
    {
        APIDashboardEntities db = new APIDashboardEntities();

        public List<Application> GetApplications(int userId)
        {
            var applications = db.Applications.Where(x => x.UserId == userId).ToList();
            return applications;
        }

        public void AddApplication(int userId, Application application)
        {
            application.UserId = userId;
            application.CreateTime = DateTime.Now;
            db.Applications.Add(application);
            //db.Entry(application).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateApplication(int Id, Application application)
        {
            var updatedApp = db.Applications.Find(application.Id);
            if(updatedApp == null)
            {
                ; //do something
            }

            updatedApp.Name = application.Name;
            db.Entry(updatedApp).State = EntityState.Modified;
            db.SaveChanges();

        }

        //unused....
        public int GetApplicationID (string name)
        {
            var thatApp = db.Applications.FirstOrDefault(x => x.Name == name);
            int appId = thatApp.Id;
            return appId;
        }

    }
}