<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Dideco.Reportes.Index" %>
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
        <legend>Menú de Reportes</legend>
        <h4>¿Que desea realizar?</h4>
        <table border="0" style="margin-top: 30px; margin-left: 10%; margin-right: 10%;">
            
            <tr>
                <td>
                    <a href="SolicitudesFecha.aspx">
                        <button type="button" class="btn btn-primary" style="margin-left: 10px; width: 400px">Solicitudes por Fecha</button></a>
                </td>
                <td>
                    <a href="SolicitudesBeneficiario.aspx">
                        <button type="button" class="btn btn-primary" style="margin-left: 10px; width: 400px">Solicitudes por Beneficiario</button></a>
                </td>
                
            </tr>
            <tr>
                <td>
                    <br />
                </td>
                <td>
                    <br />
                </td>
                
            </tr>
             
        </table>
    </fieldset>


</asp:Content>
