<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="InsertFlowerPage.aspx.cs" Inherits="NeinteenFlower.View.InsertFlowerPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:Label ID="NameLbl" runat="server" Text="Name : "></asp:Label>
    <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="ImageLbl" runat="server" Text="Image : "></asp:Label>
    <asp:FileUpload ID="ImageUpload" runat="server" />
    <br />
    <asp:Label ID="DescriptionLbl" runat="server" Text="Description : "></asp:Label>
    <asp:TextBox ID="DescriptionTxt" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="FlowerTypeLbl" runat="server" Text="Flower Type : "></asp:Label>
    <asp:TextBox ID="FlowerTypeTxt" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="PriceLbl" runat="server" Text="Price : "></asp:Label>
    <asp:TextBox ID="PriceTxt" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="ErrorMsg" runat="server" Text="" ForeColor="Red" ></asp:Label>
    <br />
    <br />
    <asp:Button ID="InsertBtn" runat="server" Text="Insert Flower" OnClick="InsertBtn_Click" />
</asp:Content>
