using Dideco.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dideco.SecreAlcaldia
{
    public partial class AsignarAudiencias : System.Web.UI.Page
    {
        List<Audiencias> listado = new AudienciasBLL().ObtenerAudienciasPendientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
            Calendar1.SelectedDate = DateTime.Now;
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
                    e.Cell.Controls.AddAt(1, Literal1);
                }
            }
        }

        protected void GvAudiencieas_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelAudiencias.Visible = false;
            LblAux.Text = GvAudiencieas.SelectedValue.ToString();
            PanelAsignar.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fecha = Calendar1.SelectedDate;
            PanelHorario.Visible = true;
            PanelAsignar.Visible = false;
            LblFecha.Text = Calendar1.SelectedDate.ToString();
            List<Audiencias> list = new AudienciasBLL().ObtenerAudienciasPendientesPorFecha(Calendar1.SelectedDate);
            LblHorarios.Text = " ";
            foreach (Audiencias item in list)
            {
                LblHorarios.Text = LblHorarios.Text + item.FechaAudiencia.Value.Hour + ":" + item.FechaAudiencia.Value.Minute + " " + item.Beneficiario.Nombre + "<br/>";
            }
        }

        protected void BtnAsignar_Click(object sender, EventArgs e)
        {
            string aux = DdlHorario.SelectedItem.ToString();
            DateTime fecha = Convert.ToDateTime(LblFecha.Text);
            PanelAudiencias.Visible = true;
            if (aux == "08:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 8, 00, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "08:30") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 8, 30, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "09:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 9, 00, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "09:30") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 9, 30, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "10:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 10, 00, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "10:30") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 10, 30, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "11:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 11, 00, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "11:30") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 11, 30, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "12:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 12, 00, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "12:30") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 12, 30, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "13:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 13, 00, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "13:30") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 13, 30, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "14:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 14, 00, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "14:30") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 14, 30, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "15:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 15, 00, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "15:30") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 15, 30, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "16:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 16, 00, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "16:30") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 16, 30, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "17:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 17, 00, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "17:30") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 17, 30, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "18:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 18, 00, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "18:30") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 18, 30, 0), Convert.ToInt32(LblAux.Text));
            if (aux == "19:00") LblResult.Text = new AudienciasBLL().AsignarHorario(new DateTime(fecha.Year, fecha.Month, fecha.Day, 19, 00, 0), Convert.ToInt32(LblAux.Text));
            PanelHorario.Visible = false;

            GvAudiencieas.DataBind();
        }
    }
}