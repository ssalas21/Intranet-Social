<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContratosVigentes.aspx.cs" Inherits="Dideco.DirectorAreaOperativa.ContratosVigentes" %>

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
                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Charts">
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
                <!-- Icon Cards -->
                

                
                <h2>Ver Contrato - Agregar Gasto</h2>
                <br />
                    <asp:Panel ID="PanelContratos" runat="server">
                        <p>Seleccione contrato </p>
                        <asp:GridView ID="GvContratos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdContrato" DataSourceID="ODSContratos" OnSelectedIndexChanged="GvContratos_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                <asp:BoundField DataField="FechaInicio" DataFormatString="{0:d}" HeaderText="Fecha de Inicio" SortExpression="FechaInicio" />
                                <asp:BoundField DataField="FechaExpiracion" DataFormatString="{0:d}" HeaderText="Fecha de Expiracion" SortExpression="FechaExpiracion" />
                                <asp:BoundField DataField="Monto" HeaderText="Monto" SortExpression="Monto" DataFormatString="${0:N0}" />
                                <asp:BoundField DataField="Gastos" HeaderText="Gastos" SortExpression="Gastos" DataFormatString="${0:N0}" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/elegir.png" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSContratos" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerContratosVigentes" TypeName="Dideco.BLL.ContratosOperativaBLL"></asp:ObjectDataSource>
                    </asp:Panel>
                <asp:Label ID="Label1" runat="server" Text="" CssClass="alert"></asp:Label>
                <br />
                <asp:Panel ID="PanelModificar" runat="server" Visible="false">
                <table style="width: 100%; align-content: center;">
                    <tr>
                        <td>Nombre</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="TxtNombre" runat="server" Width="400px" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Detalle</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="TxtDetalle" runat="server" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Fecha de inicio (dia/mes/año)</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="TxtFechaInicio" runat="server" Width="400px" ReadOnly="true"></asp:TextBox></td>
                        </td>
                    </tr>
                    <tr>
                        <td>Fecha de expiracion (dia/mes/año)</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="TxtFechaExpiracion" runat="server" Width="400px"></asp:TextBox></td>
                        </td>
                    </tr>
                    <tr>
                        <td>Monto</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="TxtMonto" runat="server" Width="400px" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Agregar Gasto</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="TxtMontoSuma" runat="server" TextMode="Number" Width="400px">0</asp:TextBox></td>
                    </tr>   
                    <tr>
                        <td>Detalle del gasto</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="TxtDetalleGasto" runat="server" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox></td>
                    </tr>                 
                    <tr>
                        <td> Gastos realizados </td>                            
                        <td></td>
                        <td>
                            <asp:GridView ID="GvGastosContratos" runat="server" AutoGenerateColumns="False" DataSourceID="ODSGastos">
                                <Columns>
                                    <asp:BoundField DataField="Detalle" HeaderText="Detalle" SortExpression="Detalle" />
                                    <asp:BoundField DataField="Gasto" HeaderText="Gasto" SortExpression="Gasto" />
                                </Columns>
                            </asp:GridView>                            
                            <asp:ObjectDataSource ID="ODSGastos" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerListadoGastos" TypeName="Dideco.BLL.GastosContratosBLL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="GvContratos" Name="idContrato" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:Button ID="BtnDescargar" runat="server" Text="Descargar adjunto" OnClick="BtnDescargar_Click" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="BtnModificarContrato" runat="server" Text="Agregar Gasto" OnClick="BtnAgregarContrato_Click" /></td>
                        <td></td>
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
                </table>
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
