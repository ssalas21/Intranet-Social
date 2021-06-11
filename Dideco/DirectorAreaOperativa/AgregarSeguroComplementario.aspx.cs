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
    public partial class AgregarSeguroComplementario : System.Web.UI.Page
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

        protected void BtnAgregarSeguro_Click(object sender, EventArgs e)
        {
            try
            {
                Archivo adjunto = new Archivo(){Ruta= Server.MapPath("~/Adjuntos/Seguros/") , Adjunto = FileUploadAdjunto};
                string resultado = (new SegurosComplementariosBLL()).AgregarSeguro(LblPlaca.Text, Convert.ToDateTime(TxtFechaInicio.Text), Convert.ToDateTime(TxtFechaTermino.Text), adjunto);
                if (resultado.Equals("Seguro agregado Correctamente"))
                {
                    LblWarning.Text = "";
                    LblSuccess.Text = "";
                    LblSuccess.Text = "Seguro agregado Correctamente";
                    PanelVehiculo.Visible = true;
                    PanelSeguros.Visible = false;
                }
                else {
                    LblWarning.Text = "";
                    LblSuccess.Text = "";
                    LblWarning.Text = resultado;
                }                
            }
            catch (Exception ex)
            {
                LblWarning.Text = "";
                LblSuccess.Text = "";
                LblWarning.Text ="Ingrese todos los datos de manera correcta";                
            }
        }

        protected void GvVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelVehiculo.Visible = false;
            PanelSeguros.Visible = true;
            GvSeguros.DataBind();
            LblPlaca.Text = GvVehiculos.SelectedValue.ToString();
        }
    }
}