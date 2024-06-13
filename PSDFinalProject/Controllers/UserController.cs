using PSDFinalProject.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDFinalProject.Controllers
{
    public class UserController
    {

        public static string validateRegistration(string username, string email, string gender, string password, string confirmpassword, DateTime dob)
        {

            int validNum = 0;
            int validLetter = 0;
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    validNum = 1;
                }
                if (char.IsLetter(c))
                {
                    validLetter = 1;
                }
            }

            if (username.Length < 5 || username.Length > 15 || username == null || username == "")
            {
                return "username Length must be between 5 and 15, must be unique, cannot be empty";
                
            }
            else if (email.EndsWith(".com") == false || email == null || email == "")
            {
                return "email must end with .com and cannot be empty";
                
            }
            else if (gender == "")
            {
                return "gender must be chosen and cannot be empty";
                
            }
            else if (validNum != 1 && validLetter != 1)
            {
                    return "must be alpha numeric";
            }
            else if (password.Equals(confirmpassword) == false || confirmpassword == null || confirmpassword == "")
            {
                return "confirm password must be the same with password and cannot be empty";
                
            }
            else if (dob == DateTime.MinValue)
            {
                return "DOB cannot be empty";
                
            }

            return UserHandler.registerUser(username, email, gender, password, dob);
        }

        private bool IsAlphanumeric(string input)
        {
            int validNum = 0;
            int validLetter = 0;
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    validNum = 1;
                }
                if (char.IsLetter(c))
                {
                    validLetter = 1;
                }
            }
            if (validNum == 1 && validLetter == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}