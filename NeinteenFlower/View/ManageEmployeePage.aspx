<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageEmployeePage.aspx.cs" Inherits="NeinteenFlower.View.ManageEmployeePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting ="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="Name" DataField="EmployeeName" SortExpression="EmployeeName" />
            <asp:BoundField HeaderText="Date of Birth" DataField="EmployeeDOB" DataFormatString="{0:dd/MM/yyyy}" SortExpression="EmployeeDOB" />
            <asp:BoundField HeaderText="Gender" DataField="EmployeeGender" SortExpression="EmployeeGender" />
            <asp:BoundField HeaderText="Address" DataField="EmployeeAddress" SortExpression="EmployeeAddress" />
            <asp:BoundField HeaderText="Phone Number" DataField="EmployeePhone" SortExpression="EmployeePhone" />
            <asp:BoundField HeaderText="Email" DataField="EmployeeEmail" SortExpression="EmployeeEmail" />
            <asp:BoundField HeaderText="Salary" DataField="EmployeeSalary" SortExpression="EmployeeSalary" />
            <asp:BoundField HeaderText="Password" DataField="EmployeePassword" SortExpression="EmployeePassword" />
            <asp:BoundField HeaderText="Role" DataField="EmployeeRole" SortExpression="EmployeeRole" />
            <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Update" />
            <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="Delete" />
        </Columns>

    </asp:GridView>
    <br />
    <br />
    <a href="./InsertEmployeePage.aspx">Insert Employee</a>
</asp:Content>
