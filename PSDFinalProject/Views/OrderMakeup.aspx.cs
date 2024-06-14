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
    public partial class OrderMakeup : System.Web.UI.Page
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

                    GridViewMakeupDetails.DataSource = MakeupController.showAllMakeupDetails();
                    GridViewMakeupDetails.AutoGenerateColumns = false;
                    GridViewMakeupDetails.DataBind();
                }
            }
        }

        protected void GridViewMakeupDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                string userId = "";
                if (Request.Cookies["user_cookie"] != null)
                {
                    userId = Request.Cookies["user_cookie"].Value;
                }
                else
                {
                    userId = (string)System.Web.HttpContext.Current.Session["user"];
                }

                // get the control that triggered the event
                Control sourceControl = e.CommandSource as Control;
                // get the GridViewRow containing the control that triggered the event
                GridViewRow row = sourceControl.NamingContainer as GridViewRow;
                // get the row index
                int idx = row.RowIndex;

                string MakeupName = GridViewMakeupDetails.Rows[idx].Cells[1].Text;
                TextBox TextBoxQuantity = (TextBox)GridViewMakeupDetails.Rows[idx].FindControl("TBox_Quantity");
                string quantity = TextBoxQuantity.Text;

                Lbl_Status.Text = CartController.validateOrder(userId, MakeupName, quantity);
                if (Lbl_Status.Text == "New cart has been added successfully!" || Lbl_Status.Text == "Cart has been updated successfully!")
                {
                    Response.Redirect("~/View/OrderSupplementPage.aspx");
                }
                else
                {
                    Lbl_Status.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

    }
}