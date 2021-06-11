<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticasLocalidad.aspx.cs" Inherits="Dideco.DirectorAreaOperativa.EstadisticasLocalidad" %>

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
                <h2>Bienvenid@
        
        <asp:Label ID="LblUsuario2" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="LblUsuario" runat="server" Visible="False"></asp:Label>
                    &nbsp;|| <a href="Index.aspx">
                        <button type="button" class="btn btn-default">Volver atras</button></a>
                </h2>
                <br />
                <fieldset>
                    <legend>Solicitudes por localidad</legend>
                    <br />
                    <table border="0">
                        <tr>
                            <td><span>Seleccione un localidad</span></td>
                            <td>&nbsp;&nbsp;:&nbsp;&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="DdlMotivos" runat="server" DataTextField="Motivo" DataValueField="IdMotivo" AutoPostBack="True" Style="margin-left: 20px">
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
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Elija fecha inicial</td>
                            <td>&nbsp;&nbsp;:&nbsp;&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TxtFechaInicial" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Elija fecha final</td>
                            <td>&nbsp;&nbsp;:&nbsp;&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TxtFechaFinal" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="align-content: center"></br></td>
                            <td style="align-content: center">
                                <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" /></td>
                            <td style="align-content: center"></br></td>
                        </tr>
                    </table>
                </fieldset>

                <asp:Panel ID="PanelResultados" runat="server" Visible="True">
                    <br />
                    <fieldset>
                        <legend>Solicitudes</legend>
                        <div style="float: left; width: 300px">
                            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="ODSTotales">
                                <Columns>
                                    <asp:BoundField DataField="Estado" HeaderText="Motivo" SortExpression="Estado" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ODSTotales" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerEstadisticasPorLocalidadTotalidad" TypeName="Dideco.BLL.EstadisticasBLL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DdlMotivos" Name="localidad" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="TxtFechaInicial" Name="inicio" PropertyName="Text" Type="DateTime" />
                                    <asp:ControlParameter ControlID="TxtFechaFinal" Name="fin" PropertyName="Text" Type="DateTime" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                        <div style="float: left">
                            <asp:Chart ID="Chart4" runat="server" DataSourceID="ODSTotales" Height="400px" Width="800px">
                                <Series>
                                    <asp:Series Name="Series1" XValueMember="Estado" YValueMembers="Cantidad">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                        <AxisX Interval="1">
                                        </AxisX>
                                        <Area3DStyle Enable3D="True" />
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>

                        </div>
                    </fieldset>
                    <br />
                    <fieldset>
                        <legend>
                            <h3>Estadisticas</h3>
                        </legend>

                        <fieldset>
                            <legend>Aprobados</legend>
                            <div style="float: left; width: 300px">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ODSAprobados">
                                    <Columns>
                                        <asp:BoundField DataField="Estado" HeaderText="Motivo" SortExpression="Estado" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="ODSAprobados" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerEstadisticasPorLocalidadAprobados" TypeName="Dideco.BLL.EstadisticasBLL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlMotivos" Name="localidad" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="TxtFechaInicial" Name="inicio" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="TxtFechaFinal" Name="fin" PropertyName="Text" Type="DateTime" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                            <div style="float: left">
                                <asp:Chart ID="Chart3" runat="server" DataSourceID="ODSAprobados" Height="400px" Width="800px">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="Estado" YValueMembers="Cantidad">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisX Interval="1">
                                            </AxisX>
                                            <Area3DStyle Enable3D="True" />
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>

                            </div>
                        </fieldset>
                        <fieldset>
                            <legend>Rechazados</legend>
                            <div style="float: left; width: 300px">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ODSRechazados">
                                    <Columns>
                                        <asp:BoundField DataField="Estado" HeaderText="Motivo" SortExpression="Estado" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="ODSRechazados" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerEstadisticasPorLocalidadRechazados" TypeName="Dideco.BLL.EstadisticasBLL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlMotivos" Name="localidad" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="TxtFechaInicial" Name="inicio" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="TxtFechaFinal" Name="fin" PropertyName="Text" Type="DateTime" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                            <div style="float: left">
                                <asp:Chart ID="Chart1" runat="server" DataSourceID="ODSRechazados" Height="400px" Width="800px">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="Estado" YValueMembers="Cantidad">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisX Interval="1">
                                            </AxisX>
                                            <Area3DStyle Enable3D="True" />
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>

                            </div>
                        </fieldset>
                        <fieldset>
                            <legend>Pendientes</legend>
                            <div style="float: left; width: 300px">
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="ODSPendientes">
                                    <Columns>
                                        <asp:BoundField DataField="Estado" HeaderText="Motivo" SortExpression="Estado" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="ODSPendientes" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerEstadisticasPorLocalidadPendientes" TypeName="Dideco.BLL.EstadisticasBLL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlMotivos" Name="localidad" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="TxtFechaInicial" Name="inicio" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="TxtFechaFinal" Name="fin" PropertyName="Text" Type="DateTime" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                            <div style="float: left">
                                <asp:Chart ID="Chart2" runat="server" DataSourceID="ODSPendientes" Height="400px" Width="800px">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="Estado" YValueMembers="Cantidad">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisX Interval="1">
                                            </AxisX>
                                            <Area3DStyle Enable3D="True" />
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>

                            </div>
                        </fieldset>
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
