<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pre OrderPage.aspx.cs" Inherits="NeinteenFlower.View.Pre_OrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
    <asp:Label ID="FlowerNameLbl" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="DescriptionLbl" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="PriceLbl" runat="server" Text=""></asp:Label>
    <br />
    <asp:Image ID="Image" Width="100px" Height="100px" runat="server" />
    <br />
    <br />
    <asp:Label ID="QuantityLbl" runat="server" Text="Quantity : "></asp:Label>
    <asp:TextBox ID="QuantityTxt" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="ErrorMsg" runat="server" Text="" ForeColor="Red" ></asp:Label>
    <br />
    <br />
    <asp:Button ID="PreorderBtn" runat="server" Text="Preorder" OnClick="PreorderBtn_Click"  />
</asp:Content>
