using InterAPI_Project.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InterAPI_Project.Services
{
    public class UserService
    {
        APIDashboardEntities db = new APIDashboardEntities();

        public int Login(string username, string password)
        {

            var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);          //chek whether there is any user in the database

            if (user != null && user.Id > 0)
            {
                return user.Id;
            }
            else
            {
                return 0;
            }
        }

        public User GetUser(int userId)                                                 //According to the user Id, the function brings the user itself
        {
            var user = db.Users.FirstOrDefault(x => x.Id == userId);

            return user;
        }

        public void UpdateUser(int userId, User user)                                   //update the user's information such as name, surname, and email
        {
            var updatedUser = new UserService().GetUser(userId);

            updatedUser.Name = user.Name;
            updatedUser.Surname = user.Surname;
            updatedUser.Email = user.Email;

            db.Entry(updatedUser).State = EntityState.Modified;                         //update the database as well
            db.SaveChanges();
        }

    }
}