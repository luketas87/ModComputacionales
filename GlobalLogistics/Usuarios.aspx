﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="GlobalLogistics.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Usuarios<br />
        </div>
        <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdUsuarios_SelectedIndexChanged">
        </asp:GridView>
        <p>
            Nombre<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </p>
        <p>
            Email<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" /> &nbsp; &nbsp;<asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
        <br />
        <br />
        Patentes<asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
    </form>
</body>
</html>
