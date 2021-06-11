<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Dideco.Rol1.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Bienvenido 
            <asp:Label ID="LblUsuario" runat="server"></asp:Label>
        &nbsp;||&nbsp;<asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Cerrar sesión" />
    </h2>
    <br />
    <br />
    <fieldset>
        <legend>Menú de administrador</legend>
        <h4>¿Que desea realizar?</h4>
        <table border="0" style="margin-top: 30px; margin-left: 10%; margin-right: 10%;">
            <tr>
                <td>
                    <a href="GestionarSecretarias.aspx">
                        <button type="button" class="btn btn-primary" style="margin-left: 10px; width: 400px">Gestionar Secretarias</button></a>
                </td>
                <td>
                    <a href="GestionarAsistentes.aspx">
                        <button type="button" class="btn btn-primary" style="margin-left: 10px; width: 400px">Gestionar Asistentes</button></a>
                </td>
                <td>
                    <a href="GestionarDirectores.aspx">
                        <button type="button" class="btn btn-primary" style="margin-left: 10px; width: 400px">Gestionar Directores</button></a>
                </td>
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
                    <a href="EstadisticasFecha.aspx">
                        <button type="button" class="btn btn-primary" style="margin-left: 10px; width: 400px">Estadisticas por Fecha</button></a>
                </td>
                <td>
                    <a href="EstadisticasMotivo.aspx">
                        <button type="button" class="btn btn-primary" style="margin-left: 10px; width: 400px">Estadisticas por Motivo</button></a>
                </td>
                <td></td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
