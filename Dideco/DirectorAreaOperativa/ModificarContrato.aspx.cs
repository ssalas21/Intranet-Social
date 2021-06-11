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
    public partial class ModificarContrato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
            GvContratos.DataBind();

        }

        protected void BtnAgregarContrato_Click(object sender, EventArgs e)
        {
            try
            {
                (new ContratosOperativaBLL()).ModificarContrato(Convert.ToInt32(Label1.Text), Convert.ToDateTime(TxtFechaExpiracion.Text), Convert.ToInt32(TxtMontoSuma.Text));
                GvContratos.DataBind();
                PanelContratos.Visible = true;
                PanelModificar.Visible = false;
            }
            catch (Exception)
            {
                (new ContratosOperativaBLL()).ModificarContrato2(Convert.ToInt32(Label1.Text), Convert.ToInt32(TxtMontoSuma.Text));
                GvContratos.DataBind();
                PanelContratos.Visible = true;
                PanelModificar.Visible = false;
            }
        }

        protected void GvContratos_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelContratos.Visible = false;
            PanelModificar.Visible = true;
            ContratosView aux = (new ContratosOperativaBLL()).ObtenerContrato(Convert.ToInt32(GvContratos.SelectedValue));
            TxtNombre.Text = aux.Nombre;
            TxtDetalle.Text = aux.Detalle;
            TxtFechaExpiracion.Text = aux.FechaExpiracion.ToString();
            TxtFechaInicio.Text = aux.FechaInicio.ToString();
            TxtMonto.Text = "" + aux.Monto;
            TxtMontoSuma.Text = "0";
            Label1.Text = GvContratos.SelectedValue.ToString();
        }
    }
}