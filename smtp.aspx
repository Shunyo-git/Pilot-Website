<%@ Page Language="C#" AutoEventWireup="true" CodeFile="smtp.aspx.cs" Inherits="smtp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        SMTP<asp:TextBox ID="txtServer" runat="server"></asp:TextBox>
        <br />
        TO<asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Button1_Click" />
    </div>
    </form>
    
</body>
</html>
