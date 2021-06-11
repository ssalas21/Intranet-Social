<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudesPorBeneficiario.aspx.cs" Inherits="Dideco.DirectorAreaOperativa.SolicitudesPorBeneficiario1" %>

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
                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Charts">
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
                <h2>Bienvenid@        
        <asp:Label ID="LblUsuario2" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="LblUsuario" runat="server" Visible="False"></asp:Label>
                    &nbsp;|| <a href="Index.aspx">
                        <button type="button" class="btn btn-default">Volver atras</button></a>
                </h2>
                <br />
                <fieldset>
                    <legend>Revisar solicitudes por rut</legend>
                    <table border="0">
                        <tr>
                            <td>Rut del beneficiario</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtRut" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <br />
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="bg-primary" OnClick="BtnBuscar_Click" /></td>
                            <td>
                                <asp:Button ID="BtnImprimir" runat="server" Text="Imprimir detalles" OnClientClick="javascript:window.print();" Visible="False" /></td>
                        </tr>
                    </table>
                    <br />

                </fieldset>
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <fieldset>
                        <legend>Solicitudes</legend>
                        <asp:GridView ID="GvSolicitudesPorRut" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSSolicitudesPorRut" CssClass="bg-info" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="IdSolicitud" CellPadding="10" CellSpacing="10" OnSelectedIndexChanged="GvSolicitudesPorRut_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="IdSolicitud" HeaderText="Folio" SortExpression="IdSolicitud">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha de Solicitud" SortExpression="FechaSolicitud" DataFormatString="{0:d}">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AprobacionDirector" HeaderText="Aprobacion" SortExpression="AprobacionDirector">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaAprobacionDirector" HeaderText="Fecha" SortExpression="FechaAprobacionDirector" DataFormatString="{0:d}">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Visita" HeaderText="Visita" SortExpression="Visita">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
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

                                <asp:CommandField AccessibleHeaderText="Certificado" HeaderText="Imprimir Certificado" ButtonType="Image" SelectImageUrl="~/img/pdf.png" ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle BorderStyle="Solid" BorderWidth="2px" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSSolicitudesPorRut" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerSolicitudesPorRut" TypeName="Dideco.BLL.SolicitudesBLL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtRut" Name="rut" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </fieldset>
                    <br />
                    <fieldset>
                        <legend>Estadisticas</legend>

                        <div style="width: 400px; float: left">
                            <br />
                            <span>Estado y cantidad de solicitudes realizadas por:
                    <br />
                                <asp:Label ID="LblBeneficiario" runat="server" Text=""></asp:Label><br />
                            </span>
                            <br />
                            <div align="center">
                                <asp:GridView ID="GvEstadisticas" runat="server" AutoGenerateColumns="False" DataSourceID="ODSGraficosPorRut">
                                    <Columns>
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div style="margin-left: 10%; float: left">
                            <asp:Chart ID="Grafico" runat="server" DataSourceID="ODSGraficosPorRut">
                                <Series>
                                    <asp:Series Name="Series1" ChartType="Bar" XValueMember="Estado" YValueMembers="Cantidad">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                        <Area3DStyle Enable3D="True" />
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                            <asp:ObjectDataSource ID="ODSGraficosPorRut" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerEstadisticasPorRut" TypeName="Dideco.BLL.EstadisticasBLL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="TxtRut" Name="rut" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>


                    </fieldset>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                    <fieldset>
                        <legend>Solicitudes</legend>

                        <asp:Label ID="Label2" runat="server" Text="No existen solicitudes para dicho rut"></asp:Label>

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
