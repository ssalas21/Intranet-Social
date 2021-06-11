using Dideco.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dideco.DirectorAreaOperativa
{
    public partial class VerSegurosVigentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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