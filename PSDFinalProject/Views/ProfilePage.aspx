<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="PSDFinalProject.Views.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="server">
    <h1>
        This is Profile Page
    </h1>
    <div>
        <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LabelDOB" runat="server" Text="DOB"></asp:Label>
        <asp:TextBox ID="TextBoxDOB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
        <asp:TextBox ID="TextBoxGender" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LabelRole" runat="server" Text="Role"></asp:Label>
        <asp:TextBox ID="TextBoxRole" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LabelError" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
    </div>
    <div>
        <asp:Label ID="LabelOldPassword" runat="server" Text="Old Password"></asp:Label>
        <asp:TextBox ID="TextBoxOldPassword" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LabelNewPassword" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="TextBoxNewPassword" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="ButtonUpdatePassword" runat="server" Text="Update Password" OnClick="ButtonUpdatePassword_Click" />
    </div>
</asp:Content>
