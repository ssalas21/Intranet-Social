using Dideco.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dideco.Reportes
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario.Text = (new PersonalBLL()).ObtenerNombre(usuario);
        }
    }
}