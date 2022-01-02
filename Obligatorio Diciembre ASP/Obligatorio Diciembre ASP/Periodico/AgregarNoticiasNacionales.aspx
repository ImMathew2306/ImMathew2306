<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgregarNoticiasNacionales.aspx.cs" Inherits="AgregarNoticiasNacionales" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 23px;
            width: 77px;
        }
        .style2
        {
            height: 23px;
            width: 199px;
        }
        .style3
        {
            width: 199px;
        }
        .style4
        {
            height: 23px;
            width: 650px;
        }
        .style5
        {
            width: 650px;
        }
        .style6
        {
            width: 77px;
        }
    </style>
</head>
<body bgcolor="#ccff99">
    <form id="form1" runat="server">
    <div align="center">
    
        &nbsp;&nbsp; AGREGAR NOTICIA NACIONAL<br />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    <br />
                    TITULO:<br />
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtTitulo" runat="server" Width="304px"></asp:TextBox>
                </td>
                <td class="style1">
                </td>
            </tr>
            <tr>
                <td class="style3">
                    RESUMEN:</td>
                <td class="style5">
                    <asp:TextBox ID="txtResumen" runat="server" ForeColor="#CC0099" Height="81px" 
                        TextMode="MultiLine" Width="304px"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    CONTENIDO:</td>
                <td class="style5">
                    <asp:TextBox ID="txtContenido" runat="server" Height="81px" TextMode="MultiLine" 
                        Width="304px"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <br />
                    FECHA:<br />
                </td>
                <td class="style5">
                    <asp:Calendar ID="Calnoticias" runat="server" BackColor="White" 
                        BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" 
                        Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" 
                        SelectedDate="12/04/2021 23:03:23" Width="330px">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                            Height="8pt" />
                        <DayStyle BackColor="#CCCCCC" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" 
                            Font-Size="12pt" ForeColor="White" Height="12pt" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <br />
                    SECCION:<br />
                </td>
                <td class="style5">
                    <asp:DropDownList ID="ddlSecciones" runat="server" 
                        >
                    </asp:DropDownList>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <br />
                    CODIGO<br />
                    PERIODISTA<br />
                </td>
                <td class="style5">
                    <asp:DropDownList ID="ddlPeriodistas" runat="server" 
                        >
                    </asp:DropDownList>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    <br />
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Noticia" 
                        Width="133px" onclick="btnAgregar_Click" />
                    <br />
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
