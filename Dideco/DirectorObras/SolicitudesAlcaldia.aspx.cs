using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.BLL;
using System.Net.Mail;

namespace Dideco.DirectorObras
{
    public partial class SolicitudesAlcaldia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
            string[] aux = new string[] { "IdAudiencias" };
            try
            {
                string depto = "OBRAS";
                GvAudiencias.DataSourceID = "";
                GvAudiencias.DataSource = (new AudienciasBLL()).ObtenerAudienciasSinSolucionPorDepartamento(depto);
                GvAudiencias.DataKeyNames = aux;
                GvAudiencias.DataBind();
            }
            catch (Exception)
            {

            }

        }

        protected void GvAudiencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Audiencias aux = (new AudienciasBLL()).ObtenerAudiencia(Convert.ToInt32(GvAudiencias.SelectedValue));
            TxtRut.Text = aux.RutBeneficiario;
            TxtNombre.Text = aux.Beneficiario.Nombre;
            TxtCompromiso.Text = aux.Compromiso;
            TxtContacto.Text = aux.Beneficiario.Contacto;
            TxtDireccion.Text = aux.Beneficiario.Direccion;
            TxtFechaNacimiento.Text = string.Format(aux.Beneficiario.FechaNacimiento.Value.Day + "/" + aux.Beneficiario.FechaNacimiento.Value.Month + "/" + aux.Beneficiario.FechaNacimiento.Value.Year);
            TxtLocalidad.Text = aux.Beneficiario.Localidad;
            TxtSexo.Text = aux.Beneficiario.Genero;
            TxtSolicitud.Text = aux.Solicitud;
            LblId.Text = aux.IdAudiencias.ToString();
            LblSolicitud.Text = "";
        }

        protected void BtnAtenderSolicitud_Click(object sender, EventArgs e)
        {
            if (TxtSolucion.Text != "")
            {
                (new AudienciasBLL()).SolucionarAudiencia(Convert.ToInt32(LblId.Text), TxtSolucion.Text);
                // Enviar correo a alcalde

                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.munipuchuncavi.cl");
                    mail.From = new MailAddress("no-reply@munipuchuncavi.cl");
                    Personal destinatario = (new PersonalBLL()).ObtenerDatos("Alcalde");
                    Audiencias audiencia = (new AudienciasBLL()).ObtenerAudiencia(Convert.ToInt32(LblId.Text));
                    mail.To.Add(destinatario.Correo);
                    string texto = "Estimad@ " + destinatario.Nombre + "\n\nCon fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + " el director de departamento a respondido su audiencia n° " + audiencia.IdAudiencias + " en la cual se solicitaba " + audiencia.Solicitud + " por parte del contribuyente " + audiencia.Beneficiario.Nombre + ", el compromiso que asumio la alcaldia fue " + audiencia.Compromiso + ". Mientras que la solución otorgada por el director fue " + TxtSolucion.Text + "\n\nEste es un mensaje automatico, rogamos no responder el mensaje";
                    mail.Subject = "Respuesta a Solicitud";
                    mail.Body = texto;
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("no-reply@munipuchuncavi.cl", "X_7iPLM");
                    SmtpServer.EnableSsl = false;
                    SmtpServer.Send(mail);
                }
                catch (Exception)
                {

                }
                Panel1.Visible = true;
                Panel2.Visible = false;
                string[] aux = new string[] { "IdAudiencias" };
                try
                {
                    string depto = "OBRAS";
                    GvAudiencias.DataSourceID = "";
                    GvAudiencias.DataSource = (new AudienciasBLL()).ObtenerAudienciasSinSolucionPorDepartamento(depto);
                    GvAudiencias.DataKeyNames = aux;
                    GvAudiencias.DataBind();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                LblError.Text = "Escriba una solución";
            }
        }
    }
}