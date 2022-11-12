<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="GlobalLogistics.ListarUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
   
        body{
            font-family: 'roboto';
        }
        h1{
            text-align:center;
        }
        .blueTable,tr,th,td{border:1px solid #919191;
            margin:0 auto;
            text-align: center;
        };
        .blueTable{
            display: flex;
        }
        button{
            border:none;
            margin:10px;
            border-radius:10px;
            padding-left:30px;
            padding-right:30px;
            padding-top:10px;
            padding-bottom:10px;
            cursor:pointer;
        }
        button:hover{
            box-shadow: 5px 5px 3px 0px rgba(0,0,0,0.32);
        }
        #btnRead{
            background-color:aquamarine;
        }
        #btnUpdate{
            background-color:rgb(211, 163, 255);

        }
        #btnDelete{
            background-color:red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Listado de registros</h1>
        <table class="blueTable">
            <thead>
            <tr>
            <th>Opciones del administrador</th>
            <th>ID de usuario</th>
            <th>Nombre</th>
            <th>Edad</th>
            <th>Correo</th>
            <th>Fecha de nacimiento</th>
            </tr>
            </thead>
            <tfoot>
            <tr>
            <td colspan="6">
            <div class="links"><a href="#">&laquo;</a> <a class="active" href="#">1</a> <a href="#">2</a> <a href="#">3</a> <a href="#">4</a> <a href="#">&raquo;</a></div>
            </td>
            </tr>
            </tfoot>
            <tbody>
            <tr>
            <td><button id="btnRead" href="#">Read</button><button id="btnUpdate">Update</button><button id="btnDelete">Delete</button></td>
            <td>0123456789</td>
            <td>Constanza</td>
            <td>27</td>
            <td>constanza.tubio.v@gmail.com</td>
            <td></td>
            </tr>
            </tbody>
            </table>
        </div>
    </form>
</body>
</html>
