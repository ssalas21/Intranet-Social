<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarAudiencia.aspx.cs" Inherits="Dideco.SecreAlcaldia.AgregarAudiencia" %>

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

                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Tables">
                        <a class="nav-link" href="AgregarAudiencia.aspx">
                            <i class="fa fa-fw fa-table"></i>
                            <span class="nav-link-text">Agregar Audiencia</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="AsignarAudiencias.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Asignar Audiencias</span>
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

                <fieldset>
                    <legend>Generar solicitud de beneficio</legend>
                    <table border="0" style="margin-top: 20px">
                        <tr>
                            <td></td>
                            <td>
                                <asp:Label ID="LblSolicitud" runat="server" Text="" CssClass="alert-success"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblError" runat="server" CssClass="alert-danger"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Rut del beneficiario</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtRut" runat="server" AutoPostBack="True" OnTextChanged="TxtRut_TextChanged" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Nombre</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtNombre" runat="server" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Dirección</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtDireccion" runat="server" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Contacto</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtContacto" runat="server" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Genero</td>
                            <td></td>
                            <td>
                                <asp:DropDownList ID="DdlGenero" runat="server" Width="340px" AutoPostBack="True">
                                    <asp:ListItem>FEMENINO</asp:ListItem>
                                    <asp:ListItem>MASCULINO</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Fecha de nacimiento (DD/MM/AAAA)</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtFechaNacimiento" runat="server" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Localidad</td>
                            <td></td>
                            <td>
                                <asp:DropDownList ID="DdlLocalidad" runat="server" Height="25px" Width="340px" AutoPostBack="True">
                                    <asp:ListItem>CAMPICHE</asp:ListItem>
                                    <asp:ListItem>CHILICAUQUÉN</asp:ListItem>
                                    <asp:ListItem>EL CARDAL</asp:ListItem>
                                    <asp:ListItem>EL RINCÓN</asp:ListItem>
                                    <asp:ListItem>EL RUNGUE</asp:ListItem>
                                    <asp:ListItem>EL PASO</asp:ListItem>
                                    <asp:ListItem>HORCÓN</asp:ListItem>
                                    <asp:ListItem>LA CANELA</asp:ListItem>
                                    <asp:ListItem>LA CHOCOTA</asp:ListItem>
                                    <asp:ListItem>LA ESTANCILLA</asp:ListItem>
                                    <asp:ListItem>LA GREDA</asp:ListItem>
                                    <asp:ListItem>LA LAGUNA</asp:ListItem>
                                    <asp:ListItem>LA QUEBRADA</asp:ListItem>
                                    <asp:ListItem>LAS MELOSILLAS</asp:ListItem>
                                    <asp:ListItem>LAS VENTANAS</asp:ListItem>
                                    <asp:ListItem>LOS MAITENES</asp:ListItem>
                                    <asp:ListItem>LOS MAQUIS</asp:ListItem>
                                    <asp:ListItem>MAITENCILLO</asp:ListItem>
                                    <asp:ListItem>POTRERILLOS</asp:ListItem>
                                    <asp:ListItem>PUCALÁN</asp:ListItem>
                                    <asp:ListItem>PUCHUNCAVÍ</asp:ListItem>
                                    <asp:ListItem>SAN ANTONIO</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Detalles del caso</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtSolicitud" runat="server" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Forma de Entrega</br></td>
                            <td></br></td>
                            <td>
                                <asp:DropDownList ID="DdlTipo" runat="server" Width="400px">
                                    <asp:ListItem>CARTA</asp:ListItem>
                                    <asp:ListItem>PRESENCIAL</asp:ListItem>
                                </asp:DropDownList>
                                </br></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="BtnAgregarSolicitud" runat="server" Text="Agregar Solicitud" CssClass="btn-primary" OnClick="BtnAgregarSolicitud_Click" /></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></br></td>
                            <td></br></td>
                            <td></br></td>
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
