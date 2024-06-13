using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;


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
            bool validation = true;

            if(username.Length <= 5 || username.Length >= 15 || username == null || username == "")
            {
                LabelError.Text = "username Length must be between 5 and 15, must be unique, cannot be empty";
                validation = false;
            }
            else if(email.EndsWith(".com") == false || email == null || email == "")
            {
                LabelError.Text = "email must end with .com and cannot be empty";
                validation = false;
            }
            else if(gender == "")
            {
                LabelError.Text = "gender must be chosen and cannot be empty";
                validation = false;
            }
            else if(IsAlphanumeric(password) == false)
            {
                LabelError.Text = "must be alpha numeric";
                validation = false;
            }
            else if(password.Equals(confirmpassword) == false || confirmpassword == null || confirmpassword == "")
            {
                LabelError.Text = "confirm password must be the same with password and cannot be empty";
                validation = false;
            }
            else if(dob == DateTime.MinValue)
            {
                LabelError.Text = "DOB cannot be empty";
                validation = false;
            }


            Response.Redirect("LoginPage.aspx");
        }

        private bool IsAlphanumeric(string input)
        {
            int validNum = 0;
            int validLetter = 0;
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    validNum = 1; 
                }
                if (char.IsLetter(c))
                {
                    validLetter = 1;
                }
            }
            if(validNum == 1 && validLetter == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}