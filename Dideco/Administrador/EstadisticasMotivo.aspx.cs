using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.BLL;
using System.Web.UI.DataVisualization.Charting;

namespace Dideco.Administrador
{
    public partial class EstadisticasMotivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(HttpContext.Current.User.Identity.Name);

        }

        protected void DdlMotivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelResultados.Visible = true;
            Chart2.Series["Series1"].IsValueShownAsLabel = true;
            Chart2.Legends.Add(new Legend("Default") { Docking = Docking.Right });
            BtnImprimir.Visible = true;
        }
    }
}