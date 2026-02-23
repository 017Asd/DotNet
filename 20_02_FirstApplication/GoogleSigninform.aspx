<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoogleSigninform.aspx.cs" Inherits="_20_02_FirstApplication.GoogleSigninform" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Google Sign In</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:300px;margin:auto;text-align:center;border:1px solid #ccc;padding:20px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/download.png" Width="100px" />

            <h2>Sign in</h2>
            <h4>Use your Google Account</h4>

            
            <asp:TextBox ID="txtEmail" runat="server" Width="250px" placeholder="Email or phone" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
            <br /><br />

            
            <asp:LinkButton ID="lnkForgot" runat="server">Forgot email?</asp:LinkButton>
                 <asp:LinkButton ID="lnkCreate" runat="server" CssClass="link" OnClick="lnkCreate_Click">
        Create account
    </asp:LinkButton>
        <div class="dropdownWrapper">
    <span class="link" onclick="toggleMenu()">Create account</span>

    <div id="createMenu" class="dropdownMenu">
        <a href="#">For myself</a>
        <a href="#">For my child</a>
        <a href="#">To manage my business</a>
    </div>
</div>

    <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btnNext" />
        
        </div>
    </form>
</body>
</html>