<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="根据ID查询" OnClick="Button1_Click" />
    
    </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br />
    </form>
</body>
</html>
