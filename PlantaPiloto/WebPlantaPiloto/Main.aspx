<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebPlantaPiloto.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>WebApp Planta Piloto</title>
    <style type="text/css">
        
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

        .rectanguloBlanco {
            background: white;
        }

        .blankCell {
            width: 25px;
            height: 25px;
        }
        
        html, body{
            margin: 0;
        }
        </style>
</head>
<body  runat="server" id="bodyTag">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="height:100vh;">
            <table style="width: 95%; height: 100vh; margin:0 auto;" aria-describedby="Main table">
                <tr>
                            <th scope="col"></th>
                </tr>

                <tr>
                    <td class="blankCell" colspan="5">
                        <asp:Label ID="lbl_err_ConString" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_err_ConString" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr style="vertical-align:central;">
                    <td style="width:530px;">
                        <div id="div_ConnString" class="rectanguloRedondeado" runat="server" >
                            <asp:Panel ID="panelConnectionString" runat="server" DefaultButton="btn_ConnString" Width="530px">
                                <asp:Label ID="lbl_ConString" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Data Base - Connection String"></asp:Label>
                                <table aria-describedby="DB Con String table">
                                    <tr>
                                        <th scope="col"></th>
                                    </tr>

                                    <tr>
                                        <td style="width:440px;" >
                                            <asp:TextBox ID="txtIn_ConnString" runat="server" Font-Names="helvetica" Font-Size="14pt" Height="28px" Width="424px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_ConnString" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Names="helvetica" Height="32px" Text="Connect" Width="70px" OnClick="btn_ConnString_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <table aria-describedby="DB Status">
                                    <tr>
                                        <th scope="col"></th>
                                    </tr>

                                    <tr>
                                        <td style="width: 440px; height:26px;" >
                                            <asp:Label ID="lbl_Connection" runat="server" Font-Names="helvetica" Font-Size="10pt" Text="Data Base connected: " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lbl_ConnectionStatus" runat="server" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="false" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td style="height: 26px; width:152px; text-align:left; margin-left:100%;" >
                                            <asp:LinkButton ID="linkButtonFullDB" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" OnClick="hlink_fulldb_DataBinding" Visible="False" ForeColor="#009FFF">View Full db</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                    <td class="blankCell"></td>
                    <td colspan="3" rowspan="2" style="vertical-align:central; text-align:center;">
                        <div id="div_Chart" class="rectanguloRedondeado" runat="server" >

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Timer ID="Timer1" runat="server" OnTick="loadExtraCharts" Interval="2007" />
                                    <asp:Chart ID="chart_Var" runat="server" BackColor="Transparent" Height="630px" Width="1000px">
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
                    <td style="width:530px; vertical-align: central;" >
                        <div id="div_Table" class="rectanguloRedondeado" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lbl_Project" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Project: " Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_ProjectName" runat="server" Font-Names="helvetica" Font-Size="24pt" Text="ProjectName" Visible="False"></asp:Label>
                                    <table style="width: 80%; height: 100%; margin: 0 auto;" aria-describedby="Project table">
                                        <tr>
                                            <th scope="col"></th>
                                        </tr>
                                        <tr>
                                            <td style="height: 23px; width: 533px;" >
                                                <asp:Label ID="lbl_err_table" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_err_table" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 533px;" >
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
                <tr style="vertical-align:bottom;">
                    <td class="blankCell" style="width: 530px;">
                        &nbsp;</td>
                    <td class="blankCell">&nbsp;</td>
                    <td class="blankCell" style="width: 554px;">
                        &nbsp;</td>
                    <td class="blankCell">&nbsp;</td>
                    <td class="blankCell" style="width: 554px;">
                        &nbsp;</td>
                </tr>
                <tr style="vertical-align:bottom;">
                    <td style="width: 530px;">
                        <div id="div_ChangeVariable" class="rectanguloRedondeado" runat="server">
                            <asp:Panel ID="panelChangeVariable" runat="server" DefaultButton="btn_ChangeVar">
                                <asp:Label ID="lbl_ChangeVariable" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Change Variable Value" Visible="False"></asp:Label>
                                <table style="width: 75%" aria-describedby="ChangeVar table">
                                    <tr>
                                        <th scope="col"></th>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height:23px;" >
                                            <asp:Label ID="lbl_err_ChangeVar" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_err_ChangeVar" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:236px;" >
                                            <asp:DropDownList ID="ddList_ChangeVar" runat="server" Height="30px" Width="215px" Font-Names="helvetica" Font-Size="14pt" Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width:249px;" >
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
                    <td style="width: 400px;">
                        <div id="div_ChangeData" class="rectanguloRedondeado" runat="server">
                            <asp:Panel ID="panelChangeAmount" runat="server" DefaultButton="btn_ChangeData" Width="400px">
                                <asp:Label ID="lbl_ChangeData" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Change Data Amount" Visible="False"></asp:Label>
                                <table style="width:454px;" aria-describedby="Change Data table">
                                    <tr>
                                        <th scope="col"></th>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height:23px;">
                                            <asp:Label ID="lbl_err_ChangeData" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_err_ChangeData" Visible="False"></asp:Label>
                                        </td>
                                        <td style="height:23px;">&nbsp;</td>
                                        <td style="height:23px;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width:112px;">
                                            <asp:TextBox ID="txtIn_ChangeData" runat="server" Height="28px" Width="111px" Font-Names="helvetica" Font-Size="14pt" Visible="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_ChangeData" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Names="helvetica" Height="32px" OnClick="btn_ChangeData_Click" Text="Change" Visible="False" Width="70px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_ChartAmount" runat="server" Font-Names="helvetica" Font-Size="14pt" Text="Chart Amount" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddList_ChartAmount" runat="server" Font-Names="helvetica" Font-Size="14pt" Visible="False">
                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                    <td class="blankCell"></td>
                    <td style="width: 400px;">
                        <div id="div_Options" class="rectanguloRedondeado" runat="server">

                            <asp:Label ID="lbl_Options" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="24pt" Text="Options" Visible="False"></asp:Label>
                            <table style="width:400px;" aria-describedby="Options table">
                                <tr>
                                    <th scope="col"></th>
                                </tr>
                                <tr>
                                    <td style="width:400px; height:23px;" colspan="4">
                                        <asp:Label ID="lbl_err_Options" runat="server" Font-Bold="True" Font-Names="helvetica" Font-Size="10pt" ForeColor="Red" Text="lbl_err_Options" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height:30px;">
                                    <td style="width:86px;">
                                        <asp:Label ID="lbl_Language" runat="server" Font-Names="helvetica" Text="Language" Visible="False" Font-Size="14pt"></asp:Label>
                                    </td>
                                    <td style="width:121px;">
                                        <asp:DropDownList ID="ddlist_lang" runat="server" Font-Names="helvetica" Font-Size="14pt" Height="30px" Visible="False" Width="102px" AutoPostBack="True" OnSelectedIndexChanged="ddlist_lang_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width:71px;">
                                        <asp:Label ID="lbl_Theme" runat="server" Font-Names="helvetica" Text="Theme" Visible="False" Font-Size="14pt"></asp:Label>
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
                    <td class="blankCell" colspan="5">
                        &nbsp;</td>
                </tr>
                </table>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div id="div_ExtraCharts" class="rectanguloRedondeado" runat="server">
        <table style="width:100%;" aria-describedby="Extra chart table">
            <tr>
                <th scope="col"></th>
            </tr>
            <tr>
                <td>
                                    <asp:Chart ID="chart_T1" runat="server" BackColor="Transparent" Height="472px" Width="750px" Visible="False">
                                        <Series>
                                            <asp:Series Name="Series1" ChartArea="ChartArea1">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                    </td>
                <td>
                                    <asp:CheckBoxList ID="cblist_Chart1" runat="server" Visible="False" Font-Names="helvetica" Font-Size="14pt">
                                    </asp:CheckBoxList>
                                    </td>
                <td>
                    <asp:Chart ID="chart_T2" runat="server" BackColor="Transparent" Height="472px" Visible="False" Width="750px">
                        <Series>
                            <asp:Series ChartArea="ChartArea1" Name="Series1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    <asp:CheckBoxList ID="cblist_Chart2" runat="server" Visible="False" Font-Names="helvetica" Font-Size="14pt">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                                    <asp:Chart ID="chart_T3" runat="server" BackColor="Transparent" Height="472px" Width="750px" Visible="False">
                                        <Series>
                                            <asp:Series Name="Series1" ChartArea="ChartArea1">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                    </td>
                <td>
                                    <asp:CheckBoxList ID="cblist_Chart3" runat="server" Visible="False" Font-Names="helvetica" Font-Size="14pt">
                                    </asp:CheckBoxList>
                                    </td>
                <td>
                    <asp:Chart ID="chart_T4" runat="server" BackColor="Transparent" Height="472px" Visible="False" Width="750px">
                        <Series>
                            <asp:Series ChartArea="ChartArea1" Name="Series1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    <asp:CheckBoxList ID="cblist_Chart4" runat="server" Visible="False" Font-Names="helvetica" Font-Size="14pt">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
