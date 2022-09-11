<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackupRestore.aspx.cs" Inherits="GlobalLogistics.BackupRestore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .Buttons{
             background-color: #1199EE;
             border:none;
             color:white;
             box-shadow:2px 2px 30px #000;
             border-radius:5px;
        }

        .TextBox{
            border-block-color: white;
            background-color: RGBA(255,255,255,0.3);
        }

        .Labels{
            color:aliceblue;
        }
    </style>
</head>
<body style="background-image:url(https://i.ibb.co/x5XKGvY/servidor-web.jpg); font-family:Arial;";>
    <form id="form1" runat="server">
        <div class="Labels">
            <b>BACKUP:</b><br />
            <br />
            &nbsp;Nbre Archivo:&nbsp;&nbsp;<asp:TextBox CssClass="TextBox" ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;Volumen:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox CssClass="TextBox" ID="txtVolumenes" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>
        &nbsp;
        <asp:Label class="Labels" ID="Label2" runat="server" Text="Ruta:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox CssClass="TextBox" ID="txtRuta" runat="server" Width="411px"></asp:TextBox>
        <br />
        <br />
        <asp:Button class="Buttons" ID="btnGenerar" runat="server" OnClick="btnGenerar_Click" Text="Generar" Height="32px" Width="105px" />
        <br />
        <p class="Labels">
            <b>RESTORE:</b></p>
        <p class="Labels">
            &nbsp;
            Nbre Archivo:&nbsp;&nbsp; <asp:TextBox CssClass="TextBox" ID="txtNombreRestore" runat="server"></asp:TextBox>
        </p>
        <p class="Labels">
            &nbsp; Volumen:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox CssClass="TextBox" ID="txtVolumenesRestore" runat="server"></asp:TextBox>
        </p>
        <p class="Labels">
            &nbsp;
            Ruta:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox CssClass="TextBox" ID="txtRutaRestore" runat="server" Width="411px"></asp:TextBox>
        </p>
        <p>
            <asp:Button class="Buttons" ID="btnRestore" runat="server" OnClick="btnRestore_Click" Text="Restore" Height="32px" Width="111px" />
        </p>
    </form>
</body>
</html>
