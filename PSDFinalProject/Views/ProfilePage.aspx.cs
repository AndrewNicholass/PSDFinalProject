﻿using PSDFinalProject.Controllers;
using PSDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDFinalProject.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

                TextBoxUsername.Text = user.Username;
                TextBoxEmail.Text = user.UserEmail;
                TextBoxDOB.Text = (user.UserDOB).ToString();
                TextBoxGender.Text = user.UserGender;
                TextBoxRole.Text = user.UserRole;
            }
        }
    }
}