<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="otp_check.aspx.cs" Inherits="rku_system.otp_check" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="Enter Email"></asp:Label>
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="s" runat="server" OnClick="s_Click" Text="send" />

        </div>
    </form>
</body>
</html>
