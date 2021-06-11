<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticasMotivo.aspx.cs" Inherits="Dideco.DirectorAreaOperativa.EstadisticasMotivo1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
    <link href="vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet"/>

    <!-- Custom styles for this template -->
    <link href="css/sb-admin.css" rel="stylesheet"/>
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

            <br /><br /><br />
    <h2>Bienvenido
        
        <asp:Label ID="LblUsuario2" runat="server"></asp:Label>
        &nbsp;<asp:Label ID="LblUsuario" runat="server" Visible="False"></asp:Label>
        &nbsp;||&nbsp;<asp:LoginStatus ID="LoginStatus2" runat="server" LogoutText="Cerrar sesión" />
        &nbsp;|| <a href="Index.aspx">
            <button type="button" class="btn btn-default">Volver atras</button></a>
    </h2>
    <br />
    <fieldset>
        <legend>Solicitudes por motivo</legend>
        <br />
        <table border="0">
            <tr>
                <td>Seleccione Motivo</td>   
                <td>&nbsp;&nbsp;:&nbsp;&nbsp;</td>             
                <td>
                    <asp:DropDownList ID="DdlMotivos" runat="server" Width="400px" AutoPostBack="True">
                        <asp:ListItem Value="0">VIVIENDA</asp:ListItem>
                        <asp:ListItem Value="1">ALIMENTACION</asp:ListItem>
                        <asp:ListItem Value="2">SALUD</asp:ListItem>
                        <asp:ListItem Value="3">INFANCIA</asp:ListItem>
                        <asp:ListItem Value="4">DEFUNCIONES</asp:ListItem>
                        <asp:ListItem Value="5">MICROEMPRENDIMIENTO</asp:ListItem>
                        <asp:ListItem Value="6">PROG. SOC. GUBERNAMENTAL</asp:ListItem>
                        <asp:ListItem Value="7">MAQUINARIA</asp:ListItem>
                        <asp:ListItem Value="8">PERSONAL MUNICIPAL</asp:ListItem>
                        <asp:ListItem Value="9">REBAJA ASEO</asp:ListItem>
                        <asp:ListItem Value="10">ENTREGA DE AGUA</asp:ListItem>
                        <asp:ListItem Value="11">OTROS</asp:ListItem>
                    </asp:DropDownList></td>
                
            </tr>
            <tr>                
                <td>Elija fecha inicial</td>
                <td>&nbsp;&nbsp;:&nbsp;&nbsp;</td>             
                <td>
                    <asp:Calendar ID="FechaInicial" runat="server" SelectedDate="07/14/2017 16:59:41" Width="400px"></asp:Calendar>
                </td>                
            </tr>
            <tr>
                <td>Elija fecha final</td>
                <td>&nbsp;&nbsp;:&nbsp;&nbsp;</td>             
                <td>
                    <asp:Calendar ID="FechaFinal" runat="server" SelectedDate="07/14/2017 16:59:51" Width="400px"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td style="align-content:center"></br></td>
                <td style="align-content:center"></br></td>
                <td style="align-content:center"></br></td>
            </tr>           
        </table>
    </fieldset>

    <asp:Panel ID="PanelResultados" runat="server" Visible="True">
        <br />        
        <br />
        <fieldset>
            <legend><h3>Estadisticas</h3></legend>
            <fieldset>
                <legend>Aprobacion, rechazos y pendientes</legend>
                <div style="float: left; width: 300px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ODSCantidades">
                        <Columns>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ODSCantidades" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerEstadisticasPorMotivo" TypeName="Dideco.BLL.EstadisticasBLL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="FechaInicial" Name="inicial" PropertyName="SelectedDate" Type="DateTime" />
                            <asp:ControlParameter ControlID="FechaFinal" Name="final" PropertyName="SelectedDate" Type="DateTime" />
                            <asp:ControlParameter ControlID="DdlMotivos" Name="motivo" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
                <div style="float: left">
                    <asp:Chart ID="Chart1" runat="server" Width="600px" DataSourceID="ODSCantidades">
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
                </div>
            </fieldset>

            <fieldset>
                <legend>Estadistica porcentual</legend>

                <div style="float: left; width: 300px">
                    <asp:GridView ID="GvPorcentaje" runat="server" AutoGenerateColumns="False" DataSourceID="ODSPorcentajes" >
                        <Columns>
                            <asp:BoundField DataField="Estado" HeaderText="Nombre" SortExpression="Estado" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Porcentaje" SortExpression="Cantidad" DataFormatString="{0:0.0}%" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ODSPorcentajes" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerEstadisticasGlobalesPorMotivo" TypeName="Dideco.BLL.EstadisticasBLL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="FechaInicial" Name="inicial" PropertyName="SelectedDate" Type="DateTime" />
                            <asp:ControlParameter ControlID="FechaFinal" Name="final" PropertyName="SelectedDate" Type="DateTime" />
                            <asp:ControlParameter ControlID="DdlMotivos" Name="motivo" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
                <div style="float: left">
                    <asp:Chart ID="Chart2" runat="server"  Width="600px" DataSourceID="ODSPorcentajes">
                        <Series>
                            <asp:Series ChartType="Pie" Name="Series1" XValueMember="Estado" YValueMembers="Cantidad">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
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
