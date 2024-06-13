using PSDFinalProject.Controllers;
using PSDFinalProject.Models;
using PSDFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDFinalProject.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
                {
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    User user;
                    if (Session["user"] == null)
                    {
                        int id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                        user = UserController.getUserByID(id);
                        Session["user"] = user;
                    }
                    else
                    {
                        user = (User)Session["user"];
                    }
                    string idbyuser = UserController.validateIdByUsername(user.Username);

                    TextBoxUsername.Text = UserController.showUsernameByID(idbyuser);
                    TextBoxEmail.Text = user.UserEmail;
                    TextBoxDOB.Text = (user.UserDOB).ToString();
                    TextBoxGender.Text = user.UserGender;
                    TextBoxRole.Text = user.UserRole;
                }
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    int id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                    user = UserController.getUserByID(id);
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }

                int userid = user.UserID;
                string username = TextBoxUsername.Text;
                string email = TextBoxEmail.Text;
                string dobtext = TextBoxDOB.Text;
                string gender = TextBoxGender.Text;


                DateTime dob;
                bool isDobValid = DateTime.TryParse(dobtext, out dob);

                if (!isDobValid)
                {
                    // Handle the invalid date case
                    // For example, display an error message
                    LabelError.Text = "Invalid Date of Birth.";
                    return;
                }

                LabelError.Text = UserController.validateUpdateProfile(userid, username, email, gender, dob);
                Session["user"] = user;

            }
        }

        protected void ButtonUpdatePassword_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    int id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                    user = UserController.getUserByID(id);
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }
                string password = TextBoxOldPassword.Text;
                string newpassword = TextBoxNewPassword.Text;
                int idUser = user.UserID;

                LabelError.Text = UserController.validateUpdatePassword(idUser, password, newpassword);

            }
        }

    }
}