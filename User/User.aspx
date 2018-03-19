<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="User.aspx.cs" Inherits="User_User" %>

<asp:Content runat="server" ID="User" ContentPlaceHolderID="MainContent">
    <div id="form-content">
        <asp:Table runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableCell Width="150px">使用者名稱</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="UserName" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>電子信箱</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="UserEmail" TextMode="Email" Enabled="false"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="UserEmail" ErrorMessage="無效的電子信箱格式!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>密碼</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="UserPassword" Enabled="false"></asp:TextBox><br />
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ControlToValidate="UserPassword"  ErrorMessage="密碼長度4到10個字元、至少要有一個特殊符號、至少要有一個大寫或小寫的英文字母、至少要有一個0-9的數字" ValidationExpression="^(?!.*[^\x21-\x7e])(?=.{4,10})(?=.*[\W])(?=.*[a-zA-Z])(?=.*\d).*$"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>再輸入一次密碼</asp:TableCell>
                <asp:TableCell>
                        <asp:TextBox runat="server" ID="UserPasswordEdit" Enabled="false" Visible="true"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="UserPasswordEdit" ErrorMessage="密碼長度4到10個字元、至少要有一個特殊符號、至少要有一個大寫或小寫的英文字母、至少要有一個0-9的數字" ValidationExpression="^(?!.*[^\x21-\x7e])(?=.{4,10})(?=.*[\W])(?=.*[a-zA-Z])(?=.*\d).*$"></asp:RegularExpressionValidator>                    
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow> 
                <asp:TableCell>性別</asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButton runat="server" GroupName="sex" ID="male" Enabled="false" Text="男"  />&nbsp
                    <asp:RadioButton runat="server" GroupName="sex" ID="female" Enabled="false" Text="女" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>稱謂:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="UserTitle" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>手機:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="UserPhone" TextMode="Number" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>所屬群組:</asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="UserGroup" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <asp:Button runat="server" ID="commit" Text="儲存" Visible="false" OnClick="commit_Click" />
    <asp:Button runat="server" ID="alater" Text="修改" OnClick="later_Click" />
</asp:Content>