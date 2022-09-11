<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMProducto.aspx.cs" Inherits="GlobalLogistics.ABMProducto" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <style>
         .Buttons{
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #1199EE;
            color:white;
            box-shadow:2px 2px 30px #000;
            border-radius:5px;
            margin-top: 0px;
            height: 30px;
            width: 100px;
        }

        #btnAgregar:hover{
            background-color: #117bee;
            cursor:pointer;
        }                   
        
        #btnModificar:hover{
            background-color: #117bee;
            cursor:pointer;
        }
      
        #btnEliminar:hover{
            background-color: #117bee;
            cursor:pointer;
        }

         .TextBox{
            border-block-color: white;
            background-color: RGBA(255,255,255,0.3);
        }
         
.mGrid {
    width: 100%;
    background-color: #fff;
    margin: 5px 0 10px 0;
    border: solid 1px #525252;
    border-collapse: collapse;
}

    .mGrid td {
        padding: 2px;
        border: solid 1px #c1c1c1;
        color: #717171;
    }

    .mGrid th {
        padding: 4px 2px;
        color: #fff;
        background: #424242 url(grd_head.png) repeat-x top;
        border-left: solid 1px #525252;
        font-size: 0.9em;
    }

    .mGrid .alt {
        background: #fcfcfc url(grd_alt.png) repeat-x top;
    }

    .mGrid .pgr {
        background: #424242 url(grd_pgr.png) repeat-x top;
    }

        .mGrid .pgr table {
            margin: 5px 0;
        }

        .mGrid .pgr td {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }

        .mGrid .pgr a {
            color: #666;
            text-decoration: none;
        }

        .mGrid .pgr a:hover {
             color: #000;
             text-decoration: none;
        }
        .Labels{
            color:aliceblue;
            font-family:Arial;
            font-size:35px;
        }
    </style>
<body style="background-image:url(https://negociosyempresa.com/wp-content/uploads/2021/11/caja-registradora-tpv.jpg)";>
    <form id="form2" runat="server">
        <div>
            
            <asp:Label ID="Label1" runat="server" Text="Administracion de Productos" CssClass="Labels"></asp:Label>
            
            <br />
        <asp:GridView ID="grdProductos" 
            runat="server" AutoGenerateSelectButton="True" 
            OnSelectedIndexChanged="grdProductos_SelectedIndexChanged" CssClass="mGrid">
        </asp:GridView>
        </div>
        <asp:TextBox class="TextBox" ID="TextBox1" runat="server" Width="249px" Height="25px" style="margin-top: 0px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button class="Buttons" ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
        &nbsp;&nbsp;
        <asp:Button class="Buttons" ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
        &nbsp;&nbsp;
        <asp:Button class="Buttons" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
    </form>
</body>
</html>

