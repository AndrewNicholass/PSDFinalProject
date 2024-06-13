using PSDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Factories
{
    public class UserFactory
    {
        public static User createNewUser(string username, string email, string gender, string password, DateTime dob)
        {
            User user = new User();
            user.Username = username;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserPassword = password;
            user.UserRole = "customer";
            user.UserDOB = dob;
            return user;
        }
    }
}