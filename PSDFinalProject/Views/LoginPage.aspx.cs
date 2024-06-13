using System;
using PSDFinalProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDFinalProject.Controllers;

namespace PSDFinalProject.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text;
            string password = TextBoxPassword.Text;
            bool isRemember = RememberMe.Checked;

            LabelError.Text = UserController.validateLogin(username, password);

            if(LabelError.Text == "login success!")
            {

                string role = UserController.validateRoleByUsername(username);
                User user = UserController.getUserByUsername(username);
                Session["user"] = user;
                if (isRemember)
                {

                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1); ;
                    Response.Cookies.Add(cookie);
                    if (role == "admin")
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                    else
                    {
                        Response.Redirect("OrderMakeup.aspx");
                    }
                }
                else
                {
                    LabelError.Text = "Check box must be checked";
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }
    }
}