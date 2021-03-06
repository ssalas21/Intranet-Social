<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSeguroComplementario.aspx.cs" Inherits="Dideco.DirectorAreaOperativa.AgregarSeguroComplementario" %>

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
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
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
                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Charts">
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
                <h2>¿Que vehículo contratara un seguro complementario?</h2>
                <br />
                <asp:Label ID="LblSuccess" runat="server" CssClass="alert-success"></asp:Label>
                <asp:Label ID="LblWarning" runat="server" Text="" CssClass="alert-warning"></asp:Label>
                <!-- Icon Cards -->
                <table style="width: 100%; align-content: center;">
                    <tr>
                        <td>
                            <asp:Panel ID="PanelVehiculo" runat="server">
                                <fieldset>
                                    <legend>Seleccione el vehículo</legend>
                                    <asp:GridView ID="GvVehiculos" runat="server" DataSourceID="ODSVehiculo" AutoGenerateColumns="False" DataKeyNames="Placa" OnSelectedIndexChanged="GvVehiculos_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa"></asp:BoundField>
                                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo"></asp:BoundField>
                                            <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca"></asp:BoundField>
                                            <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo"></asp:BoundField>
                                            <asp:BoundField DataField="Anno" HeaderText="Año" SortExpression="Anno"></asp:BoundField>
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/elegir.png" ShowSelectButton="True"></asp:CommandField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:ObjectDataSource ID="ODSVehiculo" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerVehiculos" TypeName="Dideco.BLL.VehiculosBLL"></asp:ObjectDataSource>
                                </fieldset>
                            </asp:Panel>
                        </td>
                    </tr>
                    </table>
                    <asp:Panel ID="PanelSeguros" runat="server" Visible="false">    
                        <table style="width: 100%; align-content: center;">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend>Agregar Seguro Complementario a vehículo placa <asp:Label ID="LblPlaca" runat="server" Text=""></asp:Label></legend>
                                    <table style="width: 100%; align-content: center;">
                                        <tr>
                                            <td>Fecha Inicio (dia/mes/año)</td>
                                            <td>
                                                <asp:TextBox ID="TxtFechaInicio" runat="server" TextMode="Date"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Fecha Termino (dia/mes/año)</td>
                                            <td><asp:TextBox ID="TxtFechaTermino" runat="server" TextMode="Date"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Adjunto</td>
                                            <td>
                                                <asp:FileUpload ID="FileUploadAdjunto" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:Button ID="BtnAgregarSeguro" runat="server" Text="Agregar Seguro" OnClick="BtnAgregarSeguro_Click" /></td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        </table>
                                <asp:GridView ID="GvSeguros" runat="server" AutoGenerateColumns="False" DataSourceID="ODSSeguros" OnSelectedIndexChanged="GvSeguros_SelectedIndexChanged" DataKeyNames="IdSeguro">
                                    <Columns>
                                        <asp:BoundField DataField="IdSeguro" HeaderText="Id de Seguro" SortExpression="IdSeguro"></asp:BoundField>
                                        <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa"></asp:BoundField>
                                        <asp:BoundField DataField="FechaInicio" DataFormatString="{0:d}" HeaderText="Fecha de Inicio" SortExpression="FechaInicio"></asp:BoundField>
                                        <asp:BoundField DataField="FechaTermino" DataFormatString="{0:d}" HeaderText="Fecha de Termino" SortExpression="FechaTermino"></asp:BoundField>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/elegir.png" ShowSelectButton="True"></asp:CommandField>
                                    </Columns>
                        </asp:GridView>
                            
                        
                        <asp:ObjectDataSource ID="ODSSeguros" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerSegurosPorPlaca" TypeName="Dideco.BLL.SegurosComplementariosBLL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="GvVehiculos" Name="placa" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                            
                        
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
