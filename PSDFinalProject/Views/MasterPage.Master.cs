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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ButtonHome.Visible = false;
            ButtonManageMakeup.Visible = false;
            ButtonOrderQueue.Visible = false;
            ButtonProfile.Visible = false;
            ButtonTransactionReport.Visible = false;
            ButtonOrderMakeup.Visible=false;
            ButtonHistory.Visible = false;

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

                string userRole = user.UserRole.ToString();
                if(userRole == "admin")
                {
                    ButtonHome.Visible = true;
                    ButtonManageMakeup.Visible = true;
                    ButtonOrderQueue.Visible = true;
                    ButtonProfile.Visible = true;
                    ButtonTransactionReport.Visible = true;
                }
                if(userRole == "customer")
                {
                    ButtonOrderMakeup.Visible = true;
                    ButtonHistory.Visible = true;
                    ButtonProfile.Visible = true;
                    ButtonHome.Visible = true;
                }

            }
        }

        protected void ButtonOrderMakeup_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderMakeup.aspx");
        }

        protected void ButtonHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistoryPage.aspx");
        }

        protected void ButtonProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfilePage.aspx");
        }

        protected void ButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void ButtonManageMakeup_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeup.aspx");
        }

        protected void ButtonOrderQueue_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderQueue.aspx");
        }

        protected void ButtonTransactionReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionReport.aspx");
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {

        }
    }
}