using Dideco.BLL;
using Dideco.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dideco.DirectorAreaOperativa
{
    public partial class ContratosVigentes : System.Web.UI.Page
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
            if (TxtMontoSuma.Text.Equals("0"))
            {
                PanelContratos.Visible = true;
                PanelModificar.Visible = false;
            }
            else {
                (new GastosContratosBLL()).AgregarGasto(Convert.ToInt32(Label1.Text), TxtDetalleGasto.Text.Trim(), Convert.ToInt32(TxtMontoSuma.Text));
                TxtMontoSuma.Text = "0";
                TxtDetalleGasto.Text = "";
                GvContratos.DataBind();
                PanelContratos.Visible = true;
                PanelModificar.Visible = false;
            }
        }

        protected void BtnDescargar_Click(object sender, EventArgs e)
        {
            ContratosView aux = (new ContratosOperativaBLL()).ObtenerContrato(Convert.ToInt32(GvContratos.SelectedValue));
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + aux.Adjunto);
            Response.WriteFile(aux.Adjunto);
            Response.End();
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
            TxtMonto.Text = aux.Monto.ToString();
            TxtMontoSuma.Text = "0";
            Label1.Text = GvContratos.SelectedValue.ToString();
        }
    }
}