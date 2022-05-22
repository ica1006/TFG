<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullDB.aspx.cs" Inherits="WebPlantaPiloto.FullDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Volver" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="500" OnTick="updateTable">
                    </asp:Timer>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderWidth="0px" CellPadding="12" Font-Names="helvetica" Font-Size="14pt" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" CellSpacing="0">
                        <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#E3E3E3" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" Width="200px" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F0F0F0" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
