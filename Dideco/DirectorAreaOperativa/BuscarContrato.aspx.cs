using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.BLL;
using Dideco.Entity;

namespace Dideco.DirectorAreaOperativa
{
    public partial class BuscarContrato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            PanelContratos.Visible = true;
            GvContratos.DataBind();
        }

        protected void GvContratos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContratosView aux = (new ContratosOperativaBLL()).ObtenerContrato(Convert.ToInt32(GvContratos.SelectedValue));
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + aux.Adjunto);
            Response.WriteFile(aux.Adjunto);
            Response.End();
        }
    }
}