using Dideco.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dideco.SecreAlcaldia
{
    public partial class AgregarAudiencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
        }

        protected void TxtRut_TextChanged(object sender, EventArgs e)
        {
            Beneficiario usuario = (new BeneficiarioBLL()).BuscarPorRut(TxtRut.Text.Trim());
            if (usuario != null)
            {
                TxtNombre.Text = usuario.Nombre;
                TxtDireccion.Text = usuario.Direccion;
                TxtContacto.Text = usuario.Contacto;
                if (usuario.Localidad.Equals("CAMPICHE")) DdlLocalidad.SelectedIndex = 0;
                if (usuario.Localidad.Equals("CHILICAUQUÉN")) DdlLocalidad.SelectedIndex = 1;
                if (usuario.Localidad.Equals("EL CARDAL")) DdlLocalidad.SelectedIndex = 2;
                if (usuario.Localidad.Equals("EL RINCÓN")) DdlLocalidad.SelectedIndex = 3;
                if (usuario.Localidad.Equals("EL RUNGUE")) DdlLocalidad.SelectedIndex = 4;
                if (usuario.Localidad.Equals("EL PASO")) DdlLocalidad.SelectedIndex = 5;
                if (usuario.Localidad.Equals("HORCÓN")) DdlLocalidad.SelectedIndex = 6;
                if (usuario.Localidad.Equals("LA CANELA")) DdlLocalidad.SelectedIndex = 7;
                if (usuario.Localidad.Equals("LA CHOCOTA")) DdlLocalidad.SelectedIndex = 8;
                if (usuario.Localidad.Equals("LA ESTANCILLA")) DdlLocalidad.SelectedIndex = 9;
                if (usuario.Localidad.Equals("LA GREDA")) DdlLocalidad.SelectedIndex = 10;
                if (usuario.Localidad.Equals("LA LAGUNA")) DdlLocalidad.SelectedIndex = 11;
                if (usuario.Localidad.Equals("LA QUEBRADA")) DdlLocalidad.SelectedIndex = 12;
                if (usuario.Localidad.Equals("LAS MELOSILLAS")) DdlLocalidad.SelectedIndex = 13;
                if (usuario.Localidad.Equals("LAS VENTANAS")) DdlLocalidad.SelectedIndex = 14;
                if (usuario.Localidad.Equals("LOS MAITENES")) DdlLocalidad.SelectedIndex = 15;
                if (usuario.Localidad.Equals("LOS MAQUIS")) DdlLocalidad.SelectedIndex = 16;
                if (usuario.Localidad.Equals("MAITENCILLO")) DdlLocalidad.SelectedIndex = 17;
                if (usuario.Localidad.Equals("POTRERILLOS")) DdlLocalidad.SelectedIndex = 18;
                if (usuario.Localidad.Equals("PUCALÁN")) DdlLocalidad.SelectedIndex = 19;
                if (usuario.Localidad.Equals("PUCHUNCAVÍ")) DdlLocalidad.SelectedIndex = 20;
                if (usuario.Localidad.Equals("SAN ANTONIO")) DdlLocalidad.SelectedIndex = 21;
                if (usuario.Localidad.Equals("CAMPICHE")) DdlLocalidad.SelectedIndex = 22;
                if (usuario.Genero.Equals("FEMENINO")) DdlGenero.SelectedIndex = 0;
                if (usuario.Genero.Equals("MASCULINO")) DdlGenero.SelectedIndex = 1;
                TxtFechaNacimiento.Text = string.Format(usuario.FechaNacimiento.Value.Day + "/" + usuario.FechaNacimiento.Value.Month + "/" + usuario.FechaNacimiento.Value.Year);
            }
            else
            {
                TxtNombre.Text = "";
                TxtDireccion.Text = "";
                TxtContacto.Text = "";
                TxtFechaNacimiento.Text = "";
                DdlGenero.SelectedIndex = 0;
                DdlLocalidad.SelectedIndex = 0;
            }
        }

        protected void BtnAgregarSolicitud_Click(object sender, EventArgs e)
        {
            LblError.Text = "";
            LblSolicitud.Text = "";
            if (TxtRut.Text.Trim() == "" || TxtNombre.Text.Trim() == "" || TxtDireccion.Text.Trim() == "" || TxtSolicitud.Text.Trim() == "" || TxtContacto.Text.Trim() == "" || TxtFechaNacimiento.Text.Trim() == "")
            {
                LblError.Text = "Complete todos los campos";
            }
            else
            {
                try
                {
                    DateTime fechaNacimiento = Convert.ToDateTime(TxtFechaNacimiento.Text);
                    Beneficiario user = new Beneficiario() { Rut = TxtRut.Text.Trim().ToUpper(), Nombre = TxtNombre.Text.Trim().ToUpper(), Direccion = TxtDireccion.Text.Trim().ToUpper(), Contacto = TxtContacto.Text.Trim().ToUpper(), Localidad = DdlLocalidad.SelectedValue, FechaNacimiento = Convert.ToDateTime(TxtFechaNacimiento.Text), Genero = DdlGenero.SelectedValue };
                    new AudienciasBLL().AgregarAudiencia(user, DateTime.Now, TxtSolicitud.Text.ToUpper().Trim(), DdlTipo.SelectedValue.ToString());
                    TxtRut.Text = "";
                    TxtNombre.Text = "";
                    DdlLocalidad.SelectedIndex = 0;
                    TxtDireccion.Text = "";
                    TxtSolicitud.Text = "";
                    TxtContacto.Text = "";
                    TxtFechaNacimiento.Text = "";
                    LblSolicitud.Text = "Solicitud ingresada correctamente";
                }
                catch (Exception)
                {
                    LblError.Text = "Ingrese los datos de forma correcta";
                }

            }
        }
    }
}