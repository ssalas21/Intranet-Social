using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.BLL;

namespace Dideco.Educacion
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
            LblCantidad2.Text = (new SolicitudesBLL()).ObtenerCantidadSolicitudesPendientesAsistentes().ToString();
            LblCantidadDirector.Text = (new SolicitudesBLL()).ObtenerCantidadSolicitudesPendientesDirector().ToString();
            LblAudiencias.Text = (new AudienciasBLL()).ObtenerAudienciasSinSolucionPorDepartamentoCantidad("EDUCACION").ToString();
        }
    }
}