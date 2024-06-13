using PSDFinalProject.Factories;
using PSDFinalProject.Models;
using PSDFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Handlers
{
    public class UserHandler
    {
        public static string registerUser(string username, string email, string gender, string password, DateTime dob)
        {
            User user = UserRepository.getUserByUsername(username);
            if(user != null)
            {
                return "This username has been used!";
            }

            User newUser = UserFactory.createNewUser(username, email, gender, password, dob);

            return UserRepository.addNewUser(newUser); 
        }
    }
}