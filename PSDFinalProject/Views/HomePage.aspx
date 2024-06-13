<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="PSDFinalProject.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="server">
    <h1>This is Home Page</h1>

    <div>
        Role :
        <asp:Label ID="LabelRole" runat="server" Text=""></asp:Label>
    </div>
    <div>
        Name :
        <asp:Label ID="LabelName" runat="server" Text=""></asp:Label>
    </div>
    <div id="ListUserContainer" runat="server">
        <h1>List Users</h1>
        <asp:ListBox ID="ListBoxUser" runat="server" OnSelectedIndexChanged="ListBoxUser_SelectedIndexChanged"></asp:ListBox>
    </div>
</asp:Content>
