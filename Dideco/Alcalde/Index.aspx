<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Dideco.Alcalde.Index" %>

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
    <script src="js/Chart.min.js"></script>

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
                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Dashboard">
                        <a class="nav-link" href="Index.aspx">
                            <i class="fa fa-fw fa-dashboard"></i>
                            <span class="nav-link-text">Inicio</span>
                        </a>
                    </li>

                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Tables">
                        <a class="nav-link" href="AtenderAudiencia.aspx">
                            <i class="fa fa-fw fa-table"></i>
                            <span class="nav-link-text">Atender Audiencia</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="EstadoAudiencia.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Estado de Audiencias</span>
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

                <!-- Breadcrumbs -->

                <div>
                    <br />
                    <br />
                    <br />
                    Bienvenid@ 
                    <asp:Label ID="LblUsuario2" runat="server" Text="Label"></asp:Label><br />
                    <br />
                </div>
                <!-- Icon Cards -->
                <div class="row">
                    <div class="col-xl-3 col-sm-6 mb-3">
                        <div class="card text-white bg-primary o-hidden h-100">
                            <div class="card-body">
                                <div class="card-body-icon">
                                    <i class="fa fa-fw fa-comments"></i>
                                </div>
                                <div class="mr-5">
                                    <asp:Label ID="LblCantidad2" runat="server" Text="Label"></asp:Label>
                                    audiencias sin atender
               
                                </div>
                            </div>
                            <a href="AtenderAudiencia.aspx" class="card-footer text-white clearfix small z-1">
                                <span class="float-left">Ver Detalles</span>
                                <span class="float-right">
                                    <i class="fa fa-angle-right"></i>
                                </span>
                            </a>
                        </div>
                    </div>

                    <div class="col-xl-3 col-sm-6 mb-3">
                        <div class="card text-white bg-warning o-hidden h-100">
                            <div class="card-body">
                                <div class="card-body-icon">
                                    <i class="fa fa-fw fa-list"></i>
                                </div>
                                <div class="mr-5">
                                </div>
                            </div>
                            <a href="EstadoAudiencia.aspx" class="card-footer text-white clearfix small z-1">
                                <span class="float-left">Estados de audiencias</span>
                                <span class="float-right">
                                    <i class="fa fa-angle-right"></i>
                                </span>
                            </a>
                        </div>
                    </div>
                    <!--<div class="col-xl-3 col-sm-6 mb-3">
                    <div class="card text-white bg-success o-hidden h-100">
                        <div class="card-body">
                            <div class="card-body-icon">
                                <i class="fa fa-fw fa-shopping-cart"></i>
                            </div>
                            <div class="mr-5">
                                123 New Orders!
               
                            </div>
                        </div>
                        <a href="#" class="card-footer text-white clearfix small z-1">
                            <span class="float-left">View Details</span>
                            <span class="float-right">
                                <i class="fa fa-angle-right"></i>
                            </span>
                        </a>
                    </div>
                </div>
                <div class="col-xl-3 col-sm-6 mb-3">
                    <div class="card text-white bg-danger o-hidden h-100">
                        <div class="card-body">
                            <div class="card-body-icon">
                                <i class="fa fa-fw fa-support"></i>
                            </div>
                            <div class="mr-5">
                                13 New Tickets!
               
                            </div>
                        </div>
                        <a href="#" class="card-footer text-white clearfix small z-1">
                            <span class="float-left">View Details</span>
                            <span class="float-right">
                                <i class="fa fa-angle-right"></i>
                            </span>
                        </a>
                    </div>
                </div>-->
                </div>
                <div>
                    <br />
                    <h1></h1>
                    <h2>Audiencias solicitadas durante el <asp:Label ID="LblYear" runat="server" Text="Label"></asp:Label> por localidad</h2>
                    <br />

                    <canvas id="myChart" width="1200" height="600"></canvas>
                    <script>
                        // Our labels along the x-axis
                        var years = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
                        // For drawing the lines
                        var campiche = <%=campiche%>;
                        var chilicauquen = <%=chilicauquen%>;
                        var cardal = <%=cardal%>;
                        var rincon = <%=rincon%>;
                        var rungue = <%=rungue%>;
                        var paso = <%=paso%>;
                        var horcon = <%=horcon%>;
                        var canela = <%=canela%>;
                        var chocota = <%=chocota%>;
                        var estancilla = <%=estancilla%>;
                        var greda = <%=greda%>;
                        var laguna = <%=laguna%>;
                        var quebrada = <%=quebrada%>;
                        var melosillas = <%=melosillas%>;
                        var ventanas = <%=ventanas%>;
                        var maitenes = <%=maitenes%>;
                        var maquis = <%=maquis%>;
                        var maitencillo = <%=maitencillo%>;
                        var potrerillos = <%=potrerillos%>;
                        var pucalan = <%=pucalan%>;
                        var puchuncavi = <%=puchuncavi%>;
                        var sanAntonio = <%=sanAntonio%>;
                        var ctx = document.getElementById("myChart");
                        var myChart = new Chart(ctx, {
                            type: 'line',
                            data: {
                                labels: years,
                                datasets: [
                                  {
                                      data: campiche,
                                      label: "Campiche",
                                      backgroundColor: "#3e95cd",
                                      borderColor: "#3e95cd",
                                      fill: false
                                  },
                                  {
                                      data: chilicauquen,
                                      label: "Chilicauquén",
                                      backgroundColor: "#99ff8c",
                                      borderColor: "#99ff8c",
                                      fill: false
                                  },
                                  {
                                      data: cardal,
                                      label: "El Cardal",
                                      backgroundColor: "#ff8c8c",
                                      borderColor: "#ff8c8c",
                                      fill: false
                                  },
                                  {
                                      data: rincon,
                                      label: "El Rincón",
                                      backgroundColor: "#5b5b59",
                                      borderColor: "#5b5b59",
                                      fill: false
                                  },
                                  {
                                      data: rungue,
                                      label: "El Rungue",
                                      backgroundColor: "#3a5443",
                                      borderColor: "#3a5443",
                                      fill: false
                                  },
                                  {
                                      data: paso,
                                      label: "El Paso",
                                      backgroundColor: "#543a51",
                                      borderColor: "#543a51",
                                      fill: false
                                  },
                                  {
                                      data: horcon,
                                      label: "Horcón",
                                      backgroundColor: "#3b5254",
                                      borderColor: "#3b5254",
                                      fill: false
                                  },
                                  {
                                      data: canela,
                                      label: "La Canela",
                                      backgroundColor: "#438252",
                                      borderColor: "#438252",
                                      fill: false
                                  },
                                  {
                                      data: chocota,
                                      label: "La Chocota",
                                      backgroundColor: "#7c8243",
                                      borderColor: "#7c8243",
                                      fill: false
                                  },
                                  {
                                      data: estancilla,
                                      label: "La Estancilla",
                                      backgroundColor: "#438247",
                                      borderColor: "#438247",
                                      fill: false
                                  },
                                  {
                                      data: greda,
                                      label: "La Greda",
                                      backgroundColor: "#824444",
                                      borderColor: "#824444",
                                      fill: false
                                  },
                                  {
                                      data: laguna,
                                      label: "La Laguna",
                                      backgroundColor: "#ff003b",
                                      borderColor: "#ff003b",
                                      fill: false
                                  },
                                  {
                                      data: quebrada,
                                      label: "La Quebrada",
                                      backgroundColor: "#ff0094",
                                      borderColor: "#ff0094",
                                      fill: false
                                  },
                                  {
                                      data: melosillas,
                                      label: "Las Melosillas",
                                      backgroundColor: "#ee00ff",
                                      borderColor: "#ee00ff",
                                      fill: false
                                  },
                                  {
                                      data: ventanas,
                                      label: "Las Ventanas",
                                      backgroundColor: "#7f00ff",
                                      borderColor: "#7f00ff",
                                      fill: false
                                  },
                                  {
                                      data: maitenes,
                                      label: "Los Maitenes",
                                      backgroundColor: "#1500ff",
                                      borderColor: "#1500ff",
                                      fill: false
                                  },
                                  {
                                      data: maquis,
                                      label: "Los Maquis",
                                      backgroundColor: "#00ffa5",
                                      borderColor: "#00ffa5",
                                      fill: false
                                  },
                                  {
                                      data: maitencillo,
                                      label: "Maitencillo",
                                      backgroundColor: "#26ff00",
                                      borderColor: "#26ff00",
                                      fill: false
                                  },
                                  {
                                      data: potrerillos,
                                      label: "Potrerillos",
                                      backgroundColor: "#99ff00",
                                      borderColor: "#99ff00",
                                      fill: false
                                  },
                                  {
                                      data: pucalan,
                                      label: "Pucalán",
                                      backgroundColor: "#ff6e00",
                                      borderColor: "#ff6e00",
                                      fill: false
                                  },
                                  {
                                      data: puchuncavi,
                                      label: "Puchuncaví",
                                      backgroundColor: "#f44242",
                                      borderColor: "#f44242",
                                      fill: false
                                  },
                                  {
                                      data: sanAntonio,
                                      label: "San Antonio",
                                      backgroundColor: "#f4df41",
                                      borderColor: "#f4df41",
                                      fill: false
                                  }                                  
                                ]
                            }
                        });
                    </script>
                    <br />
                </div>

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
