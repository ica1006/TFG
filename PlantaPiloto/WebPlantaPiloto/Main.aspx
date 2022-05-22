<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebPlantaPiloto.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 35px;
        }

        .auto-style2 {
            height: 147px;
        }

        .auto-style3 {
            height: 35px;
            width: 27px;
        }

        .auto-style4 {
            height: 147px;
            width: 27px;
        }

        .auto-style5 {
            width: 27px;
        }

        .auto-style6 {
            height: 35px;
            width: 613px;
        }

        .auto-style7 {
            height: 147px;
            width: 613px;
        }

        .auto-style8 {
            width: 613px;
        }

        .rectanguloRedondeado {
            border-radius: 25px;
            background: #F7F7F7;
            padding: 20px;
        }

        .auto-style10 {
            width: 93%;
        }

        .auto-style11 {
            width: 491px;
        }

        .auto-style14 {
            height: 23px;
        }

        .auto-style15 {
            width: 437px;
            height: 26px;
        }

        .auto-style16 {
            height: 26px;
        }

        .auto-style17 {
            height: 169px;
            width: 27px;
        }

        .auto-style18 {
            height: 169px;
            width: 613px;
        }

        .auto-style19 {
            height: 169px;
        }

        .auto-style20 {
            height: 35px;
            width: 169px;
        }

        .auto-style21 {
            height: 147px;
            width: 169px;
        }

        .auto-style22 {
            height: 169px;
            width: 169px;
        }

        .auto-style24 {
            width: 169px;
        }

        .auto-style25 {
            height: 146px;
            width: 27px;
        }

        .auto-style26 {
            height: 146px;
            width: 613px;
        }

        .auto-style27 {
            height: 146px;
            width: 169px;
        }

        .auto-style28 {
            height: 146px;
            width: 27px;
        }

        .auto-style29 {
            width: 236px;
        }

        .auto-style30 {
            width: 249px;
        }

        .auto-style31 {
            height: 35px;
            width: 554px;
        }

        .auto-style33 {
            height: 169px;
            width: 554px;
        }

        .auto-style35 {
            height: 146px;
            width: 554px;
        }

        .auto-style36 {
            width: 554px;
        }

        .auto-style37 {
            width: 432px;
        }

        .auto-style38 {
            width: 100%;
        }

        .auto-style39 {
            width: 86px;
        }

        .auto-style40 {
            width: 121px;
        }

        .auto-style41 {
            width: 71px;
        }

        .auto-style42 {
            border-radius: 25px;
            background: #F7F7F7;
            padding: 20px;
            height: 104px;
        }

        .auto-style43 {
            border-radius: 25px;
            background: #F7F7F7;
            padding: 20px;
            height: 104px;
            width: 603px;
        }

        .auto-style44 {
            height: 438px;
        }

        .auto-style45 {
            height: 438px;
            width: 27px;
        }

        .auto-style46 {
            height: 438px;
            width: 613px;
        }

        .auto-style47 {
            height: 438px;
            width: 169px;
        }

        .auto-style49 {
            height: 23px;
            width: 533px;
        }

        .auto-style50 {
            width: 533px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table class="auto-style38">
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style6">
                        <asp:Label ID="lbl_err_ConString" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_err_ConString" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style20"></td>
                    <td class="auto-style31"></td>
                    <td class="auto-style20"></td>
                    <td class="auto-style31"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style7">
                        <div id="div_ConnString" class="rectanguloRedondeado">
                            <asp:Panel ID="panelConnectionString" runat="server" DefaultButton="btn_ConnString">
                                <asp:Label ID="lbl_ConString" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Data Base - Connection String"></asp:Label>
                                <table class="auto-style10">
                                    <tr>
                                        <td class="auto-style11">
                                            <asp:TextBox ID="txtIn_ConnString" runat="server" Font-Names="helvetica" Font-Size="14pt" Height="28px" Width="456px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_ConnString" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Names="helvetica" Height="32px" Text="Connect" Width="70px" OnClick="btn_ConnString_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <table class="auto-style10">
                                    <tr>
                                        <td class="auto-style15">
                                            <asp:Label ID="lbl_Connection" runat="server" Font-Names="helvetica" Font-Size="10pt" Text="Data Base connected: " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lbl_ConnectionStatus" runat="server" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="false" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td class="auto-style16">
                                            <asp:LinkButton ID="linkButtonFullDB" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" OnClick="hlink_fulldb_DataBinding" Visible="False">View Full db</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                    <td class="auto-style21"></td>
                    <td colspan="3" rowspan="3">
                        <div id="div_Chart" class="rectanguloRedondeado">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Timer ID="Timer1" runat="server" OnTick="LoadChart" Interval="1000" />
                                    <asp:Chart ID="chart_Var" runat="server" BackColor="Transparent" Height="718px" Width="1375px">
                                        <Series>
                                            <asp:Series Name="Series1">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                    <asp:Label ID="lbl_err_Chart" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_error_Chart" Visible="False"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>


                        </div>
                    </td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style17"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style22"></td>
                    <td class="auto-style19"></td>
                </tr>
                <tr>
                    <td class="auto-style45"></td>
                    <td class="auto-style46">
                        <div id="div_Table" class="rectanguloRedondeado">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lbl_Project" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Project: " Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_ProjectName" runat="server" Font-Names="helvetica" Font-Size="24pt" Text="ProjectName" Visible="False"></asp:Label>
                                    <table class="auto-style38">
                                        <tr>
                                            <td class="auto-style49">
                                                <asp:Label ID="lbl_err_table" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_err_table" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style50">
                                                <asp:GridView ID="gview1" runat="server" BorderWidth="0px" CellPadding="12" Font-Names="helvetica" Font-Size="14pt" HorizontalAlign="Center" Width="500px">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cboxGV" runat="server" AutoPostBack="true" OnCheckedChanged="cboxGV_CheckedChanged" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                    <td class="auto-style47"></td>
                    <td class="auto-style44"></td>
                </tr>
                <tr>
                    <td class="auto-style17"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style22"></td>
                    <td class="auto-style33"></td>
                    <td class="auto-style22"></td>
                    <td class="auto-style33"></td>
                    <td class="auto-style19"></td>
                </tr>
                <tr>
                    <td class="auto-style25"></td>
                    <td class="auto-style26">
                        <div id="div_ChangeVariable" class="auto-style42">
                            <asp:Panel ID="panelChangeVariable" runat="server" DefaultButton="btn_ChangeVar">
                                <asp:Label ID="lbl_ChangeVariable" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Change Variable Value" Visible="False"></asp:Label>
                                <table class="auto-style10">
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lbl_err_ChangeVar" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_err_ChangeVar" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style29">
                                            <asp:DropDownList ID="ddList_ChangeVar" runat="server" Height="30px" Width="215px" Font-Names="helvetica" Font-Size="14pt" Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style30">
                                            <asp:TextBox ID="txtIn_ChangeVar" runat="server" Height="28px" Width="215px" Font-Names="helvetica" Font-Size="14pt" Visible="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_ChangeVar" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Names="helvetica" Height="32px" Text="Change" Width="70px" Visible="False" OnClick="btn_ChangeVar_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                    <td class="auto-style27"></td>
                    <td class="auto-style35">
                        <div id="div_ChangeData" class="auto-style43">
                            <asp:Panel ID="panelChangeAmount" runat="server" DefaultButton="btn_ChangeData">
                                <asp:Label ID="lbl_ChangeData" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Change Data Amount" Visible="False"></asp:Label>
                                <table class="auto-style10">
                                    <tr>
                                        <td class="auto-style37">
                                            <asp:Label ID="lbl_err_ChangeData" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_err_ChangeData" Visible="False"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style37">
                                            <asp:TextBox ID="txtIn_ChangeData" runat="server" Height="28px" Width="398px" Font-Names="helvetica" Font-Size="14pt" Visible="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_ChangeData" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Names="helvetica" Height="32px" Text="Change" Width="70px" Visible="False" OnClick="btn_ChangeData_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                    <td class="auto-style27"></td>
                    <td class="auto-style35">
                        <div id="div_Options" class="auto-style43">
                            <asp:Label ID="lbl_Options" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Options" Visible="False"></asp:Label>
                            <table class="auto-style10">
                                <tr>
                                    <td class="auto-style14" colspan="4">
                                        <asp:Label ID="lbl_err_Options" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_err_Options" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style39">
                                        <asp:Label ID="lbl_Language" runat="server" Font-Names="helvetica" Text="Language" Visible="False"></asp:Label>
                                    </td>
                                    <td class="auto-style40">
                                        <asp:DropDownList ID="ddlist_lang" runat="server" Font-Names="helvetica" Font-Size="14pt" Height="30px" Visible="False" Width="102px" AutoPostBack="True" OnSelectedIndexChanged="ddlist_lang_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style41">
                                        <asp:Label ID="lbl_Theme" runat="server" Font-Names="helvetica" Text="Theme" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlist_theme" runat="server" Font-Names="helvetica" Font-Size="14pt" Height="30px" Visible="False" Width="115px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td class="auto-style28"></td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style24">&nbsp;</td>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style24">&nbsp;</td>
                    <td class="auto-style36">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
