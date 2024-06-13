using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using PSDFinalProject.Controllers;


namespace PSDFinalProject.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool validation = false;
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text;
            string email = TextBoxEmail.Text;
            string gender = RadioButtonMale.Checked ? "Male" : RadioButtonFemale.Checked ? "Female" : string.Empty;
            string password = TextBoxPassword.Text;
            string confirmpassword = TextBoxConfirmPassword.Text;
            DateTime dob = CalendarDOB.SelectedDate;

            LabelError.Text = UserController.validateRegistration(username, email, gender, password, confirmpassword, dob);
            
            if(LabelError.Text.Equals("registration success!"))
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}