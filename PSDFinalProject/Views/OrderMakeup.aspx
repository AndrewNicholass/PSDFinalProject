<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="OrderMakeup.aspx.cs" Inherits="PSDFinalProject.Views.OrderMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="server">
    <h1>
        This is Order Makeup Page
    </h1>
    <div>
        <asp:GridView ID="GridViewMakeupDetails" runat="server" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged1">
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="Btn_Order" class="order_button" runat="server" Text="  Order  " CommandName="Order" UseSubmitBehavior="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupTypeName" HeaderText="Makeup Type Name" SortExpression="MakeupTypeName" />
                <asp:BoundField DataField="MakeupBrandName" HeaderText="Makeup Brand Name" SortExpression="MakeupBrandName" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxQuantity" class="textbox" runat="server" Text="0"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>


        </asp:GridView>
    </div>
    <div class="center">
        <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:GridView runat="server"></asp:GridView>

</asp:Content>
