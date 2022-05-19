<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPlantaPiloto._Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <table class="nav-justified">
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">&nbsp;</td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">&nbsp;</td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">&nbsp;</td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">&nbsp;</td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">
                    <asp:Label ID="lbl_1" runat="server" Text="Introduce el Connection String de la base de datos"></asp:Label>
                </td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">&nbsp;</td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">
                    <asp:TextBox ID="txtIn_1" runat="server" Width="397px"></asp:TextBox>
                    <asp:Button ID="btn_Conectar" runat="server" OnClick="btn_Conectar_Click" Text="Conectar" />
                </td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 20px; width: 313px;"></td>
                <td style="width: 493px; height: 20px"></td>
                <td style="width: 911px; height: 20px"></td>
                <td style="height: 20px; width: 187px;"></td>
                <td style="height: 20px; width: 171px;"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 313px;"></td>
                <td style="width: 493px; height: 20px">
                    <asp:Label ID="lbl_2" runat="server" Text="Conexión con la base de datos: "></asp:Label>
                    <asp:Label ID="lbl_3" runat="server" ForeColor="Red" Text="false"></asp:Label>
                </td>
                <td style="width: 911px; height: 20px">
                    &nbsp;</td>
                <td style="height: 20px; width: 187px;"></td>
                <td style="height: 20px; width: 171px;"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 313px;"></td>
                <td style="width: 493px; height: 20px"></td>
                <td style="width: 911px; height: 20px">
                    &nbsp;</td>
                <td style="height: 20px; width: 187px;"></td>
                <td style="height: 20px; width: 171px;"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 313px;"></td>
                <td style="width: 493px; height: 20px">
                    <asp:Table ID="Table1" runat="server" BorderWidth="1px" HorizontalAlign="Center" Width="200px">
                    </asp:Table>
                </td>
                <td style="width: 911px; height: 20px">
                    <asp:Button ID="btn_grafico" runat="server" OnClick="btn_grafico_Click" Text="Ver gráfico" />
                </td>
                <td style="height: 20px; width: 187px;">
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
                <td style="height: 20px; width: 171px;"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">
                    <asp:Label ID="lbl_5" runat="server" Font-Bold="True" Text="Nuevo Valor"></asp:Label>
                </td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 313px; height: 22px"></td>
                <td style="width: 493px; height: 22px;">
                    <asp:DropDownList ID="ddList_1" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddList_2" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="height: 22px"></td>
                <td style="width: 170px; height: 22px;"></td>
                <td style="width: 187px; height: 22px"></td>
                <td style="width: 171px; height: 22px"></td>
                <td style="height: 22px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 313px"></td>
                <td style="width: 493px; height: 20px;">
                    <asp:TextBox ID="txtIn_2" runat="server"></asp:TextBox>
                    <asp:Button ID="btn_actualizar" runat="server" OnClick="btn_actualizar_Click" Text="Actualizar" />
                </td>
                <td style="width: 911px; height: 20px;"></td>
                <td style="width: 187px; height: 20px"></td>
                <td style="width: 171px; height: 20px"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 313px; height: 20px"></td>
                <td style="width: 493px; height: 20px;">
                    <asp:Label ID="lbl_error" runat="server" ForeColor="Red" Text="Gestor de Excepciones"></asp:Label>
                </td>
                <td style="width: 911px; height: 20px;"></td>
                <td style="width: 187px; height: 20px"></td>
                <td style="width: 171px; height: 20px"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px; height: 20px"></td>
                <td style="width: 493px; height: 20px;"></td>
                <td style="width: 911px; height: 20px;"></td>
                <td style="width: 187px; height: 20px"></td>
                <td style="width: 171px; height: 20px"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 313px"></td>
                <td style="width: 493px; height: 20px;"></td>
                <td style="width: 911px; height: 20px;"></td>
                <td style="width: 187px; height: 20px"></td>
                <td style="width: 171px; height: 20px"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 313px"></td>
                <td style="width: 493px; height: 20px;"></td>
                <td style="width: 911px; height: 20px;"></td>
                <td style="width: 187px; height: 20px"></td>
                <td style="height: 20px; width: 171px"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="height: 20px; width: 313px"></td>
                <td style="width: 493px; height: 20px;"></td>
                <td style="width: 911px; height: 20px;"></td>
                <td style="width: 187px; height: 20px"></td>
                <td style="width: 171px; height: 20px"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">&nbsp;</td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">&nbsp;</td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">&nbsp;</td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 313px">&nbsp;</td>
                <td style="width: 493px">&nbsp;</td>
                <td style="width: 911px">&nbsp;</td>
                <td style="width: 187px">&nbsp;</td>
                <td style="width: 171px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>

</asp:Content>
