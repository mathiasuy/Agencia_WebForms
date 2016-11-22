<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ediciones.aspx.cs" Inherits="SegundoObligatorio.Ediciones" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
        }
    </style>
</head>
<body bgcolor="#999999">
    <form id="form1" runat="server">
    <div align="center">
        <h3 class="style1">Ediciones</h3>

        <table>
            <tr>
                <td>Número:</td><td><asp:TextBox ID="txtNumero" runat="server" Width="228px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="vertical-align: top">Fecha de publicación:</td>
                <td><asp:Calendar ID="calFechaPublicacion" runat="server"></asp:Calendar></td>
            </tr>
            <tr>
                <td style="vertical-align: top">Artículos:</td>
                <td>
                    <asp:DropDownList ID="ddlArticulo" runat="server" Height="22px" Width="367px">
                    </asp:DropDownList>
                    <asp:Button ID="btnAgregarArticulo" runat="server" Text="+" onclick="btnAgregarArticulo_Click" /> 
                    <asp:Button ID="btnQuitarArticulo" runat="server" Text="-" 
                        onclick="btnQuitarArticulo_Click" Width="22px" /><br /><br />

                    <asp:ListBox ID="lstArticulos" runat="server" Height="245px" Width="497px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td colspan="2"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click" /> &nbsp;<asp:Button ID="btnDarAlta" runat="server" Text="Dar de Alta" onclick="btnDarAlta_Click" /> &nbsp;<asp:Button ID="btnDarBaja" runat="server" Text="Dar de Baja" onclick="btnDarBaja_Click" /> &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" onclick="btnModificar_Click" /> &nbsp;<asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" /></td>
            </tr>
        </table>
        
        <p><asp:Label ID="lblMensaje" runat="server"></asp:Label></p>
        <p><asp:LinkButton ID="lnkVolver" PostBackUrl="~/Default.aspx" runat="server">Volver...</asp:LinkButton></p>
    </div>
    </form>
</body>
</html>
