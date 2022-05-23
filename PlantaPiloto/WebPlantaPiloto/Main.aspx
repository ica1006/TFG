<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebPlantaPiloto.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        
        .auto-style7 {
            height: 147px;
            width: 530px;
        }

        .rectanguloRedondeado {
            border-radius: 25px;
            background: #F7F7F7;
            padding: 20px;
            color: #333333;
        }

        .rectanguloRedondeadoOscuro {
            border-radius: 25px;
            background: #515151;
            padding: 20px;
            color: #C4C2C2;
        }

        .auto-style10 {
            width: 93%;
        }

        .auto-style11 {
            width: 440px;
        }

        .auto-style14 {
            height: 23px;
        }

        .auto-style16 {
            height: 26px;
            width: 152px;
        }

        .blankCell {
            height: 100%;
            width: 100%;
        }

        .auto-style29 {
            width: 236px;
        }

        .auto-style30 {
            width: 249px;
        }

        .auto-style35 {
            height: 146px;
            width: 554px;
        }

        .auto-style37 {
            width: 432px;
        }

        .auto-style38 {
            width: 80%;
            height: 100%;
            margin: 0 auto;
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

        .auto-style46 {
            height: 438px;
            width: 530px;
        }

        .auto-style49 {
            height: 23px;
            width: 533px;
        }

        .auto-style50 {
            width: 533px;
        }

        .auto-style52 {
            width: 71%;
        }
        .auto-style53 {
            border-radius: 25px;
            background: #F7F7F7;
            padding: 20px;
            height: 104px;
            width: 400px;
        }
        .auto-style54 {
            height: 100%;
            width: 530px;
        }
        .auto-style56 {
            width: 80%;
        }
        .auto-style58 {
            width: 75%;
        }
        .auto-style59 {
            height: 146px;
            width: 530px;
        }
        .auto-style60 {
            width: 96%;
        }
        .auto-style61 {
            height: 26px;
            width: 227px;
        }
        </style>
</head>
<body  runat="server" id="bodyTag">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table class="auto-style38">
                <tr>
                    <td class="auto-style54">
                        <asp:Label ID="lbl_err_ConString" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_err_ConString" Visible="False"></asp:Label>
                    </td>
                    <td class="blankCell"></td>
                    <td class="blankCell"></td>
                    <td class="blankCell"></td>
                    <td class="blankCell"></td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <div id="div_ConnString" class="rectanguloRedondeado" runat="server" >
                            <asp:Panel ID="panelConnectionString" runat="server" DefaultButton="btn_ConnString" Width="530px">
                                <asp:Label ID="lbl_ConString" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Data Base - Connection String"></asp:Label>
                                <table class="auto-style56">
                                    <tr>
                                        <td class="auto-style11">
                                            <asp:TextBox ID="txtIn_ConnString" runat="server" Font-Names="helvetica" Font-Size="14pt" Height="28px" Width="424px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_ConnString" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Names="helvetica" Height="32px" Text="Connect" Width="70px" OnClick="btn_ConnString_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <table class="auto-style60">
                                    <tr>
                                        <td class="auto-style61">
                                            <asp:Label ID="lbl_Connection" runat="server" Font-Names="helvetica" Font-Size="10pt" Text="Data Base connected: " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lbl_ConnectionStatus" runat="server" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="false" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td class="auto-style16">
                                            <asp:LinkButton ID="linkButtonFullDB" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" OnClick="hlink_fulldb_DataBinding" Visible="False" ForeColor="#009FFF">View Full db</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                    <td class="blankCell"></td>
                    <td colspan="3" rowspan="3" class="blankCell">
                        <div id="div_Chart" class="rectanguloRedondeado" runat="server">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Timer ID="Timer1" runat="server" OnTick="LoadChart" Interval="1000" />
                                    <asp:Chart ID="chart_Var" runat="server" BackColor="Transparent" Height="550px" Width="1200px">
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
                </tr>
                <tr>
                    <td class="auto-style54"></td>
                    <td class="blankCell"></td>
                </tr>
                <tr>
                    <td class="auto-style46">
                        <div id="div_Table" class="rectanguloRedondeado" runat="server">
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
                    <td class="blankCell"></td>
                </tr>
                <tr>
                    <td class="blankCell"></td>
                    <td class="blankCell"></td>
                    <td class="blankCell"></td>
                    <td class="blankCell"></td>
                    <td class="blankCell"></td>
                </tr>
                <tr>
                    <td class="auto-style59">
                        <div id="div_ChangeVariable" class="auto-style42" runat="server">
                            <asp:Panel ID="panelChangeVariable" runat="server" DefaultButton="btn_ChangeVar">
                                <asp:Label ID="lbl_ChangeVariable" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Change Variable Value" Visible="False"></asp:Label>
                                <table class="auto-style58">
                                    <tr>
                                        <td colspan="3" class="auto-style14">
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
                    <td class="blankCell"></td>
                    <td class="auto-style35">
                        <div id="div_ChangeData" class="auto-style53" runat="server">
                            <asp:Panel ID="panelChangeAmount" runat="server" DefaultButton="btn_ChangeData" Width="500px">
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
                                            <asp:TextBox ID="txtIn_ChangeData" runat="server" Height="28px" Width="302px" Font-Names="helvetica" Font-Size="14pt" Visible="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_ChangeData" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Names="helvetica" Height="32px" Text="Change" Width="70px" Visible="False" OnClick="btn_ChangeData_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                    <td class="blankCell"></td>
                    <td class="auto-style35">
                        <div id="div_Options" class="auto-style53" runat="server">
                            <asp:Label ID="lbl_Options" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Options" Visible="False"></asp:Label>
                            <table class="auto-style10">
                                <tr>
                                    <td class="auto-style37" colspan="4">
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
                                        <asp:DropDownList ID="ddlist_theme" runat="server" Font-Names="helvetica" Font-Size="14pt" Height="30px" Visible="False" Width="115px" AutoPostBack="True" OnSelectedIndexChanged="ddlist_theme_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style54">&nbsp;</td>
                    <td class="blankCell">&nbsp;</td>
                    <td class="blankCell">&nbsp;</td>
                    <td class="blankCell">&nbsp;</td>
                    <td class="blankCell">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
