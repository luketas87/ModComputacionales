<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipalUI.aspx.cs" Inherits="GlobalLogistics.MenuPrincipalUI" %>

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
                     <%--<li><a class="dropdown-item" href="#!">Panel de control</a></li>--%>
                   <%--<li><a class="dropdown-item" href="#!">Log</a></li>--%>
                     <li>
                         <hr class="dropdown-divider" />
                     </li>
                     <li><a class="dropdown-item" href="Logout.aspx">Logout</a></li>
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

                            </div>

                            <div class="collapse" id="collapsePages" aria-labelledby="headingTwo" data-bs-parent="#sidenavAccordion">
                                <nav class="sb-sidenav-menu-nested nav accordion" id="sidenavAccordionPages"></nav>
                            </div>
                        </a>


                       <div class="sb-sidenav-footer">
                            <!-- Traer el usuario logueado-->
                            <div class="small">
                                Logueado como:
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </div>
                            <!-- Start Bootstrap-->
                        </div>
                    </div>
                </div>
            </nav>
        </div>
    </div>
    <!-- Seccion fondo-->
  

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="js/scripts2.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
    <script src="assets/demo/chart-area-demo.js"></script>
    <script src="assets/demo/chart-bar-demo.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/simple-datatables@latest" crossorigin="anonymous"></script>
    <script src="js/datatables-simple-demo.js"></script>
</body>
</html>
