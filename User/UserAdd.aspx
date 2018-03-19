<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="UserAdd.aspx.cs" Inherits="User_UserAdd" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="MainContent">
    <div id="form-content">
        <asp:Table runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableCell Width="150px">
                    <asp:Label runat="server" Text="電子信箱"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" AutoPostBack="false" ID="UserEmail"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="密碼"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" TextMode="Password" ID="UserPassword"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
                
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="姓名"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="UserName"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
                
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="性別"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButton runat="server" GroupName="sex" ID="male" Text="男" />&nbsp
                    <asp:RadioButton runat="server" GroupName="sex" ID="female" Text="女" />
                </asp:TableCell>
            </asp:TableRow>
                
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="稱謂"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="UserTitle"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
               
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="手機號碼"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="UserPhone"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>        
    </div>
    <asp:Button runat="server" ID="submit" OnClick="submit_Click" Text="送出" />
</asp:Content>
