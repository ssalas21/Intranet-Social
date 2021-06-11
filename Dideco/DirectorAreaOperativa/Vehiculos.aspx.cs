using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.BLL;

namespace Dideco.DirectorAreaOperativa
{
    public partial class Vehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAgregarUso_Click(object sender, EventArgs e)
        {
            try
            {
                (new UsoVehiculosBLL ()).AgregarUso(Label1.Text, DateTime.Now, Convert.ToInt32(TxtUso.Text.Trim()));
                PanelActualizarVehiculo.Visible = false;
                PanelVehiculos.Visible = true;
                Label1.Visible = true;
                Label1.Text = "Uso agregado correctamente";
            }
            catch (Exception)
            {
                PanelActualizarVehiculo.Visible = false;
                PanelVehiculos.Visible = true;
                Label1.Visible = true;
                Label1.Text = "Por favor ingrese bien los datos";
                
            }
        }

        protected void GvVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Visible = false;
            PanelVehiculos.Visible = false;
            PanelActualizarVehiculo.Visible = true;
            Label1.Text = GvVehiculos.SelectedValue.ToString();
        }

        protected void GvMantenciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mantenciones aux = (new MantencionesBLL()).ObtenerMantencion(Convert.ToInt32(GvMantenciones.SelectedValue));
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + aux.Adjunto);
            Response.WriteFile(aux.Adjunto);
            Response.End();
        }

        protected void GvSeguros_SelectedIndexChanged(object sender, EventArgs e)
        {
            SegurosComplementarios aux = (new SegurosComplementariosBLL()).ObtenerSeguro(Convert.ToInt32(GvSeguros.SelectedValue));
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + aux.Adjunto);
            Response.WriteFile(aux.Adjunto);
            Response.End();
        }
    }
}