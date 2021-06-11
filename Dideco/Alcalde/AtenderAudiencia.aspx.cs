using Dideco.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Dideco.Alcalde
{
    public partial class AtenderAudiencia : System.Web.UI.Page
    {
        List<Audiencias> listado = new AudienciasBLL().ObtenerAudienciasPendientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);            
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            foreach (Audiencias item in listado)
            {
                if (e.Day.Date == new DateTime(item.FechaAudiencia.Value.Year, item.FechaAudiencia.Value.Month, item.FechaAudiencia.Value.Day))
                {
                    Literal Literal1 = new Literal();
                    Literal1.Text = "<br /><font size=-1 color=Gold>" + item.FechaAudiencia.Value.Hour + ":" + item.FechaAudiencia.Value.Minute + " " + item.RutBeneficiario + "</font>";
                    e.Cell.Font.Italic = true;
                    e.Cell.Font.Size = FontUnit.XLarge;
                    e.Cell.BackColor = System.Drawing.Color.Crimson;
                    e.Cell.BorderColor = System.Drawing.Color.Pink;
                    e.Cell.ForeColor = System.Drawing.Color.Snow;
                    e.Cell.Font.Name = "Courier New";
                    //e.Cell.Controls.AddAt(1, Literal1);
                }
            }
        }

        protected void BtnAtenderSolicitud_Click(object sender, EventArgs e)
        {
            (new AudienciasBLL()).AtenderAudiencia(Convert.ToInt32(LblId.Text), DateTime.Now, TxtSolicitud.Text.ToUpper(), TxtCompromiso.Text.ToUpper(), DdlDerivacion.SelectedValue);
            PanelAtencionAudiencia.Visible = false;
            PanelSeleccionarAudiencia.Visible = true;
            LblSolicitud.Text = "Audiencia atendida con exito";
            GvAudiencias.DataBind();
            Calendar1.DataBind();
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.munipuchuncavi.cl");
                mail.From = new MailAddress("no-reply@munipuchuncavi.cl");
                Personal destinatario = new Personal();
                string derivacion = DdlDerivacion.SelectedValue;
                if (derivacion.Equals("AREA OPERATIVA")) destinatario = (new PersonalBLL()).ObtenerDatos("DirectorAreaOperativa");
                if (derivacion.Equals("DIDECO")) destinatario = (new PersonalBLL()).ObtenerDatos("Dideco");
                if (derivacion.Equals("EDUCACION")) destinatario = (new PersonalBLL()).ObtenerDatos("Educacion");
                if (derivacion.Equals("FINANZAS")) destinatario = (new PersonalBLL()).ObtenerDatos("Finanzas");
                if (derivacion.Equals("INFORMATICA")) destinatario = (new PersonalBLL()).ObtenerDatos("Informatica");
                if (derivacion.Equals("MEDIO AMBIENTE")) destinatario = (new PersonalBLL()).ObtenerDatos("Ambiente");
                if (derivacion.Equals("OBRAS")) destinatario = (new PersonalBLL()).ObtenerDatos("DirectorObras");
                if (derivacion.Equals("RRPP")) destinatario = (new PersonalBLL()).ObtenerDatos("RRPP");
                if (derivacion.Equals("SECPLAN")) destinatario = (new PersonalBLL()).ObtenerDatos("DirectorSecplan");
                if (derivacion.Equals("TRANSITO")) destinatario = (new PersonalBLL()).ObtenerDatos("DirectorTransito");
                mail.To.Add(destinatario.Correo);
                string texto = "Estimado " + destinatario.Nombre + "\n\nCon fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + " desde alcaldia se a presentado una nueva solicitud para su departamento la cual consiste en \n\n" + TxtSolicitud.Text.ToUpper() + "\n\nMientras que la alcaldia se comprometio en \n\n" + TxtCompromiso.Text.ToUpper() + "\n\nSolicitado por \n\n" + TxtNombre.Text.ToUpper() + "\n\n\nRogamos no responder este mensaje";
                mail.Subject = "Nueva Solicitud";
                mail.Body = texto;
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("no-reply@munipuchuncavi.cl", "X_7iPLM");
                SmtpServer.EnableSsl = false;
                SmtpServer.Send(mail);
            }
            catch (Exception)
            {
                
            }
        }

        protected void GvAudiencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelSeleccionarAudiencia.Visible = false;
            PanelAtencionAudiencia.Visible = true;
            Audiencias aux = (new AudienciasBLL()).ObtenerAudiencia(Convert.ToInt32(GvAudiencias.SelectedValue));
            TxtRut.Text = aux.RutBeneficiario;
            TxtNombre.Text = aux.Beneficiario.Nombre;
            TxtContacto.Text = aux.Beneficiario.Contacto;
            TxtDireccion.Text = aux.Beneficiario.Direccion;
            TxtFechaNacimiento.Text = aux.Beneficiario.FechaNacimiento.Value.Day + "/" + aux.Beneficiario.FechaNacimiento.Value.Month + "/" + aux.Beneficiario.FechaNacimiento.Value.Year;
            TxtLocalidad.Text = aux.Beneficiario.Localidad;
            TxtSexo.Text = aux.Beneficiario.Genero;
            LblId.Text = aux.IdAudiencias.ToString();
            TxtSolicitud.Text = aux.Solicitud;
            TxtTipo.Text = aux.Tipo;
        }

        protected void RbtnYes_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnYes.Checked) {
                LblPreguntaMonto.Visible = false;
                RbtnDineroNo.Visible = false;
                RbtnDineroYes.Visible = false;
                LblEntregaDineroNo.Visible = false;
                LblEntregaDineroSi.Visible = false;
                LblMonto.Visible = false;
                TxtMonto.Visible = false;
                LblSolucion.Visible = false;
                TxtSolucion.Visible = false;
                BtnSolucion.Visible = false;
                LblDerivacion.Visible = true;
                DdlDerivacion.Visible = true;
                BtnAtenderSolicitud.Visible = true;
            }
        }

        protected void RbtnNo_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnNo.Checked) {
                LblPreguntaMonto.Visible = true;
                RbtnDineroNo.Visible = true;
                RbtnDineroYes.Visible = true;
                RbtnDineroNo.Checked = true;
                RbtnDineroYes.Checked = false;
                LblEntregaDineroSi.Visible = true;
                LblEntregaDineroNo.Visible = true;
                LblMonto.Visible = false;
                TxtMonto.Visible = false;
                LblSolucion.Visible = true;
                TxtSolucion.Visible = true;
                BtnSolucion.Visible = true;
                LblDerivacion.Visible = false;
                DdlDerivacion.Visible = false;
                BtnAtenderSolicitud.Visible = false;
            }
        }

        protected void RbtnDineroNo_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnDineroNo.Checked) {
                LblMonto.Visible = false;
                TxtMonto.Visible = false;
            }
        }

        protected void RbtnDineroYes_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnDineroYes.Checked) {
                LblMonto.Visible = true;
                TxtMonto.Visible = true;
            }
        }

        protected void RbtnDineroYes_CheckedChanged1(object sender, EventArgs e)
        {
            if (RbtnDineroYes.Checked)
            {
                LblMonto.Visible = true;
                TxtMonto.Visible = true;
            }
        }

        protected void RbtnDineroNo_CheckedChanged1(object sender, EventArgs e)
        {
            if (RbtnDineroNo.Checked)
            {
                LblMonto.Visible = false;
                TxtMonto.Visible = false;
            }
        }

        protected void BtnSolucion_Click(object sender, EventArgs e)
        {
            if (RbtnDineroYes.Checked)
            {
                if (TxtSolicitud.Text.Trim().Equals("") || TxtSolucion.Text.Trim().Equals("") || TxtCompromiso.Text.Trim().Equals(""))
                {
                    LblSolicitud.Text = "Para entregar solución debe llenar todos los campos";
                }
                else
                {
                    (new AudienciasBLL()).EntregarSolucionAlcaldeDinero(Convert.ToInt32(LblId.Text), DateTime.Now, TxtSolicitud.Text.ToUpper(), TxtCompromiso.Text.ToUpper(), TxtSolucion.Text.Trim(), Convert.ToInt32(TxtMonto.Text));
                    PanelAtencionAudiencia.Visible = false;
                    PanelSeleccionarAudiencia.Visible = true;
                    Calendar1.DataBind();
                    GvAudiencias.DataBind();
                    LblSolicitud.Text = "Audiencia atendida con exito";
                }
            }
            else {
                if (TxtSolicitud.Text.Trim().Equals("") || TxtCompromiso.Text.Trim().Equals(""))
                {
                    LblSolicitud.Text = "Para entregar solución debe llenar todos los campos";
                }
                else
                {
                    (new AudienciasBLL()).EntregarSolucionAlcaldeSinDinero(Convert.ToInt32(LblId.Text), DateTime.Now, TxtSolicitud.Text.ToUpper(), TxtCompromiso.Text.ToUpper(), TxtSolucion.Text.Trim());
                    PanelAtencionAudiencia.Visible = false;
                    PanelSeleccionarAudiencia.Visible = true;
                    Calendar1.DataBind();
                    GvAudiencias.DataBind();
                    LblSolicitud.Text = "Audiencia atendida con exito";
                }
            }
        }



        


        
    }
}