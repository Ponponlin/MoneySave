<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" ValidateRequest="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="CSS/bootstrap.min.css" />
    <link rel="stylesheet" href="CSS/Login.css" />
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <div class=" row align-items-center">
            <div class="col-sm"></div>
            <div class="col-sm">
                <p class="rounded p-head">歡迎使用MoneySave</p>
                <form id="form1" runat="server" class="rounded" style="padding:5px;box-shadow:3px 3px 5px grey;background-color:#e2e2e2">
                    <div class="form-group">
                        <asp:Label runat="server" Text="帳號："></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="email"></asp:TextBox>                    
                        <asp:Label runat="server" Text="密碼："></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" ID="password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col"></div>
                            <div class="col-5">
                                <asp:Button runat="server" CssClass="btn btn-primary" ID="login" OnClick="login_Click" Text="登入" />
                                <asp:Button runat="server" CssClass="btn btn-success" text="註冊"/>
                            </div>
                            <div class="col"></div>
                        </div>
                    </div>
                        
                </form>
            </div>
            <div class="col-sm"></div>
        </div>
    </div>
</body>
</html>
