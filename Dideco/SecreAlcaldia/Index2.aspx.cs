using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.BLL;

namespace Dideco.SecreAlcaldia
{
    public partial class Index : System.Web.UI.Page
    {
        List<Audiencias> listado = new AudienciasBLL().ObtenerAudienciasPendientes();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {            
            foreach (Audiencias item in listado)
            {
                if (e.Day.Date == new DateTime(item.FechaAudiencia.Value.Year,item.FechaAudiencia.Value.Month,item.FechaAudiencia.Value.Day)) {
                    Literal Literal1 = new Literal();
                    Literal1.Text = "<br /><font size=-1 color=Gold>"+item.FechaAudiencia.Value.Hour+":"+item.FechaAudiencia.Value.Minute+" "+item.RutBeneficiario+"</font>";
                    e.Cell.Font.Italic = true;
                    e.Cell.Font.Size = FontUnit.XLarge;
                    e.Cell.BackColor = System.Drawing.Color.Crimson;
                    e.Cell.BorderColor = System.Drawing.Color.Pink;
                    e.Cell.ForeColor = System.Drawing.Color.Snow;
                    e.Cell.Font.Name = "Courier New";

                    e.Cell.Controls.AddAt(1, Literal1);
                }
            }
        }
    }
}