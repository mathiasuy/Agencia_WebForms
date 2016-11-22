<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 658px;
            width: 685px;
            margin-bottom: 0px;
            background-color: #000000;
        }
        .style4
        {
            text-align: center;
        }
        .style5
        {
            background-color: #000000;
        }
    </style>
</head>
<body bgcolor="#666666">
    <form id="form1" runat="server">
    <div class="style4" style="height: 878px" align="center">
    
        <table align="center" cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td class="style4">
                    <asp:Image ID="Image1" runat="server" Height="596px" 
                        ImageUrl="~/Imagenes/Portada.png" Width="710px" />
                    <br />
                    <br />
        <asp:Button ID="btnVerArticulosXFuente" runat="server" BackColor="Black" 
            ForeColor="White" Height="28px" 
            PostBackUrl="~/VerArticulosXFuente.aspx" Text="VerArticulosXFuente" 
            Width="184px" CssClass="style5" />
        <asp:Button ID="btnVerArticulosXEdicion" runat="server" BackColor="Black" 
            ForeColor="White" Height="28px"  
            PostBackUrl="~/VerArticulosXEdicion.aspx" Text="VerArticulosXEdicion" 
            Width="184px" CssClass="style5" />
        <asp:Button ID="btnVerFuentesXEdicion" runat="server" BackColor="Black" 
            ForeColor="White" Height="28px" 
            PostBackUrl="~/VerFuentesXEdicion.aspx" Text="VerFuentesXEdicion" 
            Width="184px" CssClass="style5" />
                    <br />
                    <br />
        <asp:Button ID="btnPeriodistas" runat="server" BackColor="Black" 
            ForeColor="White" Height="28px" 
            PostBackUrl="~/PeriodistasIndependientes.aspx" Text="Periodistas" 
            Width="97px" CssClass="style5" />
        <asp:Button ID="btnAgencias" runat="server" BackColor="Black" 
            ForeColor="White" Height="28px" 
            PostBackUrl="~/Agencias.aspx" Text="Agencias" Width="97px" CssClass="style5" />
                    <br />
        <asp:Button ID="btnArticulos" runat="server" BackColor="Black" 
            ForeColor="White" Height="28px" 
            PostBackUrl="~/Articulos.aspx" Text="Articulos" Width="97px" CssClass="style5" />
        <asp:Button ID="btnEdicion" runat="server" BackColor="Black" 
            ForeColor="White" Height="28px" 
            PostBackUrl="~/Ediciones.aspx" Text="Ediciones" Width="97px" CssClass="style5" />
                    <br />
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" style="color: #FFFFFF"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
