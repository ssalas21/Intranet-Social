<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticasFecha.aspx.cs" Inherits="Dideco.DirectorAreaOperativa.EstadisticasFecha1" %>

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
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
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
                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Charts">
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
                <br />
                <fieldset>
                    <legend>Buscar solicitudes por rango de fechas</legend>
                    <br />
                    <table>
                        <tr>
                            <td>Fecha Inicial :</td>
                            <td>
                                <asp:TextBox ID="TxtFechaInicial" runat="server" TextMode="Date"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Fecha Final :</td>
                            <td>
                                <asp:TextBox ID="TxtFechaFinal" runat="server" TextMode="Date"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" /></td>
                        </tr>
                    </table>
                </fieldset>

                <asp:Panel ID="PanelResultados" runat="server" Visible="False">
                    <br />
                    <br />
                    <fieldset>
                        <legend>Solicitudes</legend>
                        <asp:GridView ID="GvResultadoBusqueda" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSResultados" DataKeyNames="IdSolicitud" OnSelectedIndexChanged="GvResultadoBusqueda_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="IdSolicitud" HeaderText="Folio" SortExpression="IdSolicitud" />
                                <asp:TemplateField HeaderText="Motivo" SortExpression="Motivo">
                                    <ItemTemplate>
                                        <asp:Label ID="LblMotivo" runat="server" Text='<% #ObtenerMotivo(Convert.ToInt32(Eval("IdSolicitud")))%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Beneficiario.Nombre" HeaderText="Beneficiario" SortExpression="RutBeneficiario" />
                                <asp:BoundField DataField="Personal.Nombre" HeaderText="Secretaria" SortExpression="UserPersonal" />
                                <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha de Solicitud" SortExpression="FechaSolicitud" DataFormatString="{0:d}" />
                                <asp:TemplateField HeaderText="Asistente" SortExpression="Asistente">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<% #BuscarAsistente(Eval("Asistente").ToString())%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="AprobacionAsistente" HeaderText="Aprobacion del Asistente" SortExpression="AprobacionAsistente" />
                                <asp:BoundField DataField="AprobacionDirector" HeaderText="Aprobacion del Director" SortExpression="AprobacionDirector" />
                                <asp:CommandField SelectImageUrl="~/img/pdf.png" ShowSelectButton="True" HeaderText="Imprimir Certificado" SelectText="" ButtonType="Image" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSResultados" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerSolicitudesPorFecha" TypeName="Dideco.BLL.SolicitudesBLL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtFechaInicial" Name="inicio" PropertyName="Text" Type="DateTime" />
                                <asp:ControlParameter ControlID="TxtFechaFinal" Name="fin" PropertyName="Text" Type="DateTime" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </fieldset>
                    <div>
                        <br />
                        <asp:Label ID="LblResultado" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="BtnExcel" runat="server" Text="Obtener Archivo Excel" OnClick="BtnExcel_Click" />
                        <br />
                    </div>
                    <br />
                    <fieldset>
                        <legend>Estadisticas</legend>
                        <table border="0" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ODSEstadistica">
                                        <Columns>
                                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:ObjectDataSource ID="ODSEstadistica" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerEstadisticasPorFecha" TypeName="Dideco.BLL.EstadisticasBLL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="TxtFechaInicial" Name="inicio" PropertyName="Text" Type="DateTime" />
                                            <asp:ControlParameter ControlID="TxtFechaFinal" Name="fin" PropertyName="Text" Type="DateTime" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:Chart ID="Chart1" runat="server" DataSourceID="ODSEstadistica">
                                        <Series>
                                            <asp:Series Name="Series1" XValueMember="Estado" YValueMembers="Cantidad">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                                <Area3DStyle Enable3D="True" />
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
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
