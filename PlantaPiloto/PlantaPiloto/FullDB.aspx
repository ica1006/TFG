<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullDB.aspx.cs" Inherits="WebPlantaPiloto.FullDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body id="bodyTag" runat="server">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="500" OnTick="updateTable">
                    </asp:Timer>
                    <table style="width: 80%; margin: 0 auto;">
                        <tr style="text-align: center; width: 50%;">
                            <td>
                                <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Back" Font-Names="helvetica" Font-Size="14pt" />
                            </td>
                            <td>
                                <asp:Button ID="btn_StartStop" runat="server" OnClick="btn_StartStop_Click" Text="Stop Auto-Refresh" Font-Names="helvetica" Font-Size="14pt" />
                            </td>
                        </tr>
                        <tr style="text-align: center; width: 50%;">
                            <td>
                                <asp:Label ID="lbl_valuesDB" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Values Data Base"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_changesDB" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Changes Data Base"></asp:Label>
                            </td>
                        </tr>
                        <tr style="text-align: center; width: 50%;">
                            <td style="vertical-align: top;">
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderWidth="0px" CellPadding="12" CellSpacing="0" Font-Names="helvetica" Font-Size="14pt" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center">
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
                            </td>
                            <td style="vertical-align: top;">
                                <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderWidth="0px" CellPadding="12" CellSpacing="0" Font-Names="helvetica" Font-Size="14pt" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center">
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
                            </td>
                        </tr>
                        <tr style="text-align: center; width: 50%; height:50px;">
                            <td colspan="2" style="vertical-align: top; height:50px;">&nbsp;</td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
