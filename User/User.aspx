<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="User.aspx.cs" Inherits="User_User" %>

<asp:Content runat="server" ID="User" ContentPlaceHolderID="MainContent">
    <asp:Table runat="server" ID="UserData">
        <asp:TableRow runat="server" ID="TableRow1" Height="35px">
            <asp:TableCell runat="server" ID="TableCell1">使用者名稱</asp:TableCell>
            <asp:TableCell runat="server" ID="tableCell2">
                <asp:TextBox runat="server" ID="UserName" Width="200px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" ID="TableRow2" Height="35px">
            <asp:TableCell runat="server" ID="TableCell3">電子信箱</asp:TableCell>
            <asp:TableCell runat="server" ID="TableCell4">
                <asp:TextBox runat="server" ID="UserEmail" Width="200px" TextMode="Email"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="UserEmail" ErrorMessage="無效的電子信箱格式!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <%--<asp:TableRow runat="server" ID="TableRow3" Height="35px">
            <asp:TableCell runat="server" ID="TableCell5">密碼</asp:TableCell>
            <asp:TableCell runat="server" ID="TableCell6">
                <asp:TextBox runat="server" ID="UserPassword" TextMode="Password" Width="200px"></asp:TextBox>
                <asp:TextBox runat="server" ID="UserPasswordEdit" TextMode="Password" Width="200px" Enabled="false" Visible="false"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ControlToValidate="UserPassword"  ErrorMessage="密碼長度4到10個字元、至少要有一個特殊符號、至少要有一個大寫或小寫的英文字母、至少要有一個0-9的數字" ValidationExpression="^(?!.*[^\x21-\x7e])(?=.{4,10})(?=.*[\W])(?=.*[a-zA-Z])(?=.*\d).*$"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="UserPasswordEdit" ErrorMessage="密碼長度4到10個字元、至少要有一個特殊符號、至少要有一個大寫或小寫的英文字母、至少要有一個0-9的數字" ValidationExpression="^(?!.*[^\x21-\x7e])(?=.{4,10})(?=.*[\W])(?=.*[a-zA-Z])(?=.*\d).*$"></asp:RegularExpressionValidator>                    
            </asp:TableCell>
        </asp:TableRow>--%>
        <asp:TableRow runat="server" Height="35px">
            <asp:TableCell runat="server" Width="100px">性別</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:RadioButton runat="server" GroupName="sex" ID="male" Text="男" />&nbsp
                <asp:RadioButton runat="server" GroupName="sex" ID="female" Text="女" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Height="35px">
            <asp:TableCell runat="server">稱謂:</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox runat="server" ID="UserTitle" Width="200px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Height="35px">
            <asp:TableCell runat="server">手機:</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox runat="server" ID="UserPhone" TextMode="Number" Width="200px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Height="35px">
            <asp:TableCell runat="server">所屬群組:</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Label runat="server" ID="UserGroup" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button runat="server" ID="commit" Text="儲存" OnClick="commit_Click" />

</asp:Content>