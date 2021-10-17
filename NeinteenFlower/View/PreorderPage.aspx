<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="PreorderPage.aspx.cs" Inherits="NeinteenFlower.View.PreorderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
        <Columns>
             <asp:BoundField HeaderText="Flower Name" DataField="FlowerName"/>
            <asp:BoundField HeaderText="Description" DataField="FlowerDescription"/>
            <asp:BoundField HeaderText="Price" DataField="FlowerPrice"/>
            <asp:ImageField HeaderText="Image" DataImageUrlField="FlowerImage" ControlStyle-Width="100" ControlStyle-Height = "100"/>
            <asp:ButtonField ButtonType="Button" Text="Pre Order" CommandName="Preorder" />
        </Columns>
    </asp:GridView>
</asp:Content>
