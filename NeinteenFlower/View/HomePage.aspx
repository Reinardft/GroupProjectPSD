<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="NeinteenFlower.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Welcome, "></asp:Label>
    <asp:Label ID="UsernameLbl" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:Button ID="ViewTransactionBtn" runat="server" Text="View Transaction History" Visible="false" OnClick="ViewTransactionBtn_Click"/>
    <asp:Button ID="PreorderBtn" runat="server" Text="Preorder" Visible="false" OnClick="PreorderBtn_Click" />
    <asp:Button ID="ManageFlowerBtn" runat="server" Text="Manage Flower" OnClick="ManageFlowerBtn_Click" Visible="false" />
    <asp:Button ID="ManageMemberBtn" runat="server" Text="Manage Member" OnClick="ManageMemberBtn_Click" Visible="false" />
    <asp:Button ID="ManageEmployeeBtn" runat="server" Text="Manage Employee" OnClick="ManageEmployeeBtn_Click" Visible="false"/>
    
</asp:Content>
