<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPasswordPage.aspx.cs" Inherits="NeinteenFlower.View.ForgotPasswordPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Forgot Password</h2>
        </div>
        <div>
           <asp:Label ID="EmailLbl" runat="server" Text="Email : "></asp:Label>
            <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Captcha : "></asp:Label>
            <asp:Label ID="CaptchaLbl" runat="server" Text="" ForeColor="White" BackColor="DarkBlue"></asp:Label>
            <br />
            <asp:Label ID="NewPasswordLbl" runat="server" Text="New Password : "></asp:Label>
            <asp:TextBox ID="NewPasswordTxt" placeholder="Must be the same as captcha" runat="server" Width="200px" ></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="ErrorMsg" runat="server" Text="" ForeColor="Red" ></asp:Label>
            <br />
            <br />
            <asp:Button ID="ChangePasswordBtn" runat="server" Text="Change Password" OnClick="ChangePasswordBtn_Click" />
        </div>
    </form>
</body>
</html>
