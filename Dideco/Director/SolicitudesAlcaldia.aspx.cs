using Dideco.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Dideco.DirectorAreaOperativa
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
                string depto = "DIDECO";
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
            if (aux.FechaAsignacion == null)
            {
                BtnDerivar.Visible = true;
            }
            else
            {
                BtnDerivar.Visible = false;
                Solicitudes aux2 = (new SolicitudesBLL()).ObtenerSolicitudPorId(Convert.ToInt32(aux.IdDepto));
                LblSolicitud.Text = string.Format("LA SOLICITUD FUE DERIVADA A LA ASISTENTE " + (new PersonalBLL()).ObtenerNombre(aux2.Asistente) + " EL DÍA " + aux.FechaAsignacion.Value.Day + "/" + aux.FechaAsignacion.Value.Month + "/" + aux.FechaAsignacion.Value.Year + " CON EL ID DE SOLICITUD NUMERO " + aux.IdDepto);
            }
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
                    string depto = "DIDECO";
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

        protected void BtnDerivar_Click(object sender, EventArgs e)
        {
            BtnAtenderSolicitud.Visible = false;
            BtnDerivar.Visible = false;
            ChkAgua.Visible = true;
            ChkAlimentacion.Visible = true;
            ChkDefunciones.Visible = true;
            ChkInfancia.Visible = true;
            ChkMaquinaria.Visible = true;
            ChkMicroemprendimiento.Visible = true;
            ChkOtros.Visible = true;
            ChkPersonalMunicipal.Visible = true;
            ChkPSGubernamental.Visible = true;
            ChkRebajaAseo.Visible = true;
            ChkSalud.Visible = true;
            ChkVivienda.Visible = true;
            LblMotivo.Visible = true;
            LblRSH.Visible = true;
            RbRegistroSocialFalse.Visible = true;
            RbRegistroSocialTrue.Visible = true;
            Label1.Visible = true;
            DdlAsistente.Visible = true;
            BtnAgregarSolicitud.Visible = true;
            LblRespuesta.Visible = false;
            TxtSolucion.Visible = false;
        }

        protected void BtnAgregarSolicitud_Click(object sender, EventArgs e)
        {
            Beneficiario aux = new BeneficiarioBLL().BuscarPorRut(TxtRut.Text);
            string detalle = string.Format("LA PERSONA SOLICITA: " + TxtSolicitud.Text + ". EL MUNICIPIO SE COMPROMETE A " + TxtCompromiso.Text);
            bool rgh;
            if (RbRegistroSocialTrue.Checked) rgh = true;
            else rgh = false;
            string porcentaje;
            if (rgh == true) porcentaje = DdlPorcentaje.SelectedValue.ToString();
            else porcentaje = "0";
            int idSolicitud = new SolicitudesBLL().AgregarSolicitud2(aux, ChkVivienda.Checked, ChkAlimentacion.Checked, ChkSalud.Checked, ChkInfancia.Checked, ChkDefunciones.Checked, ChkMicroemprendimiento.Checked, ChkPSGubernamental.Checked, ChkMaquinaria.Checked, ChkPersonalMunicipal.Checked, ChkRebajaAseo.Checked, ChkAgua.Checked, ChkOtros.Checked, HttpContext.Current.User.Identity.Name, detalle, rgh, DdlAsistente.SelectedValue, porcentaje, Convert.ToInt32(GvAudiencias.SelectedValue));
            LblError.Text = idSolicitud.ToString();
            new AudienciasBLL().ActualizarAudiencia(Convert.ToInt32(GvAudiencias.SelectedValue), idSolicitud);
            ChkAgua.Visible = false;
            ChkAlimentacion.Visible = false;
            ChkDefunciones.Visible = false;
            ChkInfancia.Visible = false;
            ChkMaquinaria.Visible = false;
            ChkMicroemprendimiento.Visible = false;
            ChkOtros.Visible = false;
            ChkPersonalMunicipal.Visible = false;
            ChkPSGubernamental.Visible = false;
            ChkRebajaAseo.Visible = false;
            ChkSalud.Visible = false;
            ChkVivienda.Visible = false;
            LblMotivo.Visible = false;
            LblRSH.Visible = false;
            RbRegistroSocialFalse.Visible = false;
            RbRegistroSocialTrue.Visible = false;
            Label1.Visible = false;
            DdlAsistente.Visible = false;
            BtnAgregarSolicitud.Visible = false;
            LblRespuesta.Visible = true;
            TxtSolucion.Visible = true;
            BtnAtenderSolicitud.Visible = true;
        }

        protected void RbRegistroSocialTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (RbRegistroSocialTrue.Checked == true)
            {
                DdlPorcentaje.Visible = true;
                LblPorcentaje.Visible = true;
                if (DdlPorcentaje.Items.Count < 1)
                {
                    for (int i = 0; i < 101; i++)
                    {
                        DdlPorcentaje.Items.Add(new ListItem(string.Format(i + "%"), i.ToString()));
                    }
                }
            }
        }

        protected void RbRegistroSocialFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (RbRegistroSocialFalse.Checked == true)
            {
                DdlPorcentaje.Visible = false;
                LblPorcentaje.Visible = false;
            }
        }
    }
}