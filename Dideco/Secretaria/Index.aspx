<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Dideco.Secretaria.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Bienvenido 
            <asp:Label ID="LblUsuario" runat="server"></asp:Label>
        &nbsp;||&nbsp;<asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Cerrar sesión" />
        &nbsp;
    </h2>

    <br />
    <fieldset>
        <legend>Generar solicitud de beneficio</legend>
        <table border="0" style="margin-top: 20px">
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="LblSolicitud" runat="server" Text="" CssClass="alert-success"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblError" runat="server" CssClass="alert-danger"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Rut del beneficiario</td>
                <td></td>
                <td>
                    <asp:TextBox ID="TxtRut" runat="server" AutoPostBack="True" OnTextChanged="TxtRut_TextChanged" Width="340px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td></td>
                <td>
                    <asp:TextBox ID="TxtNombre" runat="server" Width="340px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Dirección</td>
                <td></td>
                <td>
                    <asp:TextBox ID="TxtDireccion" runat="server" Width="340px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Contacto</td>
                <td></td>
                <td>
                    <asp:TextBox ID="TxtContacto" runat="server" Width="340px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Genero</td>
                <td></td>
                <td>
                    <asp:DropDownList ID="DdlGenero" runat="server" Width="340px" AutoPostBack="True">
                        <asp:ListItem>FEMENINO</asp:ListItem>
                        <asp:ListItem>MASCULINO</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Fecha de nacimiento (DD/MM/AAAA)</td>
                <td></td>
                <td>
                    <asp:TextBox ID="TxtFechaNacimiento" runat="server" Width="340px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Localidad</td>
                <td></td>
                <td>
                    <asp:DropDownList ID="DdlLocalidad" runat="server" Height="25px" Width="340px" AutoPostBack="True">
                        <asp:ListItem>CAMPICHE</asp:ListItem>
                        <asp:ListItem>CHILICAUQUÉN</asp:ListItem>
                        <asp:ListItem>EL CARDAL</asp:ListItem>
                        <asp:ListItem>EL RINCÓN</asp:ListItem>
                        <asp:ListItem>EL RUNGUE</asp:ListItem>
                        <asp:ListItem>EL PASO</asp:ListItem>
                        <asp:ListItem>HORCÓN</asp:ListItem>
                        <asp:ListItem>LA CANELA</asp:ListItem>
                        <asp:ListItem>LA CHOCOTA</asp:ListItem>
                        <asp:ListItem>LA ESTANCILLA</asp:ListItem>
                        <asp:ListItem>LA GREDA</asp:ListItem>
                        <asp:ListItem>LA LAGUNA</asp:ListItem>
                        <asp:ListItem>LA QUEBRADA</asp:ListItem>
                        <asp:ListItem>LAS MELOSILLAS</asp:ListItem>
                        <asp:ListItem>LAS VENTANAS</asp:ListItem>
                        <asp:ListItem>LOS MAITENES</asp:ListItem>
                        <asp:ListItem>LOS MAQUIS</asp:ListItem>
                        <asp:ListItem>MAITENCILLO</asp:ListItem>
                        <asp:ListItem>POTRERILLOS</asp:ListItem>
                        <asp:ListItem>PUCALÁN</asp:ListItem>
                        <asp:ListItem>PUCHUNCAVÍ</asp:ListItem>
                        <asp:ListItem>SAN ANTONIO</asp:ListItem>
                    </asp:DropDownList></td>
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
                <td>¿Pertenece al registro social de hogares?
                    </td>
                <td></td>
                <td>
                    <asp:RadioButton ID="RbRegistroSocialTrue" runat="server" Text="Si" GroupName="RegistroSocial" OnCheckedChanged="RbRegistroSocialTrue_CheckedChanged" AutoPostBack="True" /><asp:RadioButton ID="RbRegistroSocialFalse" runat="server" Checked="True" Text="No" GroupName="RegistroSocial" OnCheckedChanged="RbRegistroSocialFalse_CheckedChanged" AutoPostBack="True" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="LblPorcentaje" runat="server" Text="¿Cual es su porcentaje? ( 0 a 100 )" Visible="false"></asp:Label></td>
                <td></td>
                <td>
                    <asp:DropDownList ID="DdlPorcentaje" runat="server" Width="400px" Visible="false">
                        <asp:ListItem>40%</asp:ListItem>
                        <asp:ListItem>41 - 50%</asp:ListItem>
                        <asp:ListItem>51 - 60%</asp:ListItem>
                        <asp:ListItem>61 - 70%</asp:ListItem>
                        <asp:ListItem>71 - 80%</asp:ListItem>
                        <asp:ListItem>81- 90%</asp:ListItem>
                        <asp:ListItem>91 - 100%</asp:ListItem>
                        <asp:ListItem>10% +</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Detalles del caso</td>
                <td></td>
                <td>
                    <asp:TextBox ID="TxtDetalle" runat="server" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Seleccionar asistente social al cual asignar el caso</td>
                <td></td>
                <td>
                    <asp:DropDownList ID="DdlAsistente" runat="server" DataSourceID="ODSAsistentes" DataTextField="Nombre" DataValueField="User" Height="30px" Width="240px"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSAsistentes" runat="server" OldValuesParameterFormatString="{0}" SelectMethod="ListarAsistentes" TypeName="Dideco.BLL.PersonalBLL"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td></br></td>
                <td></br></td>
                <td></br></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BtnAgregarSolicitud" runat="server" Text="Agregar Solicitud" CssClass="btn-primary" OnClick="BtnAgregarSolicitud_Click" /></td>
                <td></td>
            </tr>
        </table>
    </fieldset>


</asp:Content>
