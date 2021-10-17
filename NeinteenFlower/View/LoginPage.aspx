<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="NeinteenFlower.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>LOGIN</h2>
        </div>
        <div>
             <asp:Label ID="EmailLbl" runat="server" Text="Email : "></asp:Label>
            <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="PasswordLbl" runat="server" Text="Password : "></asp:Label>
            <asp:TextBox ID="PasswordTxt" runat="server" ></asp:TextBox>
            <br />
            <br />
            <asp:CheckBox ID="RememberMe" text="Remeber Me" runat="server" />
            <br />
            <br />
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
            <br />
            <br />
            <asp:Label ID="ErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <a href="./RegisterPage.aspx">Register</a>
            <br />
            <a href="./ForgotPasswordPage.aspx">Forgot Password</a>
        </div>
    </form>
</body>
</html>
