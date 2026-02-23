<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_20_02_FirstApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Hello All</h1>
            <p> Name</p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <input id="Submit1" type="submit" value="submit" />
            
        </div>
        <div style="background-color:aqua">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" />

        </div>

    </form>
</body>
</html>
