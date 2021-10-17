<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageFlowerPage.aspx.cs" Inherits="NeinteenFlower.View.ManageFlowerPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            <asp:BoundField HeaderText="Flower Name" DataField="FlowerName"/>
            <asp:BoundField HeaderText="Description" DataField="FlowerDescription"/>
            <asp:BoundField HeaderText="Price" DataField="FlowerPrice"/>
            <asp:ImageField HeaderText="Image" DataImageUrlField="FlowerImage" ControlStyle-Width="100" ControlStyle-Height = "100"/>
            <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Update" />
            <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="Delete" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <a href="./InsertFlowerPage.aspx">Insert Flower</a>
</asp:Content>
