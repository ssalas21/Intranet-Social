using Dideco.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dideco.DirectorAreaOperativa
{
    public partial class EstadisticasMotivo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(HttpContext.Current.User.Identity.Name);
        }
    }
}