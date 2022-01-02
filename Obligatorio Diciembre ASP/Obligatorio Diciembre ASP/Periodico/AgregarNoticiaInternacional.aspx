
    <style type="text/css">
        .style3
        {
            width: 233px;
        }
        .style7
        {
            width: 233px;
            height: 23px;
        }
        .style10
        {
            width: 233px;
            height: 42px;
        }
        .style13
        {
            width: 166px;
            height: 23px;
        }
        .style14
        {
            width: 166px;
        }
        .style15
        {
            width: 166px;
            height: 42px;
        }
        .style16
        {
            width: 77px;
            height: 23px;
        }
        .style18
        {
            width: 77px;
            height: 42px;
        }
        .style19
        {
            width: 77px;
        }
    </style>
</head>
    <body bgcolor="#99ccff">
<form id="form1" runat="server">
<div align="center">
    AGREGAR NOTICIA INTERNACIONAL<br />
    <br />
    <table style="width: 57%;">
        <tr>
            <td class="style7">
                TITULO:</td>
            <td class="style13">
                <asp:TextBox ID="txtTitulo" runat="server" Height="19px" Width="167px"></asp:TextBox>
            </td>
            <td class="style16">
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style3">
                RESUMEN</td>
            <td class="style14">
                <asp:TextBox ID="txtResumen" runat="server" Height="64px" Width="167px" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="style19">
                <br />
            </td>
        </tr>
        <tr>
            <td class="style7">
                CONTENIDO</td>
            <td class="style13">
                <asp:TextBox ID="txtContenido" runat="server" Height="89px" Width="167px" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="style16">
                <br />
            </td>
        </tr>
        <tr>
            <td class="style3">
                FECHA</td>
            <td class="style14">
                <asp:TextBox ID="txtFecha" runat="server" Height="17px" 
                    Width="167px"></asp:TextBox>
            </td>
            <td class="style19">
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style3">
                PAIS</td>
            <td class="style14">
                <asp:TextBox ID="txtPais" runat="server" Height="19px" Width="167px"></asp:TextBox>
            </td>
            <td class="style19">
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style10">
                CODIGO PERIODISTA</td>
            <td class="style15">
                <asp:TextBox ID="txtCodigoPeriodista" runat="server" Height="19px" 
                    Width="167px"></asp:TextBox>
            </td>
            <td class="style18">
                <br />
                <br />
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Noticia" />
    <br />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
</div>
</form>
