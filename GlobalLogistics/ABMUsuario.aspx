<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMUsuario.aspx.cs" Inherits="GlobalLogistics.ABMUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="Label2" runat="server" Text="Contrasenia"></asp:Label>
        <asp:TextBox ID="txtContrasenia" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click" Text="Crear" />
        </p>
    </form>
</body>
</html>
