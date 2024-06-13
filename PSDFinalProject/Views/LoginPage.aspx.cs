using System;
using PSDFinalProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDFinalProject.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private Database1Entities1 db = new Database1Entities1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text;
            string passsword = TextBoxPassword.Text;
            bool isRemember = RememberMe.Checked;



            var user = (from x in db.Users where x.Username.Equals(username) && x.UserPassword.Equals(passsword) select x).FirstOrDefault();
            if (user != null)
            {
                Session["user"] = user;

                if (isRemember)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1); ;
                    Response.Cookies.Add(cookie);
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    LabelError.Text = "Check box must be checked";
                }
            }
            else
            {
                LabelError.Text = "User not found";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }
    }
}