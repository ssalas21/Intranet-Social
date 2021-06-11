using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Dideco.BLL;

namespace Dideco.Rol1
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