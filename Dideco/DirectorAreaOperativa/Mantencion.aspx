<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mantencion.aspx.cs" Inherits="Dideco.DirectorAreaOperativa.Mantencion" %>

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

                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="SolicitudesAlcaldia.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Solicitudes alcaldia</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="Vehiculos.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Vehiculos</span>
                        </a>
                    </li>
                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="Mantencion.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Mantenciones</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="Contratos.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Contratos</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="SegurosComplementariosMenu.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Seguros complementarios</span>
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
                <br />
                <br />
                <h2>Seleccione el vehiculo para agregar uso</h2>
                <br />
                <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                <!-- Icon Cards -->
                <asp:Panel ID="PanelVehiculos" runat="server" Visible="true">
                    <fieldset>
                        <legend>Permisos de circulación</legend>
                        <p>Vehículos que se encuentran con el permiso de circulación vencido o a punto de vencer</p>
                        <asp:GridView ID="GvPermisos" runat="server" AutoGenerateColumns="False" DataSourceID="ODSCirculacion" DataKeyNames="Placa" OnSelectedIndexChanged="GvPermisos_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" />
                                <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
                                <asp:BoundField DataField="Anno" HeaderText="Año" SortExpression="Anno" />
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                                <asp:BoundField DataField="FechaRevision" DataFormatString="{0:d}" HeaderText="Fecha de Revision" SortExpression="FechaRevision" />
                                <asp:BoundField DataField="ProximaMantencion" HeaderText="Proxima Mantencion" SortExpression="ProximaMantencion" />
                                <asp:BoundField DataField="FechaPermiso" DataFormatString="{0:d}" HeaderText="Fecha de Permiso" SortExpression="FechaPermiso" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/elegir.png" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSCirculacion" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="PermisoExpirando" TypeName="Dideco.BLL.VehiculosBLL"></asp:ObjectDataSource>
                    </fieldset>
                    <fieldset>
                        <legend>Mantenciones</legend>
                        <p>Vehículos que necesitan su mantención dentro de poco</p>
                        <asp:GridView ID="GvProximaMantencion" runat="server" AutoGenerateColumns="False" DataSourceID="ODSProximaMantencion" DataKeyNames="Placa" OnSelectedIndexChanged="GvProximaMantencion_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" />
                                <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
                                <asp:BoundField DataField="Anno" HeaderText="Año" SortExpression="Anno" />
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                                <asp:BoundField DataField="Uso" HeaderText="Uso (KM o HR)" SortExpression="Uso" />
                                <asp:BoundField DataField="Restante" HeaderText="Restante de uso (KM ó HR)"></asp:BoundField>
                                <asp:BoundField DataField="ProximaMantencion" HeaderText="Proxima Mantencion (KM o HR)" SortExpression="ProximaMantencion" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/elegir.png" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSProximaMantencion" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ProximaMantencion" TypeName="Dideco.BLL.VehiculosBLL"></asp:ObjectDataSource>
                    </fieldset>

                    <fieldset>
                        <legend>Revisión tecnica</legend>
                        <p>Vehículos que se encuentran con la revisión tecnica vencida o a punto de vencer.</p>
                        <asp:GridView ID="GvRevisionesProximas" runat="server" AutoGenerateColumns="False" DataSourceID="ODSProximaRevision" DataKeyNames="Placa" OnSelectedIndexChanged="GvRevisionesProximas_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" />
                                <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
                                <asp:BoundField DataField="Anno" HeaderText="Año" SortExpression="Anno" />
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                                <asp:BoundField DataField="FechaRevision" DataFormatString="{0:d}" HeaderText="Fecha de Revision" SortExpression="FechaRevision" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/elegir.png" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSProximaRevision" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="RevisionExpirando" TypeName="Dideco.BLL.VehiculosBLL"></asp:ObjectDataSource>
                    </fieldset>

                    <fieldset>
                        <legend>Reparaciones</legend>
                        <p>Seleccione un vehículo para realizar una reparación</p>
                        <asp:GridView ID="GvReparaciones" runat="server" AutoGenerateColumns="False" DataKeyNames="Placa" DataSourceID="ODSVehiculos" OnSelectedIndexChanged="GvReparaciones_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" />
                                <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
                                <asp:BoundField DataField="Anno" HeaderText="Año" SortExpression="Anno" />
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/elegir.png" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSVehiculos" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerVehiculos" TypeName="Dideco.BLL.VehiculosBLL"></asp:ObjectDataSource>
                    </fieldset>
                </asp:Panel>
                <asp:Panel ID="PanelMantenciones" runat="server" Visible="false">
                    <fieldset>
                        <legend>Agregar Mantención a
                            <asp:Label ID="LblPlacaMantencion" runat="server" Text=""></asp:Label></legend>
                        <table style="width: 100%; align-content: center">
                            <tr>
                                <td>Detalle</td>
                                <td>
                                    <asp:TextBox ID="TxtDetalleMantencion" runat="server" Height="200px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Proxima mantención a los KM" Visible="false"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="TxtProximaMantencion" runat="server" Visible="False" TextMode="Number"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Adjunto</td>
                                <td>
                                    <asp:FileUpload ID="FileUploadMantencion" runat="server" /></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="BtnAgregarMantencion" runat="server" Text="Agregar Mantención" OnClick="BtnAgregarMantencion_Click" /></td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
                <asp:Panel ID="PanelRevisiones" runat="server" Visible="false">
                    <fieldset>
                        <legend>Agregar Revisión a
                            <asp:Label ID="LblPlacaRevision" runat="server" Text=""></asp:Label></legend>
                        <table style="width: 100%; align-content: center">
                            <tr>
                                <td>Proxima revisión (dia/mes/año)</td>
                                <td>
                                    <asp:TextBox ID="TxtProximaRevision" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="BtnAgregarRevision" runat="server" Text="Agregar Revision Tecnica" OnClick="BtnAgregarRevision_Click" /></td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
                <asp:Panel ID="PanelReparaciones" runat="server" Visible="false">
                    <fieldset>
                        <legend>Agregar Reparación a
                            <asp:Label ID="LblPlacaReparacion" runat="server" Text=""></asp:Label></legend>
                        <table style="width: 100%; align-content: center">
                            <tr>
                                <td>Detalle</td>
                                <td>
                                    <asp:TextBox ID="TxtDetalleReparacion" runat="server" Height="200px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Adjunto</td>
                                <td>
                                    <asp:FileUpload ID="FileUploadReparacion" runat="server" /></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="BtnReparacion" runat="server" Text="Agregar reparación" OnClick="BtnReparacion_Click" /></td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
                <asp:Panel ID="PanelPermisos" runat="server" Visible="false">
                    <fieldset>
                        <legend>Actualizar permiso de circulación del vehículo <asp:Label ID="LblPlacaPermiso" runat="server" Text=""></asp:Label></legend>
                        <table>
                            <tr>
                                <td>Fecha de vencimiento (dia/mes/año)</td>
                                <td>
                                    <asp:TextBox ID="TxtFechaPermiso" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="BtnPermiso" runat="server" Text="Actualizar permiso" OnClick="BtnPermiso_Click" /></td>
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
