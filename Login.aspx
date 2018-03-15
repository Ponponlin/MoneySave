<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" ValidateRequest="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label runat="server" Text="帳號："></asp:Label>
            <asp:TextBox runat="server" ID="email"></asp:TextBox><br />
            <asp:Label runat="server" Text="密碼："></asp:Label>
            <asp:TextBox runat="server" TextMode="Password" ID="password"></asp:TextBox>
            <asp:Button runat="server" ID="login" OnClick="login_Click" Text="登入" />
        </div>
    </div>
    </form>
</body>
</html>
