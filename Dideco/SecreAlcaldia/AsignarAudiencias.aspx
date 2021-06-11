<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarAudiencias.aspx.cs" Inherits="Dideco.SecreAlcaldia.AsignarAudiencias" %>

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
                        <a class="nav-link" href="AgregarAudiencia.aspx">
                            <i class="fa fa-fw fa-table"></i>
                            <span class="nav-link-text">Agregar Audiencia</span>
                        </a>
                    </li>
                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="AsignarAudiencias.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Asignar Audiencias</span>
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
                <asp:Panel ID="PanelAudiencias" runat="server">
                    <asp:Label ID="LblResult" runat="server" Text=""></asp:Label>
                    <asp:GridView ID="GvAudiencieas" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSAudiencias" OnSelectedIndexChanged="GvAudiencieas_SelectedIndexChanged" DataKeyNames="IdAudiencias">
                        <Columns>
                            <asp:BoundField DataField="IdAudiencias" HeaderText="Id Audiencias" SortExpression="IdAudiencias" />
                            <asp:BoundField DataField="RutBeneficiario" HeaderText="Rut Beneficiario" SortExpression="RutBeneficiario" />
                            <asp:BoundField DataField="Beneficiario.Nombre" HeaderText="Nombre" SortExpression="FechaAudiencia" />
                            <asp:BoundField DataField="Solicitud" HeaderText="Solicitud" SortExpression="Solicitud" />
                            <asp:BoundField DataField="Beneficiario.Contacto" HeaderText="Contacto" />
                            <asp:BoundField DataField="FechaSolicitudAudiencia" DataFormatString="{0:d}" HeaderText="Fecha Solicitud Audiencia" SortExpression="FechaSolicitudAudiencia" />
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/elegir.png" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ODSAudiencias" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerAudienciasSinAsignar" TypeName="Dideco.BLL.AudienciasBLL"></asp:ObjectDataSource>
                </asp:Panel>
                <asp:Panel ID="PanelAsignar" runat="server" Visible="false">
                <div>
                    Seleccione día para asignar
                    <asp:Label ID="LblAux" runat="server" Visible="False"></asp:Label>
                    <br />
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="400px" NextPrevFormat="FullMonth" Width="950px" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </div>
                </asp:Panel>
                <asp:Panel ID="PanelHorario" runat="server" Visible="false">
                    <br />            
                    <asp:Label ID="LblError" runat="server" Text=""></asp:Label>    
                    <table>
                        <tr>
                            <td>Audiencias del día</td>
                            <td>Horario que desea asignar</td>
                            </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblFecha" runat="server" Text="" Visible="false"></asp:Label>
                                <br />
                                <asp:Label ID="LblHorarios" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlHorario" runat="server">
                                    <asp:ListItem>08:00</asp:ListItem>
                                    <asp:ListItem>08:30</asp:ListItem>
                                    <asp:ListItem>09:00</asp:ListItem>
                                    <asp:ListItem>09:30</asp:ListItem>
                                    <asp:ListItem>10:00</asp:ListItem>
                                    <asp:ListItem>10:30</asp:ListItem>
                                    <asp:ListItem>11:00</asp:ListItem>
                                    <asp:ListItem>11:30</asp:ListItem>
                                    <asp:ListItem>12:00</asp:ListItem>
                                    <asp:ListItem>12:30</asp:ListItem>
                                    <asp:ListItem>13:00</asp:ListItem>
                                    <asp:ListItem>13:30</asp:ListItem>
                                    <asp:ListItem>14:00</asp:ListItem>
                                    <asp:ListItem>14:30</asp:ListItem>
                                    <asp:ListItem>15:00</asp:ListItem>
                                    <asp:ListItem>15:30</asp:ListItem>
                                    <asp:ListItem>16:00</asp:ListItem>
                                    <asp:ListItem>16:30</asp:ListItem>
                                    <asp:ListItem>17:00</asp:ListItem>
                                    <asp:ListItem>17:30</asp:ListItem>
                                    <asp:ListItem>18:00</asp:ListItem>
                                    <asp:ListItem>18:30</asp:ListItem>
                                    <asp:ListItem>19:00</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="BtnAsignar" runat="server" Text="Asignar" OnClick="BtnAsignar_Click" /></td>                            
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