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