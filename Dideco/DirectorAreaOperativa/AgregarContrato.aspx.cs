using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.Entity;
using Dideco.BLL;

namespace Dideco.DirectorAreaOperativa
{
    public partial class AgregarContrato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
        }

        protected void BtnAgregarContrato_Click(object sender, EventArgs e)
        {
            Archivo aux = new Archivo() { Adjunto = FileUploadAdjunto, Ruta = Server.MapPath("~/Adjuntos/Contratos/") };
            if (TxtNombre.Text.Trim().Equals("") || TxtDetalle.Text.Trim().Equals("") || TxtFechaExpiracion.Text.Trim().Equals("") || TxtFechaInicio.Text.Trim().Equals("") || TxtMonto.Text.Trim().Equals("") || aux.Adjunto.HasFile == false)
            {
                Label1.Text = "Complete todos los datos";
            }
            else
            {
                DateTime fecha1 = DateTime.Now;
                DateTime fecha2 = DateTime.Now;
                try
                {
                    fecha1 = Convert.ToDateTime(TxtFechaInicio.Text.Trim());
                    fecha2 = Convert.ToDateTime(TxtFechaExpiracion.Text.Trim());
                    Label1.Text = "";
                }
                catch (Exception)
                {
                    Label1.Text = "Ingrese las fechas en el formato estipulado";
                }
                if (Label1.Text.Equals(""))
                {
                    string resultado = (new ContratosOperativaBLL()).AgregarContrato(TxtNombre.Text.ToUpper().Trim(), TxtDetalle.Text.ToUpper().Trim(), fecha1, fecha2, Convert.ToInt32(TxtMonto.Text.Trim()), aux);
                    Label1.Text = resultado;
                    TxtDetalle.Text = "";
                    TxtFechaExpiracion.Text = "";
                    TxtFechaInicio.Text = "";
                    TxtMonto.Text = "";
                    TxtNombre.Text = "";
                }
            }



        }
    }
}