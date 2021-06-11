<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudesPendientesAsistente.aspx.cs" Inherits="Dideco.Asistente.SolicitudesPendientesAsistente" %>

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

                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Tables">
                        <a class="nav-link" href="SolicitudesPendientesAsistente.aspx">
                            <i class="fa fa-fw fa-table"></i>
                            <span class="nav-link-text">Aprobar Solicitudes</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
                        <a class="nav-link" href="SolicitudesPorRutAsistente.aspx">
                            <i class="fa fa-fw fa-area-chart"></i>
                            <span class="nav-link-text">Solicitudes por rut</span>
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
    <h2>Bienvenid@
        
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
            <asp:GridView ID="GvSolicitudesPendientes" runat="server" AutoGenerateColumns="False" DataSourceID="ODSSolicitudes" CssClass="bg-info" OnSelectedIndexChanged="GvSolicitudesPendientes_SelectedIndexChanged" AllowPaging="True" CellPadding="2" CellSpacing="2" DataKeyNames="IdSolicitud">
                <Columns>
                    <asp:BoundField DataField="IdSolicitud" HeaderText="Folio" SortExpression="IdSolicitud" />
                    <asp:BoundField DataField="Beneficiario.Nombre" HeaderText="Beneficiario" SortExpression="RutBeneficiario" />
                    <asp:BoundField DataField="FechaSolicitud" DataFormatString="{0:d}" HeaderText="FechaSolicitud" SortExpression="FechaSolicitud" />
                    <asp:TemplateField HeaderText="Registro Social de Hogares" SortExpression="RegistroSocialHogar">
                        <ItemTemplate>
                            <%# Boolean.Parse(Eval("RegistroSocialHogar").ToString()) ? "Si" : "No" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" SelectImageUrl="~/img/elegir.png" HeaderText="Revisar solicitud" ButtonType="Image" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ODSSolicitudes" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerSolicitudesPorAsistentePendientes" TypeName="Dideco.BLL.SolicitudesBLL">
                <SelectParameters>
                    <asp:ControlParameter ControlID="LblUsuario" DefaultValue="" Name="user" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </fieldset>
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelAprobaciones" runat="server" Visible="False">
        <fieldset>
            <legend>Solicitud</legend>
            <table border="0" style="margin-top: 20px">
                <tr>
                    <td>Rut del beneficiario</td>
                    <td>
                        <asp:Label ID="LblId" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtRut" ReadOnly="true" runat="server" Width="340px"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>Nombre</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TxtNombre" ReadOnly="true" runat="server" Width="340px"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>Dirección</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TxtDireccion" ReadOnly="true" runat="server" Width="340px"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>Contacto</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TxtContacto" ReadOnly="true" runat="server" Width="340px"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>Localidad</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TxtLocalidad" ReadOnly="true" runat="server" Width="340px"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>Motivo</td>
                    <td></td>
                    <td class="text-left">
                    <asp:CheckBox ID="ChkVivienda" runat="server" Text="Vivienda" />
                    <br />
                    <asp:CheckBox ID="ChkAlimentacion" runat="server" Text="Alimentación" />
                    <br />
                    <asp:CheckBox ID="ChkSalud" runat="server" Text="Salud" />
                    <br />
                    <asp:CheckBox ID="ChkInfancia" runat="server" Text="Infancia" />
                    <br />
                    <asp:CheckBox ID="ChkDefunciones" runat="server" Text="Defunciones" />
                    <br />
                    <asp:CheckBox ID="ChkMicroemprendimiento" runat="server" Text="Microemprendimiento" />
                    <br />
                    <asp:CheckBox ID="ChkPSGubernamental" runat="server" Text="Prog. Soc. Gubernamental" />
                    <br />
                    <asp:CheckBox ID="ChkMaquinaria" runat="server" Text="Maquinaria" />
                    <br />
                    <asp:CheckBox ID="ChkPersonalMunicipal" runat="server" Text="Personal Municipal" />
                    <br />
                    <asp:CheckBox ID="ChkRebajaAseo" runat="server" Text="Rebaja Aseo" />
                    <br />
                    <asp:CheckBox ID="ChkAgua" runat="server" Text="Entrega de Agua" />
                    <br />
                    <asp:CheckBox ID="ChkOtros" runat="server" Text="Otros" />
                </td>
                </tr>
                <tr>
                    <td>¿Pertenece al registro social de hogares?</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TxtRGH" ReadOnly="true" runat="server" Width="340px"></asp:TextBox>
                        <br />
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
                    <td>
                        <asp:TextBox ID="TxtDetalle" runat="server" TextMode="MultiLine" Width="402px" Height="97px"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>¿Se necesita visita?</td>
                    <td></td>
                    <td>
                        <asp:DropDownList ID="DdlVisita" runat="server" Width="240" AutoPostBack="True" OnSelectedIndexChanged="DdlVisita_SelectedIndexChanged">
                            <asp:ListItem Value="NO">NO</asp:ListItem>
                            <asp:ListItem Value="SI">SI</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td><br /></td>
                    <td><br /></td>
                    <td>
                        <asp:Calendar ID="CVisita" runat="server" Height="196px" SelectedDate="07/05/2017 15:19:16" Visible="False" Width="416px"></asp:Calendar>
                    </td>
                </tr>
                
                <tr>
                    <td><br /></td>
                    <td><br /></td>
                    <td><br /></td>
                </tr>
                <tr>
                    <td>Situación familiar y socioeconomica del solicitante</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TxtSituacion" runat="server" TextMode="MultiLine" Width="400px" Height="300px"></asp:TextBox></td>
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
                        <asp:Button ID="BtnImprimir" runat="server" Text="Actualizar Solicitud" OnClick="BtnImprimir_Click" /></td>
                    <td>
                        <asp:Button ID="BtnAprobarSolicitud" runat="server" Text="Aprobar Solicitud" CssClass="btn-success" OnClick="BtnAprobarSolicitud_Click" /></td>
                    <td>
                        <asp:Button ID="BtnRechazarSolicitud" runat="server" Text="Rechazar Solicitud" CssClass="btn-warning" OnClick="BtnRechazarSolicitud_Click" /></td>
                </tr>
                <tr>
                    <td><br /></td>
                    <td><br /></td>
                    <td><br /></td>
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
        <script src="js/sb-admin.js"></script>
    </form>
</body>
</html>
