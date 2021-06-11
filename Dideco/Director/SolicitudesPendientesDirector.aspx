<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudesPendientesDirector.aspx.cs" Inherits="Dideco.DirectorAreaOperativa.SolicitudesPendientesDirector1" %>

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

                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Tables">
                        <a class="nav-link" href="SolicitudesPendientesAsistentes.aspx">
                            <i class="fa fa-fw fa-table"></i>
                            <span class="nav-link-text">Solicitudes Asistentes</span>
                        </a>
                    </li>
                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="SolicitudesPendientesDirector.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Solicitudes Director</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="SolicitudesPorBeneficiario.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Solicitudes por Beneficiario</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="Estadisticas.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Estadisticas</span>
                        </a>
                    </li>

                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
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
                <h2>Bienvenido 
            <asp:Label ID="LblUsuario2" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="LblUsuario" runat="server" Visible="False"></asp:Label>
                    &nbsp;|| <a href="Index.aspx">
                        <button type="button" class="btn btn-default">Volver atras</button></a>
                </h2>
                <table border="0" style="margin-top: 20px">
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="alert-success" Font-Size="Large"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="alert-danger" Font-Size="Large"></asp:Label>
                        </td>
                    </tr>
                </table>

                <br />
                <asp:Panel ID="PanelSolicitudes" runat="server">
                    <fieldset>
                        <legend>Solicitudes pendientes</legend>
                        <asp:GridView ID="GvSolicitudesDirector" runat="server" AutoGenerateColumns="False" DataSourceID="ODSSolicitudesDirector" AllowPaging="True" DataKeyNames="IdSolicitud" OnSelectedIndexChanged="GvSolicitudesDirector_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="IdSolicitud" HeaderText="Folio" SortExpression="IdSolicitud" />
                                <asp:BoundField DataField="RutBeneficiario" HeaderText="Rut" SortExpression="Visita" />
                                <asp:TemplateField HeaderText="Asistente" SortExpression="Asistente">
                                    <ItemTemplate>
                                        <asp:Label ID="LblAsistente" runat="server" Text='<% #BuscarAsistente(Eval("Asistente").ToString())%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Motivo" SortExpression="Motivo">
                                    <ItemTemplate>
                                        <asp:Label ID="LblMotivo" runat="server" Text='<% #ObtenerMotivo(Convert.ToInt32(Eval("IdSolicitud")))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Beneficiario.Nombre" HeaderText="Beneficiario" SortExpression="RutBeneficiario" />
                                <asp:BoundField DataField="Personal.Nombre" HeaderText="Secretaria" SortExpression="UserPersonal" />
                                <asp:BoundField DataField="FechaSolicitud" DataFormatString="{0:d}" HeaderText="Fecha de Solicitud" SortExpression="FechaSolicitud" />
                                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Image" HeaderText="Revisar solicitud" SelectImageUrl="~/img/elegir.png" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSSolicitudesDirector" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SolicitudesDirectorPendientes" TypeName="Dideco.BLL.SolicitudesBLL"></asp:ObjectDataSource>
                    </fieldset>
                </asp:Panel>
                <br />
                <asp:Panel ID="PanelAprobaciones" runat="server" Visible="False">
                    <fieldset>
                        <legend>Solicitud</legend>

                        <table border="0" style="margin-top: 20px" align="center">
                            <tr>
                                <td>Rut del beneficiario</td>
                                <td>
                                    <asp:Label ID="LblId" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="TxtRut" ReadOnly="true" runat="server" Width="440px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Nombre</td>
                                <td></td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="TxtNombre" ReadOnly="true" runat="server" Width="440px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Dirección</td>
                                <td></td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="TxtDireccion" ReadOnly="true" runat="server" Width="440px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Contacto</td>
                                <td></td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="TxtContacto" ReadOnly="true" runat="server" Width="440px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Localidad</td>
                                <td></td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="TxtLocalidad" ReadOnly="true" runat="server" Width="440px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Motivo</td>
                                <td></td>
                                <td class="text-left">
                                    <asp:CheckBox ID="ChkVivienda" runat="server" Text="Vivienda" Enabled="false" />
                                    <br />
                                    <asp:CheckBox ID="ChkAlimentacion" runat="server" Text="Alimentación" Enabled="false" />
                                    <br />
                                    <asp:CheckBox ID="ChkSalud" runat="server" Text="Salud" Enabled="false" />
                                    <br />
                                    <asp:CheckBox ID="ChkInfancia" runat="server" Text="Infancia" Enabled="false" />
                                    <br />
                                    <asp:CheckBox ID="ChkDefunciones" runat="server" Text="Defunciones" Enabled="false" />
                                    <br />
                                    <asp:CheckBox ID="ChkMicroemprendimiento" runat="server" Text="Microemprendimiento" Enabled="false" />
                                    <br />
                                    <asp:CheckBox ID="ChkPSGubernamental" runat="server" Text="Prog. Soc. Gubernamental" Enabled="false" />
                                    <br />
                                    <asp:CheckBox ID="ChkMaquinaria" runat="server" Text="Maquinaria" Enabled="false" />
                                    <br />
                                    <asp:CheckBox ID="ChkPersonalMunicipal" runat="server" Text="Personal Municipal" Enabled="false" />
                                    <br />
                                    <asp:CheckBox ID="ChkRebajaAseo" runat="server" Text="Rebaja Aseo" Enabled="false" />
                                    <br />
                                    <asp:CheckBox ID="ChkAgua" runat="server" Text="Entrega de Agua" Enabled="false" />
                                    <br />
                                    <asp:CheckBox ID="ChkOtros" runat="server" Text="Otros" Enabled="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>¿Pertenece al registro social de hogares?</td>
                                <td></td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="TxtRGH" ReadOnly="true" runat="server" Width="400px"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LblPorcentaje" runat="server" Text="Porcentaje del registro social de hogares" Visible="false"></asp:Label></td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtPorcentaje" runat="server" Visible="false" Width="400px" ReadOnly="true"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Detalles del caso</td>
                                <td></td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="TxtDetalle" runat="server" TextMode="MultiLine" Width="440px" Height="400px" ReadOnly="True"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>¿Se realizo visita?</td>
                                <td></td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="TxtVisita" runat="server" Width="440px" ReadOnly="True"></asp:TextBox>
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
                                    <asp:Calendar ID="CVisita" runat="server" Height="196px" SelectedDate="07/05/2017 15:19:16" Visible="False" Width="440px"></asp:Calendar>
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
                                <td class="auto-style1">
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>Situación familiar y socioeconomica del solicitante</td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="TxtSituacion" runat="server" TextMode="MultiLine" Width="400px" Height="300px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    Observaciones<br />
                                </td>
                                <td>
                                    <br />
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="TxtObservacion" runat="server" Height="300px" TextMode="MultiLine" Width="400px"></asp:TextBox>
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
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="BtnAprobarSolicitud" runat="server" Text="Aprobar Solicitud" CssClass="btn-success" OnClick="BtnAprobarSolicitud_Click" PostBackUrl="~/Director/SolicitudesPendientesDirector.aspx" /></td>
                                <td class="auto-style1">
                                    <asp:Button ID="BtnRechazarSolicitud" runat="server" Text="Rechazar Solicitud" CssClass="btn-warning" OnClick="BtnRechazarSolicitud_Click" PostBackUrl="~/Director/SolicitudesPendientesDirector.aspx" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                                <td class="auto-style1">
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <div style="float: right;">
                            <asp:Button ID="BtnRecargar" runat="server" Text="Volver a las solicitudes pendientes" OnClick="BtnRecargar_Click" />
                        </div>
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
