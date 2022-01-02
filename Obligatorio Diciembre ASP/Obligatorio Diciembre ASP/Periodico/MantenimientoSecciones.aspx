<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoSecciones.aspx.cs" Inherits="MantenimientoSecciones" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 237px;
        }
        .style2
        {
            width: 352px;
        }
    </style>
</head>
<body bgcolor="#ccffcc">
    <form id="form1" runat="server">
    <div align="center">
    
        MANTENIMIENTO SECCIONES<br />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    <br />
                    CODIGO SECCION:<br />
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtCodeSec" runat="server" Width="308px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                        onclick="btnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <br />
                    NOMBRE SECCION:<br />
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtNombreSec" runat="server" Width="308px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                        Text="Limpiar" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <br />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                        onclick="btnModificar_Click" />
                    <br />
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
        </table>
    
    </div>
    <p style="text-align: center">
&nbsp;<asp:Label ID="lblError" runat="server" Text="Error"></asp:Label>
    </p>
    <div align="center">
        <asp:HyperLink ID="Volver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
    </div>
    </form>
</body>
</html>
