<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="GlobalLogistics.Bitacora" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

        <style type="text/css">

            .main-background {
                background-image: url(https://i.ibb.co/drgvK9q/4M2.jpg);
                width: 70%;
                height: 70%;
                position: absolute;
            }

            * {
    padding: 0;
    margin: 0;
}

body {
    font: 11px Tahoma;
}

h1 {
    font: bold 32px Times;
    color: #666;
    text-align: center;
    padding: 20px 0;
}

#container {
    width: 700px;
    margin: 10px auto;
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

           /* #GridView1{
                opacity: 0.4;
            }*/
        </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body class="main-background" style="left: 56px; top: 0px; width: 92%">
    <form id="form1" runat="server" translate="0.2">
        <h1>Bitácora</h1>
        <br />Usuario:
        <asp:TextBox ID="TxtUsuario" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nivel de criticidad:
        <asp:TextBox ID="TxtNivel" runat="server" ToolTip="Fecha Hasta"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Filtrar" />
        <br /><br /><br />
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="200" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                
            </asp:GridView>
        </div>
    </form>
</body>
</html>