<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoPeriodistas.aspx.cs" Inherits="MantenimientoPeriodistas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            width: 216px;
        }
        .style4
        {
            width: 216px;
            height: 23px;
        }
        .style5
        {
            height: 23px;
        }
        .style7
        {
            width: 216px;
            height: 30px;
        }
        .style8
        {
            height: 30px;
        }
        .style9
        {
            width: 208px;
            height: 30px;
        }
        .style10
        {
            width: 208px;
            height: 23px;
        }
        .style11
        {
            width: 208px;
        }
    </style>
</head>
<body bgcolor="#ff9933">
    <form id="form1" runat="server">
    <div align="center">
    
        MANTENIMIENTO PERIODISTA<br />
        <br />
        <table align="center" style="width: 79%;">
            <tr>
                <td class="style9">
                    Codigo Periodista:</td>
                <td class="style7">
                    <asp:TextBox ID="txtCodigoPeriodista" runat="server" Width="203px"></asp:TextBox>
                </td>
                <td class="style8">
                    <asp:Button ID="btnBuscar" runat="server" Text="buscar" 
                        onclick="btnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td class="style10">
                    Nombre:</td>
                <td class="style4">
                    <asp:TextBox ID="txtNombre" runat="server" Width="203px"></asp:TextBox>
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td class="style11">
                    Apellido:</td>
                <td class="style2">
                    <asp:TextBox ID="txtApellido" runat="server" Width="203px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    Mail:</td>
                <td class="style2">
                    <asp:TextBox ID="txtMail" runat="server" Width="203px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnLimpiar" runat="server" onclick="Button1_Click" 
                        Text="Limpiar" />
                </td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                        onclick="btnModificar_Click" />
                </td>
                <td class="style2">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                        onclick="btnEliminar_Click" />
                </td>
                <td>
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                        onclick="btnAgregar_Click" />
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    <div align="center">
        <asp:HyperLink ID="Volver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
    </div>
    </form>
</body>
</html>
