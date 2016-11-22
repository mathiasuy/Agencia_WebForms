<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeriodistasIndependientes.aspx.cs" Inherits="Presentacion.PeriodistasIndependientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#999999">
    <form id="form1" runat="server">
    <div>
    
        <table class="style1" align="center">
            <tr>
                <td class="style3">
                    <br />
                </td>
                <td class="style4" colspan="2">
                    <strong>Periodistas</strong></td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    Id:</td>
                <td colspan="2">
                    <asp:TextBox ID="txtId" runat="server" Width="301px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Nombre</td>
                <td colspan="2">
                    <asp:TextBox ID="txtNombre" runat="server" Width="301px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Documento</td>
                <td colspan="2">
                    <asp:TextBox ID="txtDocumento" runat="server" Width="301px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Direccion</td>
                <td colspan="2">
                    <asp:TextBox ID="txtDireccion" runat="server" Width="301px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Teléfono</td>
                <td colspan="2">
                    <asp:TextBox ID="txtTelefono" runat="server" Width="301px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:LinkButton ID="lnkVolver" runat="server" PostBackUrl="~/Default.aspx">Volver </asp:LinkButton>
                </td>
                <td class="style2">
                    <br />
                    <asp:Button ID="btnAlta" runat="server" onclick="btnAlta_Click" Text="Alta" />
&nbsp;
                    <asp:Button ID="btnBaja" runat="server" onclick="btnBaja_Click" Text="Baja" />
&nbsp;
                    <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                        Text="Modificar" />
&nbsp;
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" />
&nbsp;
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                        Text="Limpiar" />
                    <br />
                    <asp:Label ID="lbl" runat="server" style="color: #999999"></asp:Label>
                    <br />
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
