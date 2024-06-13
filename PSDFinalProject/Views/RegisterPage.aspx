<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="PSDFinalProject.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            Register Page
        </h1>
        <div>
            <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        </div>
        <div >
            <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButton ID="RadioButtonMale" runat="server" Text="Male" GroupName="gender" />
            <asp:RadioButton ID="RadioButtonFemale" runat="server" GroupName="gender" Text="Female" />
        </div>
        <div>
            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelConfirmPassword" runat="server" Text="ConfirmPassword"></asp:Label>
            <asp:TextBox ID="TextBoxConfirmPassword" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelDOB" runat="server" Text="Date of Birth"></asp:Label>
            <asp:Calendar ID="CalendarDOB" runat="server"></asp:Calendar>
        </div>
        <div>
            <asp:Label ID="LabelError" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" />
        </div>
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Already Have account ? click here</asp:LinkButton>
        </div>
    </form>
</body>
</html>
