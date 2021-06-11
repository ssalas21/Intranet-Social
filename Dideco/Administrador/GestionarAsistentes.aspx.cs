using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.BLL;

namespace Dideco.Administrador
{
    public partial class GestionarAsistentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario.Text = (new PersonalBLL()).ObtenerNombre(usuario);
        }

        protected void BtnAgregarSecretaria_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text.Trim() == "" || TxtPass.Text.Trim() == "" || TxtNombre.Text.Trim() == "")
            {
                LblErrores.Text = "*Complete todos los datos";
            }
            else
            {
                LblAgregar.Text = (new PersonalBLL()).AgregarPersonal(TxtUser.Text.Trim(), TxtPass.Text.Trim(), TxtNombre.Text.Trim(), "Asistente");
                GvAsistentes.DataBind();
            }
        }
    }
}