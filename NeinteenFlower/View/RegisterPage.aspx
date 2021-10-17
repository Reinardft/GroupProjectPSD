<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="NeinteenFlower.View.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register</h2>
        </div>
        <div>
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
            <asp:TextBox ID="AgeTxt" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <asp:Label ID="GenderLbl" runat="server" Text="Gender :"></asp:Label>
            <asp:RadioButtonList ID="Gender" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
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
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
        </div>
    </form>
</body>
</html>
