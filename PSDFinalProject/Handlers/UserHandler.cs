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

        public static string loginUser(string username, string password)
        {
            User user = UserRepository.getUserByUsernameAndPassword(username, password);
            if(user != null)
            {
                return "login success!";
            }
            return "user not found!";
        }

        public static string updateUserProfile(int id, string username, string email,string gender, DateTime dob)
        {
            User user = UserRepository.getUserById(id);

            if (user != null)
            {
                return UserRepository.updateUserProfile(user, username, email, gender, dob);
            }
            return "user not found!";
        }

        public static string checkRoleByUsername(string username)
        {
            User user = UserRepository.getUserByUsername(username);
            if (user != null)
            {
                return user.UserRole;
            }
            return "";
        }

        public static User getUserByUsername(string username)
        {
            User user = UserRepository.getUserByUsername(username);
            if(user != null)
            {
                return user;
            }
            return null;
        }

        public static User getUserByID(int id)
        {
            User user = UserRepository.getUserById(id);
            if( user != null)
            {
                return user;
            }
            return null;
        }

        public static string checkIdByUsername(string username)
        {
            User user = UserRepository.getUserByUsername(username);
            if (user != null)
            {
                return user.UserID.ToString();
            }
            return "";
        }

        public static string checkRoleById(int id)
        {
            User user = UserRepository.getUserById(id);
            if (user != null)
            {
                return user.UserRole;
            }
            return "";
        }

        public static List<object> getAllCustomers()
        {
            return UserRepository.getAllUsers();
        }

        public static List<User> getAllUsers()
        {
            return UserRepository.getAllUser();
        }

        public static string getUserEmail(int id)
        {
            User user = UserRepository.getUserById(id);
            if (user != null)
            {
                return user.UserEmail;
            }
            return "";
        }

        public static string getUserGender(int id)
        {
            User user = UserRepository.getUserById(id);
            if (user != null)
            {
                return user.UserGender;
            }
            return "";
        }

        public static string getUserDOB(int id)
        {
            User user = UserRepository.getUserById(id);
            if (user != null)
            {
                return user.UserDOB.ToString("dd-MM-yyyy");
            }
            return "";
        }

        public static string getUsernameByID(string id)
        {
            int idint = Convert.ToInt32(id);
            User user = UserRepository.getUserById(idint);
            if (user != null)
            {
                return user.Username;
            }
            return "";
        }

        public static string changeUserPassword(int id, string password)
        {
            User user = UserRepository.getUserById(id);
            if (user != null)
            {
                return UserRepository.updateUserPassword(user, password);
            }
            return "user not found!";
        }

        public static bool checkOldPassword(int id, string password)
        {
            User user = UserRepository.getUserById(id);
            if (user != null)
            {
                if(user.UserPassword == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}