<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoNoticias.aspx.cs" Inherits="ListadoNoticias" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#99ccff">
    <form id="form1" runat="server">
    <div align="center">
    
        LISTAR NOTICIAS<br />
        <br />
        Seleccione un tipo de noticia<br />
        <br />
        <asp:DropDownList ID="ddlListadoNoticias" runat="server" 
            ondatabound="ddlListadoNoticias_SelectedIndexChanged" 
            onselectedindexchanged="ddlListadoNoticias_SelectedIndexChanged" 
            AutoPostBack="True" >
            <asp:ListItem>--------------------------</asp:ListItem>
            <asp:ListItem>Todas las Noticias</asp:ListItem>
            <asp:ListItem>Solo Nacionales</asp:ListItem>
            <asp:ListItem>Solo Internacionales</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblError" runat="server" Text="Error"></asp:Label>
        <br />
        <br />
        <asp:ListBox ID="LbNoticias" runat="server" Height="248px" Width="627px">
        </asp:ListBox>
        <br />
    
    </div>
    <div style="text-align: center">
        <asp:HyperLink ID="Volver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
    </div>
    </form>
</body>
</html>
