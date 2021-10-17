<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageMemberPage.aspx.cs" Inherits="NeinteenFlower.View.ManageMemberPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
     <asp:GridView ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField HeaderText="Name" DataField="MemberName" SortExpression="MemberName" />
            <asp:BoundField HeaderText="Date of Birth" DataField="MemberDOB" SortExpression="MemberDOB" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="Gender" DataField="MemberGender" SortExpression="MemberGender" />
            <asp:BoundField HeaderText="Address" DataField="MemberAddress" SortExpression="MemberAddress" />
            <asp:BoundField HeaderText="Phone Number" DataField="MemberPhone" SortExpression="MemberPhone" />
            <asp:BoundField HeaderText="Email" DataField="MemberEmail" SortExpression="MemberEmail" />
            <asp:BoundField HeaderText="Password" DataField="MemberPassword" SortExpression="MemberPassword" />
            <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Update" />
            <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="Delete" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <a href="./InsertMemberPage.aspx">Insert Member</a>
</asp:Content>
