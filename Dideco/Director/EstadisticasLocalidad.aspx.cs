using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.BLL;
using System.Web.UI.DataVisualization.Charting;
namespace Dideco.DirectorAreaOperativa
{
    public partial class EstadisticasLocalidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(HttpContext.Current.User.Identity.Name);
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
            GridView2.DataBind();
            GridView3.DataBind();
            GridView4.DataBind();
            Chart1.DataBind();
            Chart2.DataBind();
            Chart3.DataBind();
            Chart4.DataBind();
        }

        
    }
}