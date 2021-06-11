<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SolicitudesPorRut.aspx.cs" Inherits="Dideco.DirectorAreaOperativa.SolicitudesPorRut" %>

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
        <legend>Revisar solicitudes por rut</legend>
        <table border="0">
            <tr>
                <td>Rut del beneficiario</td>
                <td></td>
                <td>
                    <asp:TextBox ID="TxtRut" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <br />
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="bg-primary" OnClick="BtnBuscar_Click" /></td>
                <td>
                    <asp:Button ID="BtnImprimir" runat="server" Text="Imprimir detalles" OnClientClick="javascript:window.print();" Visible="False" /></td>
            </tr>
        </table>
        <br />

    </fieldset>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <fieldset>
            <legend>Solicitudes</legend>
            <asp:GridView ID="GvSolicitudesPorRut" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSSolicitudesPorRut" CssClass="bg-info" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="IdSolicitud" CellPadding="10" CellSpacing="10" OnSelectedIndexChanged="GvSolicitudesPorRut_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="IdSolicitud" HeaderText="Folio" SortExpression="IdSolicitud" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha de Solicitud" SortExpression="FechaSolicitud" DataFormatString="{0:d}" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AprobacionDirector" HeaderText="Aprobacion" SortExpression="AprobacionDirector" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FechaAprobacionDirector" HeaderText="Fecha" SortExpression="FechaAprobacionDirector" DataFormatString="{0:d}" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Visita" HeaderText="Visita" SortExpression="Visita" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Asistente" SortExpression="Asistente">
                        <ItemTemplate>
                        <asp:Label ID="LblAsistente" runat="server" Text='<% #BuscarAsistente(Eval("Asistente").ToString())%>'></asp:Label>
                    </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Motivo" SortExpression="Motivo">
                        <ItemTemplate>
                            <asp:Label ID="LblMotivo" runat="server" Text='<% #ObtenerMotivo(Convert.ToInt32(Eval("IdSolicitud")))%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    <asp:CommandField AccessibleHeaderText="Certificado" HeaderText="Imprimir Certificado" ButtonType="Image" SelectImageUrl="~/img/pdf.png" ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BorderStyle="Solid" BorderWidth="2px" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ODSSolicitudesPorRut" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerSolicitudesPorRut" TypeName="Dideco.BLL.SolicitudesBLL">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtRut" Name="rut" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </fieldset>

        <br />
        <fieldset>
            <legend>Estadisticas</legend>

            <div style="width: 400px; float: left">
                <br />
                <span>Estado y cantidad de solicitudes realizadas por:
                    <br />
                    <asp:Label ID="LblBeneficiario" runat="server" Text=""></asp:Label><br />
                </span>
                <br />
                <div align="center">
                    <asp:GridView ID="GvEstadisticas" runat="server" AutoGenerateColumns="False" DataSourceID="ODSGraficosPorRut">
                        <Columns>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div style="margin-left: 10%; float: left">
                <asp:Chart ID="Grafico" runat="server" DataSourceID="ODSGraficosPorRut">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Bar" XValueMember="Estado" YValueMembers="Cantidad">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <Area3DStyle Enable3D="True" />
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:ObjectDataSource ID="ODSGraficosPorRut" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ObtenerEstadisticasPorRut" TypeName="Dideco.BLL.EstadisticasBLL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtRut" Name="rut" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>


        </fieldset>

    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="False">
        <fieldset>
            <legend>Solicitudes</legend>

            <asp:Label ID="Label2" runat="server" Text="No existen solicitudes para dicho rut"></asp:Label>

        </fieldset>
    </asp:Panel>
</asp:Content>
