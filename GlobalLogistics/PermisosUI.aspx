<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermisosUI.aspx.cs" Inherits="GlobalLogistics.Permisos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
        .wrapper {
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            grid-gap: 10px;
            grid-auto-rows: minmax(100px, auto);
        }
        .three {
            grid-column: 1;
            grid-row: 1 / 2;
        }
        .five {
            grid-column: 2;
            grid-row: 1/2;
        }
   </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Permisos</h1><br/>
        </div> 
        <div class="wrapper">
            <div class="three">
                Seleccione una familia:
                <asp:GridView CssClass="mGrid" ID="grdFamilia" runat="server" AutoGenerateDeleteButton="True" AutoGenerateSelectButton="True" OnRowDeleted="grdFamilia_RowDeleted" OnSelectedIndexChanged="grdFamilia_SelectedIndexChanged">
                </asp:GridView>
            </div> 
            <div class="five">
                Patentes de la familia seleccionada:
                <asp:GridView ID="grdPatFam" runat="server" CssClass="mGrid">
                </asp:GridView>
            </div>
        </div>
        <p>
            <asp:Button ID="btnBorrarSeleccion" class="Buttons" runat="server" OnClick="btnBorrarSeleccion_Click" Text="Borrar Seleccion" />            
        </p>
           Seleccione una patente para agregar a la familia seleccionada:<br />
        <asp:GridView ID="grdPermisos" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdPermisos_SelectedIndexChanged" CssClass="mGrid">
        </asp:GridView>
        <asp:Button ID="btnAgregarAFamilia" class="Buttons" runat="server" OnClick="btnAgregarAFamilia_Click" style="margin-bottom: 0px" Text="Agregar a familia" />
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
            <asp:Button ID="btnGuardar" class="Buttons" runat="server" OnClick="btnGuardar_Click" Text="Guardar Patente" />
            <asp:Button ID="btnCrearFamilia" class="Buttons" runat="server" OnClick="btnCrearFamilia_Click" Text="Crear Familia" />
            <asp:Button ID="btnVolver" class="Buttons" runat="server" OnClick="btnVolver_Click" Text="Volver" />
        </p>
        <br />
       
        <p>
        <asp:Button ID="gtnGuardarFamilia" class="Buttons" runat="server" OnClick="gtnGuardarFamilia_Click" Text="Guardar Familia" />
        </p>
    </form>
</body>
</html>
