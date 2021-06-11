using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.BLL;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Dideco.Asistente
{
    public partial class SolicitudesPendientesAsistente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
            LblUsuario.Text = usuario;
        }

        protected void GvSolicitudesPendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvSolicitudesPendientes.SelectedValue);
            LblId.Text = id.ToString();
            PanelSolicitudes.Visible = false;
            PanelAprobaciones.Visible = true;
            Solicitudes solicitud = (new SolicitudesBLL()).ObtenerSolicitudPorId(id);
            TxtRut.Text = solicitud.RutBeneficiario;
            if (solicitud.RegistroSocialHogar == true)
            {
                TxtRGH.Text = "Si";
                TxtPorcentaje.Text = string.Format(solicitud.PorcentajeRSH.ToString() + "%");
                TxtPorcentaje.Visible = true;
            }
            else { TxtRGH.Text = "No"; }
            TxtNombre.Text = solicitud.Beneficiario.Nombre;
            ChkVivienda.Checked = solicitud.Vivienda.Value;
            ChkAlimentacion.Checked = solicitud.Alimentacion.Value;
            ChkSalud.Checked = solicitud.Salud.Value;
            ChkInfancia.Checked = solicitud.Infancia.Value;
            ChkDefunciones.Checked = solicitud.Defunciones.Value;
            ChkPersonalMunicipal.Checked = solicitud.PersonalMunicipal.Value;
            ChkMicroemprendimiento.Checked = solicitud.Microemprendimiento.Value;
            ChkPSGubernamental.Checked = solicitud.PSGubernamental.Value;
            ChkMaquinaria.Checked = solicitud.Maquinaria.Value;
            ChkRebajaAseo.Checked = solicitud.RebajaAseo.Value;
            ChkAgua.Checked = solicitud.EntregaAgua.Value;
            ChkOtros.Checked = solicitud.Otros.Value;
            TxtLocalidad.Text = solicitud.Beneficiario.Localidad;
            TxtDireccion.Text = solicitud.Beneficiario.Direccion;
            TxtDetalle.Text = solicitud.DetallesCaso;
            TxtContacto.Text = solicitud.Beneficiario.Contacto;
            
            if (solicitud.Visita.Equals("SI"))
            {
                DdlVisita.SelectedIndex = 1;
                if (solicitud.FechaVisita != null)
                {
                    DdlVisita.Enabled = false;
                    CVisita.Visible = true;
                    CVisita.SelectedDate = (DateTime)solicitud.FechaVisita;
                    CVisita.Enabled = false;
                }
                else
                {
                    CVisita.Visible = true;
                    CVisita.SelectedDate = DateTime.Now;
                }
            }
            else
            {
                DdlVisita.SelectedIndex = 0;
                CVisita.Visible = false;
                DdlVisita.Enabled = true;
            }
            TxtSituacion.Text = solicitud.SituacionFamiliar;
            Label1.Text = "";
            Label2.Text = "";
        }

        protected void BtnAprobarSolicitud_Click(object sender, EventArgs e)
        {
            if (DdlVisita.SelectedValue.Equals("SI")) (new SolicitudesBLL()).AprobarSolicitudPorAsistenteFecha(Convert.ToInt32(LblId.Text), DdlVisita.SelectedValue.ToString(), TxtDetalle.Text, ChkVivienda.Checked, ChkAlimentacion.Checked, ChkSalud.Checked, ChkInfancia.Checked, ChkDefunciones.Checked, ChkMicroemprendimiento.Checked, ChkPSGubernamental.Checked, ChkMaquinaria.Checked, ChkPersonalMunicipal.Checked, ChkRebajaAseo.Checked, ChkAgua.Checked, ChkOtros.Checked, CVisita.SelectedDate, TxtSituacion.Text.Trim());
            else (new SolicitudesBLL()).AprobarSolicitudPorAsistente(Convert.ToInt32(LblId.Text), DdlVisita.SelectedValue.ToString(), TxtDetalle.Text, ChkVivienda.Checked, ChkAlimentacion.Checked, ChkSalud.Checked, ChkInfancia.Checked, ChkDefunciones.Checked, ChkMicroemprendimiento.Checked, ChkPSGubernamental.Checked, ChkMaquinaria.Checked, ChkPersonalMunicipal.Checked, ChkRebajaAseo.Checked, ChkAgua.Checked, ChkOtros.Checked, TxtSituacion.Text.Trim());
            Label1.Text = "Solicitud Aprobada con exito, se eleva solicitud a director de departamento";
            PanelAprobaciones.Visible = false;
            PanelSolicitudes.Visible = true;
            GvSolicitudesPendientes.DataBind();
        }

        protected void BtnRechazarSolicitud_Click(object sender, EventArgs e)
        {
            if (DdlVisita.SelectedValue.Equals("SI")) (new SolicitudesBLL()).RechazarSolicitudPorAsistenteFecha(Convert.ToInt32(LblId.Text), DdlVisita.SelectedValue.ToString(), TxtDetalle.Text, ChkVivienda.Checked, ChkAlimentacion.Checked, ChkSalud.Checked, ChkInfancia.Checked, ChkDefunciones.Checked, ChkMicroemprendimiento.Checked, ChkPSGubernamental.Checked, ChkMaquinaria.Checked, ChkPersonalMunicipal.Checked, ChkRebajaAseo.Checked, ChkAgua.Checked, ChkOtros.Checked, CVisita.SelectedDate, TxtSituacion.Text.Trim());
            else (new SolicitudesBLL()).RechazarSolicitudPorAsistente(Convert.ToInt32(LblId.Text), DdlVisita.SelectedValue.ToString(), TxtDetalle.Text, ChkVivienda.Checked, ChkAlimentacion.Checked, ChkSalud.Checked, ChkInfancia.Checked, ChkDefunciones.Checked, ChkMicroemprendimiento.Checked, ChkPSGubernamental.Checked, ChkMaquinaria.Checked, ChkPersonalMunicipal.Checked, ChkRebajaAseo.Checked, ChkAgua.Checked, ChkOtros.Checked, TxtSituacion.Text.Trim());
            Label2.Text = "Solicitud rechazada con exito";
            PanelAprobaciones.Visible = false;
            PanelSolicitudes.Visible = true;
            GvSolicitudesPendientes.DataBind();
        }

        protected void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (DdlVisita.SelectedValue.Equals("SI")) (new SolicitudesBLL()).ActualizarSolicitudConFecha(Convert.ToInt32(LblId.Text), DdlVisita.SelectedValue.ToString(), TxtDetalle.Text, CVisita.SelectedDate, ChkVivienda.Checked, ChkAlimentacion.Checked, ChkSalud.Checked, ChkInfancia.Checked, ChkDefunciones.Checked, ChkMicroemprendimiento.Checked, ChkPSGubernamental.Checked, ChkMaquinaria.Checked, ChkPersonalMunicipal.Checked, ChkRebajaAseo.Checked, ChkAgua.Checked, ChkOtros.Checked, TxtSituacion.Text.Trim());
            else (new SolicitudesBLL()).ActualizarSolicitud(Convert.ToInt32(LblId.Text), DdlVisita.SelectedValue.ToString(), TxtDetalle.Text, ChkVivienda.Checked, ChkAlimentacion.Checked, ChkSalud.Checked, ChkInfancia.Checked, ChkDefunciones.Checked, ChkMicroemprendimiento.Checked, ChkPSGubernamental.Checked, ChkMaquinaria.Checked, ChkPersonalMunicipal.Checked, ChkRebajaAseo.Checked, ChkAgua.Checked, ChkOtros.Checked, TxtSituacion.Text.Trim());
            Label1.Text = "Solicitud Actualizada con exito";
            PanelAprobaciones.Visible = false;
            PanelSolicitudes.Visible = true;
            GvSolicitudesPendientes.DataBind();
            // Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            // PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            // pdfDoc.Open();
            // pdfDoc.Add(new Paragraph("Welcome to dotnetfox"));
            // pdfDoc.Close();
            // Response.ContentType = "application/pdf";
            // Response.AddHeader("content-disposition", "attachment;" + "filename=sample.pdf");
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            // Response.Write(pdfDoc);
            // Response.End();            
        }

        protected void DdlVisita_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlVisita.SelectedValue.Equals("SI")) CVisita.Visible = true;
            else CVisita.Visible = false;
        }
    }
}