<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EstadisticasMotivo.aspx.cs" Inherits="Dideco.Administrador.EstadisticasMotivo" %>

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
        <legend>Solicitudes por motivo</legend>
        <br />
        <table border="0">
            <tr>
                <td><span>Seleccione un motivo</span></td>
                <td>
                    <asp:DropDownList ID="DdlMotivos" runat="server" DataSourceID="ODSMotivos" DataTextField="Motivo" DataValueField="IdMotivo" AutoPostBack="True" OnSelectedIndexChanged="DdlMotivos_SelectedIndexChanged" style="margin-left:20px"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSMotivos" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ListarMotivos" TypeName="Dideco.BLL.MotivoAtencionBLL"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BtnImprimir" runat="server" Text="Imprimir" Visible="false" style="margin-left:20px" OnClientClick="javascript:window.print();" />
                </td>
            </tr>
        </table>
    </fieldset>

    <asp:Panel ID="PanelResultados" runat="server" Visible="False">
        <br />
        <fieldset>
            <legend>Solicitudes</legend>
            <asp:GridView ID="GvSolicitudesPorMotivo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSTablaMotivos">
                <Columns>
                    <asp:BoundField DataField="Beneficiario.Nombre" HeaderText="Beneficiario" SortExpression="RutBeneficiario" />
                    <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha de Solicitud" SortExpression="FechaSolicitud" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="AprobacionAsistente" HeaderText="Aprobacion del Asistente" SortExpression="AprobacionAsistente" />
                    <asp:BoundField DataField="AprobacionDirector" HeaderText="Aprobacion del Director" SortExpression="AprobacionDirector" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ODSTablaMotivos" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerSolicitudesPorMotivo" TypeName="Dideco.BLL.SolicitudesBLL">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DdlMotivos" Name="id" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </fieldset>
        <br />
        <fieldset>
            <legend>
                <h3>Estadisticas</h3>
            </legend>

            <fieldset>
                <legend>Aprobacion, rechazos y pendientes</legend>
                <div style="float: left; width: 300px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ODSMotivoCantidades">
                        <Columns>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ODSMotivoCantidades" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerEstadisticasPorMotivo" TypeName="Dideco.BLL.EstadisticasBLL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DdlMotivos" Name="id" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
                <div style="float: left">
                    <asp:Chart ID="Chart1" runat="server" DataSourceID="ODSMotivoCantidades" Width="600px">
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
                    <asp:GridView ID="GvPorcentaje" runat="server" AutoGenerateColumns="False" DataSourceID="ODSMotivosPorcentaje">
                        <Columns>
                            <asp:BoundField DataField="Estado" HeaderText="Nombre" SortExpression="Estado" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Porcentaje" SortExpression="Cantidad" DataFormatString="{0:0.0}%" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="float: left">
                    <asp:Chart ID="Chart2" runat="server" DataSourceID="ODSMotivosPorcentaje" Width="600px">
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
                    <asp:ObjectDataSource ID="ODSMotivosPorcentaje" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerEstadisticasGlobalesPorMotivo" TypeName="Dideco.BLL.EstadisticasBLL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DdlMotivos" Name="id" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </fieldset>

        </fieldset>
    </asp:Panel>

</asp:Content>
