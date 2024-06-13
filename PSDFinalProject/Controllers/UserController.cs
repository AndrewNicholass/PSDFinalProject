using PSDFinalProject.Handlers;
using PSDFinalProject.Models;
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

        public static string validateLogin(string username, string password)
        {
            if (username == "")
            {
                return "Username is required!";
            }
            if (password == "")
            {
                return "Password is required!";
            }

            return UserHandler.loginUser(username, password);
        }

        public static string validateUpdateProfile(int id, string username, string email, string gender, DateTime dob)
        {
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
            else if (dob == DateTime.MinValue)
            {
                return "DOB cannot be empty";

            }

            return UserHandler.updateUserProfile(id,  username, email, gender, dob);
        }

        public static string validateUpdatePassword(int id, string oldPassword, string newPassword)
        {
            bool isValid = UserHandler.checkOldPassword(id, oldPassword);
            if(isValid == false)
            {
                return "old password is wrong!";
            }

            return UserHandler.changeUserPassword(id, newPassword);
        }

        public static User getUserByUsername(string username)
        {
            return UserHandler.getUserByUsername(username);
        }

        public static User getUserByID(int id)
        {
            return UserHandler.getUserByID(id);
        }

        public static string validateRoleByUsername(string username)
        {
            return UserHandler.checkRoleByUsername(username);
        }

        public static string validateIdByUsername(string username)
        {
            return UserHandler.checkIdByUsername(username);
        }

        public static string validateRoleById(int id)
        {
            return UserHandler.checkRoleById(id);
        }

        public static List<object> showAllCustomers()
        {
            return UserHandler.getAllCustomers();
        }

        public static List<User> showAllUsers()
        {
            return UserHandler.getAllUsers();
        }

        public static string showUsernameByID(string id)
        {
            return UserHandler.getUsernameByID(id);
        }
    }
}