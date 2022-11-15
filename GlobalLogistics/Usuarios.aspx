<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="GlobalLogistics.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Global Logistics</title>
    <link href="https://cdn.jsdelivr.net/npm/simple-datatables@latest/dist/style.css" rel="stylesheet" />
    <link href="css/styles.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>
    <%--    Estilos--%>
    <style>
        .Buttons {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #1199EE;
            color: white;
            box-shadow: 2px 2px 30px #000;
            border-radius: 5px;
            margin-top: 0px;
            width: 100px;
        }

        #btnAgregar:hover {
            background-color: #117bee;
            cursor: pointer;
        }

        #btnModificar:hover {
            background-color: #117bee;
            cursor: pointer;
        }

        #btnEliminar:hover {
            background-color: #117bee;
            cursor: pointer;
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
        .TextBox {
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

        .Labels {
            color: aliceblue;
            font-family: Arial;
            font-size: 35px;
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

<body class="sb-nav-fixed">
    <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
        <!-- Navbar Brand-->
        <a class="navbar-brand ps-3" href="index2.html">Inicio</a>
        <!-- Sidebar Toggle-->
        <button class="btn btn-link btn-sm order-1 order-lg-0 me-4 me-lg-0" id="sidebarToggle" href="#!"><i class="fas fa-bars"></i></button>
        <!-- Navbar Search-->
        <form class="d-none d-md-inline-block form-inline ms-auto me-0 me-md-3 my-2 my-md-0">
            <!--<div class="input-group">
                    <input class="form-control" type="text" placeholder="Search for..." aria-label="Search for..." aria-describedby="btnNavbarSearch" />
                    <button class="btn btn-primary" id="btnNavbarSearch" type="button"><i class="fas fa-search"></i></button>
                </div>-->
        </form>
        <!-- Navbar-->
        <ul class="navbar-nav ms-auto ms-md-0 me-3 me-lg-4">
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-user fa-fw"></i></a>
                <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                    <li><a class="dropdown-item" href="#!">Panel de control</a></li>
                    <li><a class="dropdown-item" href="#!">Log</a></li>
                    <li>
                        <hr class="dropdown-divider" />
                    </li>
                    <li><a class="dropdown-item" href="#!">Logout</a></li>
                </ul>
            </li>
        </ul>
    </nav>
    <div id="layoutSidenav">
        <div id="layoutSidenav_nav">
            <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                <div class="sb-sidenav-menu">
                    <div class="nav">
                        <div class="sb-sidenav-menu-heading">Negocio</div>
                        <a class="nav-link" href="ProductoUI.aspx">
                            <div class="sb-nav-link-icon"><i class="fas fa-tachometer-alt"></i></div>
                            Productos
                                <a class="nav-link collapsed" href="#" data-bs-toggle="collapse" data-bs-target="#collapseLayouts" aria-expanded="false" aria-controls="collapseLayouts">
                                    <div class="sb-nav-link-icon"><i class="fas fa-columns"></i></div>
                                    Apps
                                    <div class="sb-sidenav-collapse-arrow"></div>
                                </a>
                            <div class="collapse" id="collapseLayouts" aria-labelledby="headingOne" data-bs-parent="#sidenavAccordion">
                                <nav class="sb-sidenav-menu-nested nav">


                                    <!--Administrar usuarios-->
                                    <a class="nav-link" href="Usuarios.aspx">
                                        <div class="sb-nav-link-icon"><i class="fas fa-user-plus"></i></div>
                                        Administrar Usuarios
                                    </a>

                                    <!--Asignar Permisos-->
                                    <a class="nav-link" href="PermisosUI.aspx">
                                        <div class="sb-nav-link-icon"><i class="fas fa-key"></i></div>
                                        Asignar Permisos
                                    </a>

                                    <!--DVH-->
                                    <a class="nav-link" href="Verificadores.aspx">
                                        <div class="sb-nav-link-icon"><i class="fas fa-calculator"></i></div>
                                        Recalcular DVH
                                    </a>

                                    <!--Backup & Restore-->
                                    <a class="nav-link" href="BackupRestore.aspx">
                                        <div class="sb-nav-link-icon"><i class="fas fa-database"></i></div>
                                        Backup & Restore
                                    </a>

                                    <!--Bitácora-->
                                    <a class="nav-link collapsed" href="Bitacora.aspx" data-bs-toggle="collapse" data-bs-target="#collapsePages" aria-expanded="false" aria-controls="collapsePages">
                                        <div class="sb-nav-link-icon"><i class="fas fa-book-open"></i></div>
                                        Bitácora
                                    </a>
                                </nav>
                        </a>
                    </div>
                </div>
                <!-- Backup & Restore-->
                <!--<a class="nav-link" href="index.html">
                                    <div class="sb-nav-link-icon"><i class="fas fa-tachometer-alt"></i></div>
                                    Backup & Restore
                                </a>-->

                <!-- Colapsado Bitácora-->

                <div class="collapse" id="collapsePages" aria-labelledby="headingTwo" data-bs-parent="#sidenavAccordion">
                    <nav class="sb-sidenav-menu-nested nav accordion" id="sidenavAccordionPages"></nav>
                </div>



                <div class="sb-sidenav-footer">
                    <!-- Traer el usuario logueado-->
                    <div class="small">Logueado como:
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
                    <!-- Start Bootstrap-->
                </div>
            </nav>
        </div>
    </div>
    <main>
        <form id="form1" runat="server">
            <div>
                <h4>Usuarios:</h4>
            </div>
            <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdUsuarios_SelectedIndexChanged" CssClass="mGrid">
            </asp:GridView>
            <p>
                <input type="text" class="form-control" placeholder="Nombre de usuario" id="txtNombre" runat="server">
            </p>
            <p>
                <input type="text" class="form-control" placeholder="Email" id="txtEmail" runat="server">
            </p>
            <asp:Button ID="btnAgregarUsuario" class="Buttons" runat="server" OnClick="btnAgregarUsuario_Click" Style="margin-bottom: 0px" Text="Agregar Usuario" Height="24px" Width="110px" />
            <asp:Button ID="btnModificarUsuario" class="Buttons" runat="server" OnClick="btnModificarUsuario_Click" Style="margin-bottom: 0px" Text="Modificar" Height="24px" Width="110px" />
            <asp:Button ID="btnEliminarUsuario" class="Buttons" runat="server" OnClick="btnEliminarUsuario_Click" Style="margin-bottom: 0px" Text="Eliminar Usuario" Height="24px" Width="110px" />

            <br />
            <br />

            <h4>Todos los permisos:</h4>
            <asp:GridView ID="grdPatentes" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdPatentes_SelectedIndexChanged" CssClass="mGrid">
            </asp:GridView>
            <asp:Button ID="btnAgregar" class="Buttons" runat="server" OnClick="btnAgregarPermiso" Style="margin-bottom: 0px" Text="Agregar Permiso" Height="24px" Width="110px" />

            <br />
            <br />
            <h4>Patentes Asignadas</h4>
            <asp:GridView ID="grdPatAsignadas" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdPatAsignadas_SelectedIndexChanged" CssClass="mGrid">
            </asp:GridView>
            <asp:Button ID="btnRemoverPermiso" class="Buttons" runat="server" OnClick="btnRemoverPermiso_Click" Style="margin-bottom: 0px" Text="Remover Permisos" Height="25px" Width="110px" />

            <br />
        </form>
    </main>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="js/scripts2.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
        <script src="assets/demo/chart-area-demo.js"></script>
        <script src="assets/demo/chart-bar-demo.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/simple-datatables@latest" crossorigin="anonymous"></script>
        <script src="js/datatables-simple-demo.js"></script>
</body>
</html>
