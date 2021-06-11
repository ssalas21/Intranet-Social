<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadoAudiencia.aspx.cs" Inherits="Dideco.Alcalde.EstadoAudiencia" %>

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
    <script src="js/Chart.min.js"></script>

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
                        <a class="nav-link" href="AtenderAudiencia.aspx">
                            <i class="fa fa-fw fa-table"></i>
                            <span class="nav-link-text">Atender Audiencia</span>
                        </a>
                    </li>
                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="EstadoAudiencia.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Estado de Audiencias</span>
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
                <!-- Icon Cards -->
                <asp:Panel ID="PanelBusqueda" runat="server">
                    <fieldset>
                        <legend>Seleccione el beneficiario</legend>
                        <table style="width: 100%;">
                            <tr>
                                <td>Ingrese nombre o rut</td>
                                <td>
                                    <asp:TextBox ID="TxtNombre" runat="server" AutoPostBack="True"></asp:TextBox></td>
                                <td>
                                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" /></td>
                            </tr>
                        </table>
                        <asp:GridView ID="GvBeneficiarios" runat="server" AutoGenerateColumns="False" DataSourceID="ODSBeneficiarios" DataKeyNames="Rut" Width="100%" OnSelectedIndexChanged="GvBeneficiarios_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Rut" HeaderText="Rut" SortExpression="Rut" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                <asp:BoundField DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/elegir.png" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSBeneficiarios" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ListarBeneficiarios" TypeName="Dideco.BLL.BeneficiarioBLL"></asp:ObjectDataSource>
                    </fieldset>
                </asp:Panel>
                <asp:Panel ID="PanelAudiencias" runat="server" Visible="false">
                    <asp:GridView ID="GvAudiencias" runat="server" AutoGenerateColumns="False" DataSourceID="ODSAudiencias" DataKeyNames="IdAudiencias" Width="100%" OnSelectedIndexChanged="GvAudiencias_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="IdAudiencias" HeaderText="Id" SortExpression="IdAudiencias" />
                            <asp:BoundField DataField="FechaAudiencia" DataFormatString="{0:d}" HeaderText="Fecha Audiencia" SortExpression="FechaAudiencia" />
                            <asp:BoundField DataField="FechaAudiencia" DataFormatString="{0:hh:mm tt}" HeaderText="Horario" />
                            <asp:BoundField DataField="Solicitud" HeaderText="Solicitud" SortExpression="Solicitud" />
                            <asp:BoundField DataField="FechaSolucion" DataFormatString="{0:d}" HeaderText="Fecha Solucion" SortExpression="FechaSolucion" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/pdf.png" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ODSAudiencias" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerAudienciasPorRut" TypeName="Dideco.BLL.AudienciasBLL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="GvBeneficiarios" Name="rut" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                    <!-- // Estadisticas -->
                    <br />
                    <canvas id="myChart" width="1200" height="600"></canvas>
                    <script>
                        // Our labels along the x-axis
                        var years = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
                        // For drawing the lines
                        var pendiente = <%=pendiente%>;
                        var solucionada = <%=solucionada%>;
                        var atendida = <%=atendida%>;
                        var ctx = document.getElementById("myChart");
                        var myChart = new Chart(ctx, {
                            type: 'line',
                            data: {
                                labels: years,
                                datasets: [
                                  {
                                      data: pendiente,
                                      label: "Solicitadas",
                                      backgroundColor: "#99ff8c",
                                      borderColor: "#99ff8c",
                                      fill: false
                                  },
                                  {
                                      data: solucionada,
                                      label: "Solucionada",
                                      backgroundColor: "#FF0000",
                                      borderColor: "#FF0000",
                                      fill: false
                                  },
                                  {
                                      data: atendida,
                                      label: "Atendida",
                                      backgroundColor: "#09F8FF",
                                      borderColor: "#09F8FF",
                                      fill: false
                                  }                                  
                                ]
                            }
                        });
                    </script>
                    <br />


                    <!-- // Cierre de panel -->

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
