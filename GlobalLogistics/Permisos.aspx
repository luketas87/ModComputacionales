<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permisos.aspx.cs" Inherits="GlobalLogistics.Permisos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Permisos<br />
            <br />
        </div>
        <asp:GridView ID="grdPermisos" runat="server">
        </asp:GridView>
        <p>
            Agregar Permiso</p>
        <p>
            Permiso<asp:DropDownList ID="ddlPermisos" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            Nombre<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
        </p>
    </form>
</body>
</html>
