using PSDFinalProject.Controllers;
using PSDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDFinalProject.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListUserContainer.Visible = false;

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
                    user = (User) Session["user"];
                }

                LabelName.Text = user.Username;
                LabelRole.Text = user.UserRole;

                if (user.Username.Equals("admin"))
                {
                    ListUserContainer.Visible = true;
                    List<User> u = UserController.showAllUsers();
                    foreach(var x in u)
                    {
                        ListBoxUser.Items.Add(x.Username);
                    }
                }
            }


        }

        protected void ListBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}