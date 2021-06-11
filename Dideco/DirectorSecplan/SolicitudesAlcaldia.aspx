<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudesAlcaldia.aspx.cs" Inherits="Dideco.DirectorSecplan.SolicitudesAlcaldia" %>

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

                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="SolicitudesAlcaldia.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Solicitudes alcaldia</span>
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
                <h2>Bienvenid@        
        <asp:Label ID="LblUsuario2" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="LblUsuario" runat="server" Visible="False"></asp:Label>
                    &nbsp;|| <a href="Index.aspx">
                        <button type="button" class="btn btn-default">Volver atras</button></a>
                </h2>
                <asp:Label ID="LblDepto" runat="server" Text="DIDECO" Visible="false"></asp:Label>
                <br />
                <asp:Panel ID="Panel1" runat="server" Visible="true">
                    <fieldset>
                        <legend>Solicitudes</legend>
                        <asp:Label ID="LblDerivado" runat="server" Visible="false" CssClass="alert-success"></asp:Label>
                        <asp:GridView ID="GvAudiencias" runat="server" AutoGenerateColumns="False" DataSourceID="ODSAudiencias" DataKeyNames="IdAudiencias" OnSelectedIndexChanged="GvAudiencias_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="IdAudiencias" HeaderText="Id" SortExpression="IdAudiencias" />
                                <asp:BoundField DataField="Beneficiario.Nombre" HeaderText="Beneficiario" SortExpression="RutBeneficiario" />
                                <asp:BoundField DataField="FechaDerivacion" DataFormatString="{0:d}" HeaderText="Fecha de derivacion" SortExpression="FechaDerivacion" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/elegir.png" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSAudiencias" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerAudienciasSinSolucionPorDepartamento" TypeName="Dideco.BLL.AudienciasBLL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="LblDepto" Name="departamento" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </fieldset>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                    <fieldset>
                        <legend>Audiencia</legend>
                        <table border="0" style="margin-top: 20px">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="LblError" runat="server" CssClass="alert-danger"></asp:Label>
                                    <asp:Label ID="LblSolicitud" runat="server" Text="" Visible="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Rut del beneficiario</td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtRut" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Nombre</td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtNombre" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Dirección</td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtDireccion" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Contacto</td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtContacto" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Genero</td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtSexo" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td>Fecha de nacimiento (DD/MM/AAAA)</td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtFechaNacimiento" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Localidad</td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtLocalidad" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Solicitud</td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtSolicitud" runat="server" TextMode="MultiLine" Width="400px" Height="200px" ReadOnly="true"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Compromiso</td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtCompromiso" runat="server" TextMode="MultiLine" Width="400px" Height="200px" ReadOnly="true"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LblRespuesta" runat="server" Text="Respuesta entregada"></asp:Label>
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtSolucion" runat="server" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Button ID="BtnAtenderSolicitud" runat="server" Text="Entregar Solución" CssClass="btn-primary" OnClick="BtnAtenderSolicitud_Click" /></td>
                                <td></td>
                                <td>
                                    <asp:Label ID="LblId" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
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
                        <h5 class="modal-title" id="exampleModalLabel">Desconectarse                       <span aria-hidden="true">&times;</span>
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



