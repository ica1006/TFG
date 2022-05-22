<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullDB.aspx.cs" Inherits="WebPlantaPiloto.FullDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:SqlDataSource ID="WebDB" runat="server"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
