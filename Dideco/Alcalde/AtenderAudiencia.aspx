<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AtenderAudiencia.aspx.cs" Inherits="Dideco.Alcalde.AtenderAudiencia" %>

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

                    <li class="nav-item active" data-toggle="tooltip" data-placement="right" title="Tables">
                        <a class="nav-link" href="AtenderAudiencia.aspx">
                            <i class="fa fa-fw fa-table"></i>
                            <span class="nav-link-text">Atender Audiencia</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Charts">
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
                <h3>Atender audiencias</h3>
                <br />
                <asp:Label ID="LblSolicitud" runat="server" Text="" CssClass="alert-success"></asp:Label>
                <br />
                <br />
                <asp:Panel ID="PanelSeleccionarAudiencia" runat="server">
                    <div style="align-content:center;">
                        <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" Width="900px"></asp:Calendar>
                    </div>
                    <br />
                    <div style="align-content:center">
                        <asp:GridView ID="GvAudiencias" runat="server" AutoGenerateColumns="False" DataSourceID="ODSAudiencias" DataKeyNames="IdAudiencias" CellPadding="15" CellSpacing="10" OnSelectedIndexChanged="GvAudiencias_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="FechaAudiencia" HeaderText="Horario  " DataFormatString="{0:hh:mm tt}" SortExpression="FechaAudiencia" />
                                <asp:BoundField DataField="IdAudiencias" HeaderText="Id" SortExpression="IdAudiencias" />
                                <asp:BoundField DataField="Beneficiario.Nombre" HeaderText="Beneficiario" SortExpression="RutBeneficiario" />
                                <asp:BoundField DataField="Solicitud" HeaderText="Solicitud" SortExpression="Solicitud" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/elegir.png" ShowSelectButton="True" HeaderText="Atender" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSAudiencias" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerAudienciasPendientesPorFecha" TypeName="Dideco.BLL.AudienciasBLL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="Calendar1" Name="fecha" PropertyName="SelectedDate" Type="DateTime" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    
                </asp:Panel>
                <asp:Panel ID="PanelAtencionAudiencia" runat="server" Visible="false">
                    <table border="0" style="margin-top: 20px">
                        <tr>
                            <td></td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="LblError" runat="server" CssClass="alert-danger"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Rut del beneficiario</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtRut" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Nombre</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtNombre" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Dirección</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtDireccion" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Contacto</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtContacto" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Genero</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtSexo" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td>Fecha de nacimiento (DD/MM/AAAA)</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtFechaNacimiento" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Localidad</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtLocalidad" runat="server" ReadOnly="true" Width="340px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Entregado mediante</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtTipo" runat="server" ReadOnly="true" Width="340px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Solicitud</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtSolicitud" runat="server" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Compromiso</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtCompromiso" runat="server" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox></td>

                        </tr>                        
                        <tr>
                            <td>¿La solicitud sera derivada?</td>
                            <td></td>
                            <td>
                                <asp:RadioButton ID="RbtnNo" runat="server" GroupName="Derivacion" Checked="true" AutoPostBack="True" OnCheckedChanged="RbtnNo_CheckedChanged" />NO
                                <asp:RadioButton ID="RbtnYes" runat="server" GroupName="Derivacion" OnCheckedChanged="RbtnYes_CheckedChanged" AutoPostBack="True" />SI
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="LblPreguntaMonto" runat="server" Text="¿Se entregaran dinero o elementos avaluados?"></asp:Label>
                            </td>
                            <td></td>
                            <td>
                                <asp:RadioButton ID="RbtnDineroNo" runat="server" GroupName="Entrega" AutoPostBack="True" OnCheckedChanged="RbtnDineroNo_CheckedChanged1" />&nbsp;<asp:Label ID="LblEntregaDineroNo" runat="server" Text="NO"></asp:Label>
                                <asp:RadioButton ID="RbtnDineroYes" runat="server" GroupName="Entrega" AutoPostBack="True" Checked="True" OnCheckedChanged="RbtnDineroYes_CheckedChanged1" />
                                <asp:Label ID="LblEntregaDineroSi" runat="server" Text="SI"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblMonto" runat="server" Text="Monto entregado"></asp:Label>
                            </td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtMonto" runat="server" TextMode="Number" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblSolucion" runat="server" Text="Solución"></asp:Label>
                            </td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="TxtSolucion" runat="server" Width="400px" Height="200px" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><br />
                                <asp:Button ID="BtnSolucion" runat="server" Text="Entregar Solución" CssClass="btn-primary" OnClick="BtnSolucion_Click"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblDerivacion" runat="server" Text="La solicitud sera derivada a" Visible="False"></asp:Label>
                            </td>
                            <td></td>
                            <td>
                                <asp:DropDownList ID="DdlDerivacion" runat="server" Width="400px" Visible="false">
                                    <asp:ListItem Value="AREA OPERATIVA">Area Operativa</asp:ListItem>
                                    <asp:ListItem Value="DIDECO">Dideco</asp:ListItem>
                                    <asp:ListItem Value="EDUCACION">Educación</asp:ListItem>
                                    <asp:ListItem Value="FINANZAS">Finanzas</asp:ListItem>
                                    <asp:ListItem Value="INFORMATICA">Informática</asp:ListItem>
                                    <asp:ListItem Value="MEDIO AMBIENTE">Medio Ambiente</asp:ListItem>
                                    <asp:ListItem Value="OBRAS">Obras</asp:ListItem>
                                    <asp:ListItem Value="RRPP">Relaciones Publicas</asp:ListItem>
                                    <asp:ListItem Value="SECPLAN">Secplan</asp:ListItem>
                                    <asp:ListItem Value="TRANSITO">Transito</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><br />
                                <asp:Button ID="BtnAtenderSolicitud" runat="server" Text="Derivar Audiencia" CssClass="btn-primary" OnClick="BtnAtenderSolicitud_Click" Visible="false" /></td>
                            <td>
                                <asp:Label ID="LblId" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <br />
                            </td>
                            <td>
                                <br />
                                <br />
                            </td>
                            <td>
                                <br />
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
