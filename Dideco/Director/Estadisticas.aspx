<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="Dideco.DirectorAreaOperativa.Estadisticas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Municipalidad de Puchuncaví</title>

    <!-- Bootstrap core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom fonts for this template -->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Plugin CSS -->
    <link href="vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="css/sb-admin.css" rel="stylesheet" />
    <style>
        .myButton {
            background-color: #4545c7;
            -moz-border-radius: 42px;
            -webkit-border-radius: 42px;
            border-radius: 42px;
            border: 2px solid #2319ab;
            display: inline-block;
            cursor: pointer;
            color: #ffffff;
            font-family: Trebuchet MS;
            font-size: 17px;
            font-weight: bold;
            padding: 19px 60px;
            text-decoration: none;
            text-shadow: 0px 1px 30px #283466;
        }

            .myButton:hover {
                background-color: #402abd;
            }

            .myButton:active {
                position: relative;
                top: 1px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navigation -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" id="mainNav">
            <a class="navbar-brand" href="#"></a>
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav navbar-sidenav">
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Dashboard">
                        <a class="nav-link" href="Index.aspx">
                            <i class="fa fa-fw fa-dashboard"></i>
                            <span class="nav-link-text">Inicio</span>
                        </a>
                    </li>

                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Tables">
                        <a class="nav-link" href="SolicitudesPendientesAsistentes.aspx">
                            <i class="fa fa-fw fa-table"></i>
                            <span class="nav-link-text">Solicitudes Asistentes</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="SolicitudesPendientesDirector.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Solicitudes Director</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="SolicitudesPorBeneficiario.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Solicitudes por beneficiario</span>
                        </a>
                    </li>
                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="Estadisticas.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Estadisticas</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="SolicitudesAlcaldia.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Solicitudes de alcaldia</span>
                        </a>
                    </li>
                    
                </ul>

                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="modal" data-target="#exampleModal">
                            <i class="fa fa-fw fa-sign-out"></i>
                            Desconectarse</a>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="content-wrapper py-3">

            <div class="container-fluid">

                <br />
                <br />
                <br />
                <h2>Bienvenido
        
        <asp:Label ID="LblUsuario2" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="LblUsuario" runat="server" Visible="False"></asp:Label>
                    &nbsp;|| <a href="Index.aspx">
                        <button type="button" class="btn btn-default">Volver atras</button></a>
                </h2>
                <br />
                <br />
                <h3>Estadisticas</h3>
                <fieldset>
                    <legend>Seleccione que tipo de estadisticas desea revisar</legend>
                    <br />
                    <br />


                    <table style="width: 100%; align-content: center;">
                        <tr>
                            <td align="center">
                                <a href="EstadisticasFecha.aspx" class="myButton">
                                    Estadisticas por fecha</a>
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;</td>
                            <td align="center">
                                <a href="EstadisticasLocalidad.aspx" class="myButton">
                                    Estadisticas por localidad</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <a href="EstadisticasMotivo.aspx" class="myButton">
                                    Estadisticas por motivo</a>
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;</td>
                           <td align="center">
                                <a href="EstadisticasRangoEtario.aspx" class="myButton">
                                    Estadisticas por rango etario</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>
                    </table>
                </fieldset>

            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /.content-wrapper -->
        <!-- Scroll to Top Button -->
        <a class="scroll-to-top rounded" href="#page-top">
            <i class="fa fa-angle-up"></i>
        </a>

        <!-- Logout Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Desconectarse</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        ¿Seguro que desea desconectarse?.
         
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        <asp:LoginStatus ID="LoginStatus1" class="btn btn-primary" runat="server" LogoutText="Cerrar sesión" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Bootstrap core JavaScript -->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/popper/popper.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.min.js"></script>

        <!-- Plugin JavaScript -->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
        <script src="vendor/chart.js/Chart.min.js"></script>
        <script src="vendor/datatables/jquery.dataTables.js"></script>
        <script src="vendor/datatables/dataTables.bootstrap4.js"></script>

        <!-- Custom scripts for this template -->
        <script src="js/sb-admin.min.js"></script>
    </form>
</body>

</html>
