<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipalUI.aspx.cs" Inherits="GlobalLogistics.MenuPrincipalUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu</title>
    <link rel="shortcut icon" href="https://i.imgur.com/jd9iHlx.png">
	<style>body {
  margin: 0;
  padding: 0;
  background-color: #222;
}

* {
  font-family: Helvetica,sans-serif;
  color: #555;
}

#mmeennuu {
  display: none;
}

#mmeennuu:checked ~ .menu {
  width: 500px;
  border-radius: 5px;
  background-color:RGBA(17,153,238,0.2);
  border: 3px solid #1199EE;
  height: 85px;
}
#mmeennuu:checked ~ .menu > ul {
  display: block;
  opacity: 1;
}
#mmeennuu:checked ~ .menu > .barry {
  display: none;
}

.menu {
  display: block;
  margin: 30px auto;
  width: 100px;
  height: 100px;
  background-color: #1199EE;
  border: 3px solid transparent;
  border-radius: 50%;
  overflow: hidden;
  cursor: pointer;
  transition: all 0.5s ease-in-out;
  -webkit-transition: all 0.5s ease-in-out;
  -moz-transition: all 0.5s ease-in-out;
  -o-transition: all 0.5s ease-in-out;
  -ms-transition: all 0.5s ease-in-out;
}
.menu div.barry {
  width: 40px;
  margin: 35px auto;
}
.menu div.barry .bar {
  display: block;
  width: 100%;
  height: 5px;
  margin-top: 3px;
  border-radius: 2px;
  background-color: #fff;
}
.menu ul {
  opacity: 0;
  display: none;
  transition: all 0.5s ease-in-out;
  -webkit-transition: all 0.5s ease-in-out;
  -moz-transition: all 0.5s ease-in-out;
  -o-transition: all 0.5s ease-in-out;
  -ms-transition: all 0.5s ease-in-out;
  list-style-type: none;
  padding: 0;
  width: 500px;
  text-align: center;
  margin-bottom: 0;
}
.menu ul li {
  display: inline-block;
}

.alerta {
  vertical-align: bottom
}

.menu ul li a {
  text-decoration: none;
  display: inline-block;
  padding: 15px 25px;
  color: #fff;
  font-size: 20px;
  font-weight: bold;
  transition: all 0.3s ease-in-out;
  -webkit-transition: all 0.3s ease-in-out;
  -moz-transition: all 0.3s ease-in-out;
  -o-transition: all 0.3s ease-in-out;
  -ms-transition: all 0.3s ease-in-out;
  border: 3px solid transparent;
  border-radius: 5px;
  text-shadow:2px 2px 4px #000000;
}
.menu ul li a:hover {
  border-color: #1199EE;
}
.menu ul li a:target {
  border-bottom-color: #1199EE;
}
        .alerrta {
            margin-left: 40px;
        }
        #Button1{
            position:absolute;
            right:70px;
            padding:10px 40px 10px 40px;
             background-color: #1199EE;
             border:none;
             color:white;
             box-shadow:2px 2px 30px #000;
             border-radius:5px;
        }
        .labels{
            position:absolute;
            left:50px;
            padding:0px 150px 0px 0px;
        }

        #Button1:hover{
                                      background-color: #117bee;
                                      cursor:pointer;

        }

        #btnBackup{
             background-color: #1199EE;
             border:none;
             color:white;
             box-shadow:2px 2px 30px #000;
             border-radius:5px;
        }

        #btnBackup:hover{
             background-color: #117bee;
             cursor:pointer;

        }
          #btnProductos{
             border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #1199EE;
             color:white;
             box-shadow:2px 2px 30px #000;
             border-radius:5px;
            margin-top: 0px;
        }

        #btnProductos:hover{
             background-color: #117bee;
             cursor:pointer;

        }
    </style>
</head>
<body style="background-image:url(https://i.ibb.co/YRyZzVx/store-g0842e754b-1920.jpg)">
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
    <input type='checkbox' id='mmeennuu'/>
<label class='menu' for='mmeennuu'/>

<div class='barry'>
	<span class='bar'></span>
	<span class='bar'></span>
	<span class='bar'></span>
	<span class='bar'></span>
</div>

<ul>
	<li><a id='bitacora' href='Bitacora.aspx' runat="server" visible="false">Bitacora</a></li>
	<li><a id='usuario' href='ABMUsuario.aspx' runat="server" visible="False">Usuarios</a></li>
	<li><a id='digitos' href='Verificadores.aspx' runat="server" visible="false">Dígitos Verificadores</a></li>
</ul>
        </label>
        	            

        <div style="margin-left: 40px">
            <br />
            <asp:Label style="top:50px;" class="labels" ID="lblUser" runat="server" Text="Label" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White"></asp:Label>
            <br />
            <br />
            <asp:Label style="top:80px;" class="labels" ID="lblRol" runat="server" Text="Label" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White"></asp:Label>
            <br />
            <br />
            <br />
            <!---->
            <br />
            <br />
            <asp:Button ID="btnBackup" runat="server" OnClick="btnBackup_Click" Text="BackupRestore" Height="38px" />
            <br />
            <br />
            <asp:Button ID="btnProductos" runat="server" OnClick="btnProductos_Click1" Text="Productos" Height="38px" />
            <br />
            <br />
            <br />
            
            <br />
        </div>
        <div class="alerrta">
            <asp:Label ID="lblDVVDVH" runat="server" Text="Label" Font-Bold="True" Font-Names="Arial" Font-Size="Larger" ForeColor="#C60000" Visible="False"></asp:Label>
            </div>
    </form>
</body>
</html>