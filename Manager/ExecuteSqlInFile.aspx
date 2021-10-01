<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExecuteSqlInFile.aspx.cs" Inherits="Manager_ExecuteSqlInFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        File Name :
        <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox>
        <asp:Button ID="btnExecute" runat="server" OnClick="btnExecute_Click" Text="GO" /></div>
    </form>
</body>
</html>
