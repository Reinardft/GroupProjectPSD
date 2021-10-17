<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="InsertMemberPage.aspx.cs" Inherits="NeinteenFlower.View.InsertMemberPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
     <asp:Label ID="EmailLbl" runat="server" Text="Email : "></asp:Label>
             <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="PasswordLbl" runat="server" Text="Password : "></asp:Label>
            <asp:TextBox ID="PasswordTxt" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="NameLbl" runat="server" Text="Name : "></asp:Label>
            <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="AgeLbl" runat="server" Text="Age : "></asp:Label>
            <asp:TextBox ID="AgeTxt" runat="server" textmode="Date"></asp:TextBox>
            <br />
            <asp:Label ID="GenderLbl" runat="server" Text="Gender :"></asp:Label>
            <asp:RadioButtonList ID="GenderList" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="PhoneNumberLbl" runat="server" Text="Phone Number : "></asp:Label>
            <asp:TextBox ID="PhoneNumberTxt" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="AddressLbl" runat="server" Text="Address : "></asp:Label>
            <asp:TextBox ID="AddressTxt" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="ErrorMsg" runat="server" Text="" ForeColor="Red" ></asp:Label>
            <br />
            <br />
            <asp:Button ID="InsertBtn" runat="server" Text="Insert Member" OnClick="InsertBtn_Click" />
</asp:Content>
