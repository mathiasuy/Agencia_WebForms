<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="SegundoObligatorio.Articulos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#999999">
    <form id="form1" runat="server">
    <div>
        <h3>Artículos</h3>

        <table>
            <tr>
                <td>Id:</td><td><asp:TextBox ID="txtId" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Fuente:</td>
                <td>
                    <asp:DropDownList ID="ddlFuente" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Sección:</td><td><asp:TextBox ID="txtSeccion" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Imagen ilustrativa:</td><td><asp:CheckBox ID="chkImagenIlustrativa" runat="server" /></td>
            </tr>
            <tr>
                <td>Costo:</td><td><asp:TextBox ID="txtCosto" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="vertical-align: top;">Contenido:</td><td>
                <asp:TextBox ID="txtContenido" TextMode="MultiLine" runat="server" 
                    Height="284px" Width="918px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click" /> <asp:Button ID="btnDarAlta" runat="server" Text="Dar de Alta" onclick="btnDarAlta_Click" /> <asp:Button ID="btnDarBaja" runat="server" Text="Dar de Baja" onclick="btnDarBaja_Click" /> <asp:Button ID="btnModificar" runat="server" Text="Modificar" onclick="btnModificar_Click" /> <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" /></td>
            </tr>
        </table>
        
        <p><asp:Label ID="lblMensaje" runat="server"></asp:Label></p>
        <p><asp:LinkButton ID="lnkVolver" PostBackUrl="~/Default.aspx" runat="server">Volver...</asp:LinkButton></p>
    </div>
    </form>
</body>
</html>
