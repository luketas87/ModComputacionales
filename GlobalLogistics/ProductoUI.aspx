<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductoUI.aspx.cs" Inherits="GlobalLogistics.ProductoUI" %>

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
</head>
<body class="sb-nav-fixed">
    <form id="form1" runat="server">
        >
     <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
         <!-- Navbar Brand-->
         <a class="navbar-brand ps-3" href="MenuPrincipalUI.aspx">Inicio</a>
         <!-- Sidebar Toggle-->
         <button class="btn btn-link btn-sm order-1 order-lg-0 me-4 me-lg-0" id="sidebarToggle" href="#!"><i class="fas fa-bars"></i></button>
         <!-- Navbar Search-->
         <!--<div class="input-group">
                    <input class="form-control" type="text" placeholder="Search for..." aria-label="Search for..." aria-describedby="btnNavbarSearch" />
                    <button class="btn btn-primary" id="btnNavbarSearch" type="button"><i class="fas fa-search"></i></button>
                </div>-->
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
                                        <a class="nav-link" href="Bitacora.aspx">
                                            <div class="sb-nav-link-icon"><i class="fas fa-database"></i></div>
                                            Bitacora
                                        </a>
                                    </nav>

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
                            </a>


                            <div class="sb-sidenav-footer">
                                <!-- Traer el usuario logueado-->
                                <div class="small">Logueado como: </div>
                                <!-- Start Bootstrap-->
                            </div>
                </nav>
            </div>

            <!-- Seccion fondo-->
            <div id="layoutSidenav_content">
                <main>
                    <div class="container-fluid px-4">
                        <h1 class="mt-4">Productos</h1>
                        <ol class="breadcrumb mb-4">
                            <%--<li class="breadcrumb-item active">Productos</li>--%>
                        </ol>
                        <!--<div class="row">
                    <div class="col-xl-3 col-md-6">
                        <div class="card bg-primary text-white mb-4">
                            <div class="card-body">Primary Card</div>
                            <div class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link" href="#">View Details</a>
                                <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-md-6">
                        <div class="card bg-warning text-white mb-4">
                            <div class="card-body">Warning Card</div>
                            <div class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link" href="#">View Details</a>
                                <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-md-6">
                        <div class="card bg-success text-white mb-4">
                            <div class="card-body">Success Card</div>
                            <div class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link" href="#">View Details</a>
                                <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-md-6">
                        <div class="card bg-danger text-white mb-4">
                            <div class="card-body">Danger Card</div>
                            <div class="card-footer d-flex align-items-center justify-content-between">
                                <a class="small text-white stretched-link" href="#">View Details</a>
                                <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                            </div>
                        </div>
                    </div>
                </div>-->
                        <div class="row">
                            <div class="col-xl-6">
                                <div class="card mb-4">
                                    <!--<div class="card-header">-->
                                    <!--<i class="fas fa-chart-area me-1"></i>-->
                                    <!--Area Chart Example-->
                                    <!--</div>-->
                                    <!--<div class="card-body"><canvas id="myAreaChart" width="100%" height="40"></canvas></div>-->
                                </div>
                            </div>
                            <div class="col-xl-6">
                                <div class="card mb-4">
                                    <!--<div class="card-header">-->
                                    <!--<i class="fas fa-chart-bar me-1"></i>-->
                                    <!--Bar Chart Example-->
                                    <!--</div>-->
                                    <!--<div class="card-body"><canvas id="myBarChart" width="100%" height="40"></canvas></div>-->
                                </div>

                            </div>
                        </div>
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fas fa-table me-1"></i>
                                <!-- Tabla de registros-->
                                Registros &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label><asp:TextBox ID="txtID" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar " OnClick="btnModificar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Agregar Stock"></asp:Label><asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
                                <asp:Button ID="btnStock" runat="server" Text="Agregar Stock" OnClick="btnStock_Click" />
                            </div>
                            <div class="card-body">

                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="True" GridLines="None"
                                    AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnPageIndexChanging="GridView2_PageIndexChanging">
                                </asp:GridView>




                            </div>
                        </div>
                        <asp:Button ID="btnExportar" runat="server" Text="Exportar" OnClick="btnExportar_Click" Height="28px" Width="68px" />
                        <br />
                        <asp:FileUpload ID="btnImportar" runat="server" Text="Importar .xml" Height="28px" Width="68px" />
                        <asp:Button ID="btnSubir" runat="server" Text="Subir" Height="28px" Width="68px" OnClick="btnSubir_Click" />
                        <br />

                                <asp:GridView ID="gridViewArchivo" runat="server" AutoGenerateColumns="True" GridLines="None"
                                    AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" AutoGenerateSelectButton="True" OnPageIndexChanging="gridViewArchivo_PageIndexChanging">
                                </asp:GridView>




                    </div>
                </main>
                <footer class="py-4 bg-light mt-auto">
                    <div class="container-fluid px-4">
                        <div class="d-flex align-items-center justify-content-between small">
                            <div class="text-muted">Copyright &copy; Global Logistics 2022</div>
                            <div>
                                <a href="#">Privacy Policy</a>
                                &middot;
                                <a href="#">Terms &amp; Conditions</a>
                            </div>
                        </div>
                    </div>
                </footer>
            </div>

        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="js/scripts2.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
        <script src="assets/demo/chart-area-demo.js"></script>
        <script src="assets/demo/chart-bar-demo.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/simple-datatables@latest" crossorigin="anonymous"></script>
        <script src="js/datatables-simple-demo.js"></script>
    </form>
</body>
</html>
