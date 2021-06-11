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
    public partial class Mantencion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GvProximaMantencion_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelVehiculos.Visible = false;
            Label1.Text = "";
            LblPlacaMantencion.Text = GvProximaMantencion.SelectedValue.ToString();
            PanelMantenciones.Visible = true;
            PanelReparaciones.Visible = false;
            PanelRevisiones.Visible = false;
            PanelPermisos.Visible = false;
            string aux = (new VehiculosBLL()).ObtenerTipo(LblPlacaMantencion.Text);
            if (aux == "RETROEXCAVADORA" || aux == "EXCAVADORA" || aux == "MOTONIVELADORA")
            {
                Label2.Visible = false;
                TxtProximaMantencion.Visible = false;
            }
            else
            {
                Label2.Visible = true;
                TxtProximaMantencion.Visible = true;
            }
        }

        protected void GvRevisionesProximas_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelVehiculos.Visible = false;
            Label1.Text = "";
            LblPlacaRevision.Text = GvRevisionesProximas.SelectedValue.ToString();
            PanelMantenciones.Visible = false;
            PanelReparaciones.Visible = false;
            PanelRevisiones.Visible = true;
            PanelPermisos.Visible = false;
        }

        protected void GvReparaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelVehiculos.Visible = false;
            Label1.Text = "";
            LblPlacaReparacion.Text = GvReparaciones.SelectedValue.ToString();
            PanelMantenciones.Visible = false;
            PanelReparaciones.Visible = true;
            PanelRevisiones.Visible = false;
            PanelPermisos.Visible = false;
        }

        protected void BtnAgregarMantencion_Click(object sender, EventArgs e)
        {
            Archivo aux = new Archivo() { Adjunto = FileUploadMantencion, Ruta = Server.MapPath("~/Adjuntos/Mantenciones/") };
            if (aux.Adjunto.HasFile == true && TxtDetalleMantencion.Text != "")
            {
                int proxima;
                try
                {
                    proxima = Convert.ToInt32(TxtProximaMantencion.Text.Trim());
                }
                catch (Exception)
                {
                    proxima = 0;
                }

                Label1.Text = (new MantencionesBLL()).AgregarMantencion(LblPlacaMantencion.Text, TxtDetalleMantencion.Text, aux, proxima);
                PanelMantenciones.Visible = false;
                PanelReparaciones.Visible = false;
                PanelRevisiones.Visible = false;
                PanelVehiculos.Visible = true;
                PanelPermisos.Visible = false;
                TxtProximaMantencion.Text = "";
                GvProximaMantencion.DataBind();
                GvReparaciones.DataBind();
                GvRevisionesProximas.DataBind();
                GvPermisos.DataBind();
            }
            else
            {
                Label1.Text = "Complete todos los datos";
            }
        }

        protected void BtnReparacion_Click(object sender, EventArgs e)
        {
            Archivo aux = new Archivo() { Adjunto = FileUploadMantencion, Ruta = Server.MapPath("~/Adjuntos/Mantenciones/") };
            if (aux.Adjunto.HasFile == true && TxtDetalleReparacion.Text != "")
            {
                Label1.Text = (new MantencionesBLL()).AgregarReparacion(LblPlacaMantencion.Text, TxtDetalleReparacion.Text, aux);
                PanelMantenciones.Visible = false;
                PanelReparaciones.Visible = false;
                PanelRevisiones.Visible = false;
                PanelVehiculos.Visible = true;
                PanelPermisos.Visible = false;
                GvProximaMantencion.DataBind();
                GvReparaciones.DataBind();
                GvRevisionesProximas.DataBind();
                GvPermisos.DataBind();
            }
            else
            {
                Label1.Text = "Complete todos los datos";
            }
        }

        protected void BtnAgregarRevision_Click(object sender, EventArgs e)
        {
            try
            {
                (new VehiculosBLL()).ModificarRevision(LblPlacaRevision.Text, Convert.ToDateTime(TxtProximaRevision.Text));
                Label1.Text = "Revision modificada correctamente";
                PanelMantenciones.Visible = false;
                PanelReparaciones.Visible = false;
                PanelRevisiones.Visible = false;
                PanelVehiculos.Visible = true;
                PanelPermisos.Visible = false;
                GvProximaMantencion.DataBind();
                GvReparaciones.DataBind();
                GvRevisionesProximas.DataBind();
                GvPermisos.DataBind();
            }
            catch (Exception)
            {
                Label1.Text = "Ingrese la fecha de forma correcta";
            }
        }

        protected void GvPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelVehiculos.Visible = false;
            Label1.Text = "";
            LblPlacaPermiso.Text = GvPermisos.SelectedValue.ToString();
            PanelMantenciones.Visible = false;
            PanelReparaciones.Visible = false;
            PanelRevisiones.Visible = false;
            PanelPermisos.Visible = true;
        }

        protected void BtnPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = Convert.ToDateTime(TxtFechaPermiso.Text.Trim());
                string resultado = (new VehiculosBLL()).ActualizarPermiso(LblPlacaPermiso.Text, fecha);
                Label1.Text = resultado;
                PanelMantenciones.Visible = false;
                PanelReparaciones.Visible = false;
                PanelRevisiones.Visible = false;
                PanelVehiculos.Visible = true;
                PanelPermisos.Visible = false;
                GvProximaMantencion.DataBind();
                GvReparaciones.DataBind();
                GvRevisionesProximas.DataBind();
                GvPermisos.DataBind();

            }
            catch (Exception)
            {
                Label1.Text = "Ingrese la fecha en formato correcto";
            }
        }
    }
}