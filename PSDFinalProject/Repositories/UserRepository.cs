using PSDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Repositories
{
    public class UserRepository
    {
        private static Database1Entities1 db = DBInstance.getInstance();
        public static string addNewUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return "registration success!";
        }

        public static User getUserByEmail(string email)
        {
            return db.Users.Where(u => u.UserEmail == email).FirstOrDefault();
        }

        public static User getUserByUsername(string username)
        {
            return db.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public static User getUserById(string id)
        {
            int userID = Convert.ToInt32(id);
            return db.Users.Where(u => u.UserID == userID).FirstOrDefault();
        }

        public static List<object> getAllUsers()
        {
            var customer = (
                from x in db.Users
                where x.UserRole == "customer"
                select new
                {
                    x.UserID,
                    x.Username,
                    x.UserEmail,
                    x.UserDOB,
                    x.UserGender,
                    x.UserRole,

                }
            ).ToList();

            List<object> customerList = customer.Select(x => (object)new
                {
                    UserID = x.UserID,
                    UserName = x.Username,
                    UserEmail = x.UserEmail,
                    UserDOB = x.UserDOB,
                    UserGender = x.UserGender,
                    UserRole = x.UserRole
                }
            ).ToList();

            return customerList;

        }
    }
}