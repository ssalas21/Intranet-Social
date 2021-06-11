<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GestionarDirectores.aspx.cs" Inherits="Dideco.Administrador.GestionarDirectores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Bienvenido 
            <asp:Label ID="LblUsuario" runat="server"></asp:Label>
        &nbsp;||&nbsp;<asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Cerrar sesión" />
        &nbsp;|| <a href="Index.aspx">
            <button type="button" class="btn btn-default">Volver atras</button></a>
    </h2>

    <br />
    <fieldset>
        <legend>Agregar Asistente</legend>
        <table border="0">
            <tr>
                <td>Nombre Usuario</td>
                <td>
                    <br />
                </td>
                <td>
                    <asp:TextBox ID="TxtUser" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
                <td>
                    <br />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Contraseña</td>
                <td>
                    <br />
                </td>
                <td>
                    <asp:TextBox ID="TxtPass" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
                <td>
                    <br />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td>
                    <br />
                </td>
                <td>
                    <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
                <td>
                    <br />
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                
                <td>
                    <asp:Button ID="BtnAgregarDirector" runat="server" Text="Agregar Director" CssClass="btn-primary" OnClick="BtnAgregarSecretaria_Click" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="LblAgregar" runat="server" Text="" CssClass="badge"></asp:Label></td>
                <td></td>
                <td>
                    <asp:Label ID="LblErrores" runat="server" CssClass="alert-danger"></asp:Label>
                </td>
            </tr>
        </table>
        
    </fieldset>
    <br />
    <fieldset>
        <legend>Directores</legend>
        <asp:GridView ID="GvDirectores" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="User" DataSourceID="ODSPersonal">
            <Columns>
                <asp:BoundField DataField="User" HeaderText="Nombre de Usuario" ReadOnly="True" SortExpression="User" />
                <asp:BoundField DataField="Pass" HeaderText="Contraseña" SortExpression="Pass" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Rol" HeaderText="Rol" ReadOnly="True" SortExpression="Rol" />
                <asp:CommandField CancelText="Cancelar" EditText="Editar" ShowEditButton="True" UpdateText="Actualizar" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ODSPersonal" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListarDirectores" TypeName="Dideco.BLL.PersonalBLL" UpdateMethod="ModificarPersonal">
            <UpdateParameters>
                <asp:Parameter Name="User" Type="String" />
                <asp:Parameter Name="Pass" Type="String" />
                <asp:Parameter Name="Nombre" Type="String" />
                <asp:Parameter Name="Rol" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </fieldset>

</asp:Content>
