using Dideco.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dideco.Asistente
{
    public partial class Index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
            LblCantidad2.Text = (new SolicitudesBLL()).ObtenerCantidadSolicitudesPendientesAsistente(usuario).ToString();
            
        }
    }
}