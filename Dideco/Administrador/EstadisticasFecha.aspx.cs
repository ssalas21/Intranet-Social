using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.BLL;

namespace Dideco.Administrador
{
    public partial class EstadisticasFecha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(HttpContext.Current.User.Identity.Name);
            if (!IsPostBack) {
                CalendarInicio.SelectedDate = DateTime.Now;
                CalendarFin.SelectedDate = DateTime.Now;
            }
        }

        protected void CalendarFin_SelectionChanged(object sender, EventArgs e)
        {
            if (CalendarFin.SelectedDate < CalendarInicio.SelectedDate)
            {
                CalendarFin.SelectedDate = CalendarInicio.SelectedDate;
                GvResultadoBusqueda.DataBind();
                GridView1.DataBind();
                Chart1.DataBind();
                PanelResultados.Visible = true;
            }
            else
            {
                GvResultadoBusqueda.DataBind();
                GridView1.DataBind();
                Chart1.DataBind();
                PanelResultados.Visible = true;
            }
        }



        public string BuscarAsistente(string asistente)
        {
            return (new PersonalBLL()).ObtenerNombre(asistente);
        }

        protected void CalendarInicio_SelectionChanged(object sender, EventArgs e)
        {
            GvResultadoBusqueda.DataBind();
            GridView1.DataBind();
            Chart1.DataBind();
            PanelResultados.Visible = true;
        }
    }
}