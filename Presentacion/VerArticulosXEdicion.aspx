
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerArticulosXEdicion.aspx.cs" Inherits="Presentacion.VerArticulosXEdicion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ver Atriculos por Edicion</title>
    <style>
        h1
        {
            line-height: 70px;
            background-color: #225D5B;
            text-align: center;
            border: 3px solid;
        }
        span
        {
            width: 150px;
            float: left;
        }
        body
        {
            background-color: #FFFFFF;
        }
        .derecha
        {
            margin-left: 150px;
        }
    </style>
</head>
<body bgcolor="#666666">
    <form id="form1" runat="server">
    <div style="background-color: #FFFFFF">
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
        <br />
        <br />
        <asp:Label ID="lblEdicion" runat="server" Text="Edición: "></asp:Label>
        <asp:DropDownList ID="ddlEdicion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEdicion_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblArticulos" runat="server" Text="Artículos: "></asp:Label>
        <br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <br />
        <asp:gridview CssClass="derecha" ID="grdArticulos" runat="server" 
            AutoPostBack="True" 
            OnSelectedIndexChanged="ddlEdicion_SelectedIndexChanged">
        </asp:gridview>
        <br />
        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>


