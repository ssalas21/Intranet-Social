<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EstadisticasFecha.aspx.cs" Inherits="Dideco.Administrador.EstadisticasFecha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2>Bienvenido
        <br />
        <asp:Label ID="LblUsuario2" runat="server"></asp:Label>
        &nbsp;<asp:Label ID="LblUsuario" runat="server" Visible="False"></asp:Label>
        &nbsp;||&nbsp;<asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Cerrar sesión" />
        &nbsp;|| <a href="Index.aspx">
            <button type="button" class="btn btn-default">Volver atras</button></a>
    </h2>
    <br />
    <fieldset>
        <legend>Buscar solicitudes por rango de fechas</legend>
        <br />
        <div style="width: 45%; margin-left: 2%; float: left">
            <span>Seleccione fecha de inicio</span>
            <asp:Calendar ID="CalendarInicio" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnSelectionChanged="CalendarInicio_SelectionChanged">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                <TodayDayStyle BackColor="#CCCCCC" />
                <WeekendDayStyle BackColor="Red" />
            </asp:Calendar>
        </div>
        <div style="width: 45%; margin-left: 2%; float: left">
            <span>Seleccione fecha de fin</span>
            <asp:Calendar ID="CalendarFin" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnSelectionChanged="CalendarFin_SelectionChanged">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                <TodayDayStyle BackColor="#CCCCCC" />
                <WeekendDayStyle BackColor="Red" />
            </asp:Calendar>
        </div>
    </fieldset>

    <asp:Panel ID="PanelResultados" runat="server" Visible="False">
        <fieldset>
            <legend>Solicitudes</legend>
            <asp:GridView ID="GvResultadoBusqueda" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSResultados">
                <Columns>
                    <asp:BoundField DataField="IdSolicitud" HeaderText="Folio" SortExpression="IdSolicitud" />
                    <asp:BoundField DataField="MotivosAtencion.Motivo" HeaderText="Motivo" SortExpression="IdMotivo" />
                    <asp:BoundField DataField="Beneficiario.Nombre" HeaderText="Beneficiario" SortExpression="RutBeneficiario" />
                    <asp:BoundField DataField="Personal.Nombre" HeaderText="Secretaria" SortExpression="UserPersonal" />
                    <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha de Solicitud" SortExpression="FechaSolicitud" DataFormatString="{0:d}" />
                    <asp:TemplateField HeaderText="Asistente" SortExpression="Asistente">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<% #BuscarAsistente(Eval("Asistente").ToString())%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AprobacionAsistente" HeaderText="Aprobacion del Asistente" SortExpression="AprobacionAsistente" />
                    <asp:BoundField DataField="AprobacionDirector" HeaderText="Aprobacion del Director" SortExpression="AprobacionDirector" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ODSResultados" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerSolicitudesPorFecha" TypeName="Dideco.BLL.SolicitudesBLL">
                <SelectParameters>
                    <asp:ControlParameter ControlID="CalendarInicio" Name="inicio" PropertyName="SelectedDate" Type="DateTime" />
                    <asp:ControlParameter ControlID="CalendarFin" Name="fin" PropertyName="SelectedDate" Type="DateTime" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </fieldset>
        <br />
        <fieldset>
            <legend>Estadisticas</legend>
            <table border="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ODSEstadistica">
                            <Columns>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ODSEstadistica" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerEstadisticasPorFecha" TypeName="Dideco.BLL.EstadisticasBLL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="CalendarInicio" Name="inicio" PropertyName="SelectedDate" Type="DateTime" />
                                <asp:ControlParameter ControlID="CalendarFin" Name="fin" PropertyName="SelectedDate" Type="DateTime" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        <asp:Chart ID="Chart1" runat="server" DataSourceID="ODSEstadistica">
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
                    </td>
                </tr>
            </table>
        </fieldset>

    </asp:Panel>
</asp:Content>
