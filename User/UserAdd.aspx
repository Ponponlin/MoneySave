<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="UserAdd.aspx.cs" Inherits="User_UserAdd" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="MainContent">
    <div id="form-content">
        <asp:Label runat="server" Text="電子信箱"></asp:Label>
        <asp:TextBox runat="server" AutoPostBack="false" ID="UserEmail"></asp:TextBox><br />
        <asp:Label runat="server" Text="密碼"></asp:Label>
        <asp:TextBox runat="server" TextMode="Password" ID="UserPassword"></asp:TextBox><br />
        <asp:Label runat="server" Text="姓名"></asp:Label>
        <asp:TextBox runat="server" ID="UserName"></asp:TextBox><br />
        <asp:Label runat="server" Text="性別"></asp:Label>
        <asp:RadioButton runat="server" GroupName="sex" ID="male" Text="男" />
        <asp:RadioButton runat="server" GroupName="sex" ID="female" Text="女" /><br />
        <asp:Label runat="server" Text="稱謂"></asp:Label>
        <asp:TextBox runat="server" ID="UserTitle"></asp:TextBox><br />
        <asp:Label runat="server" Text="手機號碼"></asp:Label>
        <asp:TextBox runat="server" ID="UserPhone"></asp:TextBox>
    </div>
    <asp:Button runat="server" ID="submit" OnClick="submit_Click" Text="送出" />
</asp:Content>
