using Dideco.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dideco.Reportes
{
    public partial class SolicitudesBeneficiario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
            LblUsuario.Text = usuario;
        }

        public string ObtenerMotivo(int id)
        {
            Solicitudes solicitud = (new SolicitudesBLL()).ObtenerSolicitudPorId(id);
            string motivo = "";
            List<string> contador = new List<string>();
            if (solicitud.Vivienda == true) contador.Add("VIVIENDA");
            if (solicitud.Alimentacion == true) contador.Add("ALIMENTACION");
            if (solicitud.Salud == true) contador.Add("SALUD");
            if (solicitud.Infancia == true) contador.Add("INFANCIA");
            if (solicitud.Defunciones == true) contador.Add("DEFUNCIONES");
            if (solicitud.Microemprendimiento == true) contador.Add("MICROEMPRENDIMIENTO");
            if (solicitud.PSGubernamental == true) contador.Add("PROGRAMA SOCIAL GUBERNAMENTAL");
            if (solicitud.Maquinaria == true) contador.Add("MAQUINARIA");
            if (solicitud.PersonalMunicipal == true) contador.Add("PERSONAL MUNICIPAL");
            if (solicitud.RebajaAseo == true) contador.Add("REBAJA DE ASEO");
            if (solicitud.EntregaAgua == true) contador.Add("ENTREGA DE AGUA");
            if (solicitud.Otros == true) contador.Add("OTROS");
            int auxMotivo = contador.Count();
            if (auxMotivo == 1)
            {
                foreach (string item in contador)
                {
                    motivo = motivo + item;
                }
            }
            else
            {
                foreach (string item in contador)
                {
                    motivo = motivo + item;
                    auxMotivo = auxMotivo - 1;
                    if (auxMotivo >= 1)
                    {
                        if (auxMotivo == 1) motivo = motivo + " Y ";
                        else motivo = motivo + ", ";
                    }
                    else
                    {
                        motivo = motivo + ".";
                    }

                }
            }
            return motivo;
        }

        public string BuscarAsistente(string asistente)
        {
            return (new PersonalBLL()).ObtenerNombre(asistente);
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            try
            {
                BtnImprimir.Visible = true;
                BtnImprimir.Visible = true;
                Panel1.Visible = true;
                LblBeneficiario.Text = (new BeneficiarioBLL()).ObtenerNombreBeneficiario(TxtRut.Text.Trim());
            }
            catch (Exception)
            {
                BtnImprimir.Visible = false;
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
        }
        protected void GvSolicitudesPorRut_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvSolicitudesPorRut.SelectedValue);
            Solicitudes solicitud = (new SolicitudesBLL()).ObtenerSolicitudPorId(id);
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            string ruta = Server.MapPath("~/img");
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(ruta + "/Encabezado.jpg");
            imagen.ScalePercent(40f);
            imagen.Alignment = Element.ALIGN_LEFT;
            pdfDoc.Add(imagen);
            iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance(ruta + "/Pie.jpg");
            imagen2.ScalePercent(40f);
            imagen2.SetAbsolutePosition(130, 4);
            imagen2.Alignment = Element.ALIGN_MIDDLE;
            pdfDoc.Add(imagen2);
            Paragraph titulo = new Paragraph();
            titulo.Add(new Chunk("Ficha de ingreso - DIDECO").SetUnderline(0, -1));
            titulo.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(titulo);
            pdfDoc.Add(new Paragraph(" "));
            pdfDoc.Add(new Chunk("                            Datos personales"));
            //Crear tabla
            PdfPTable datosPersonales = new PdfPTable(2);
            //Modificar celda - color
            PdfPCell fila1 = new PdfPCell();
            fila1.BackgroundColor = new iTextSharp.text.Color(179, 255, 255);
            //Agregar nombre
            fila1.Phrase = new Phrase("Nombre");
            datosPersonales.AddCell(fila1);
            datosPersonales.AddCell(solicitud.Beneficiario.Nombre);
            //Agregar RUT
            fila1.Phrase = new Phrase("RUT");
            datosPersonales.AddCell(fila1);
            datosPersonales.AddCell(solicitud.Beneficiario.Rut);
            //Agregar fecha de nacimiento
            fila1.Phrase = new Phrase("Fecha de nacimiento");
            datosPersonales.AddCell(fila1);
            datosPersonales.AddCell(string.Format(solicitud.Beneficiario.FechaNacimiento.Value.Day + "/" + solicitud.Beneficiario.FechaNacimiento.Value.Month + "/" + solicitud.Beneficiario.FechaNacimiento.Value.Year));
            //Agregar Genero
            fila1.Phrase = new Phrase("Genero");
            datosPersonales.AddCell(fila1);
            datosPersonales.AddCell(solicitud.Beneficiario.Genero);
            //Edad
            fila1.Phrase = new Phrase("Edad");
            datosPersonales.AddCell(fila1);
            TimeSpan aux = (DateTime.Now - (DateTime)solicitud.Beneficiario.FechaNacimiento);
            int edad = aux.Days / 365;
            datosPersonales.AddCell(edad.ToString());

            pdfDoc.Add(datosPersonales);
            pdfDoc.Add(new Paragraph(" "));

            pdfDoc.Add(new Chunk("                            Datos de la atencion"));
            //Atencion
            PdfPTable atencion = new PdfPTable(2);

            //Fecha
            fila1.Phrase = new Phrase("Fecha de atención");
            atencion.AddCell(fila1);
            atencion.AddCell(string.Format(solicitud.FechaSolicitud.Value.Day + "/" + solicitud.FechaSolicitud.Value.Month + "/" + solicitud.FechaSolicitud.Value.Year));
            //Motivo
            fila1.Phrase = new Phrase("Motivo de Atencion");
            atencion.AddCell(fila1);
            string motivo = "";
            List<string> contador = new List<string>();
            if (solicitud.Vivienda == true) contador.Add("VIVIENDA");
            if (solicitud.Alimentacion == true) contador.Add("ALIMENTACION");
            if (solicitud.Salud == true) contador.Add("SALUD");
            if (solicitud.Infancia == true) contador.Add("INFANCIA");
            if (solicitud.Defunciones == true) contador.Add("DEFUNCIONES");
            if (solicitud.Microemprendimiento == true) contador.Add("MICROEMPRENDIMIENTO");
            if (solicitud.PSGubernamental == true) contador.Add("PROGRAMA SOCIAL GUBERNAMENTAL");
            if (solicitud.Maquinaria == true) contador.Add("MAQUINARIA");
            if (solicitud.PersonalMunicipal == true) contador.Add("PERSONAL MUNICIPAL");
            if (solicitud.RebajaAseo == true) contador.Add("REBAJA DE ASEO");
            if (solicitud.EntregaAgua == true) contador.Add("ENTREGA DE AGUA");
            if (solicitud.Otros == true) contador.Add("OTROS");
            int auxMotivo = contador.Count();
            if (auxMotivo == 1)
            {
                foreach (string item in contador)
                {
                    motivo = motivo + item;
                }
            }
            else
            {
                foreach (string item in contador)
                {
                    motivo = motivo + item;
                    auxMotivo = auxMotivo - 1;
                    if (auxMotivo >= 1)
                    {
                        if (auxMotivo == 1) motivo = motivo + " Y ";
                        else motivo = motivo + ", ";
                    }
                    else
                    {
                        motivo = motivo + ".";
                    }

                }
            }
            atencion.AddCell(motivo);
            //Registro social de hogares
            fila1.Phrase = new Phrase("RSH en la comuna");
            atencion.AddCell(fila1);
            if (solicitud.RegistroSocialHogar == true)
            {
                atencion.AddCell(new Phrase("SI"));
                fila1.Phrase = new Phrase("Porcentaje del RSH");
                atencion.AddCell(fila1);
                atencion.AddCell(new Phrase(solicitud.PorcentajeRSH.ToString() + "%"));
            }
            else
            {
                atencion.AddCell(new Phrase("NO"));
            }
            //Visita
            fila1.Phrase = new Phrase("¿Necesitaba visita?");
            atencion.AddCell(fila1);
            atencion.AddCell(solicitud.Visita);
            //Fecha de visita
            if (solicitud.Visita.Equals("SI"))
            {
                fila1.Phrase = new Phrase("Fecha de visita");
                atencion.AddCell(fila1);
                atencion.AddCell(string.Format(solicitud.FechaVisita.Value.Day + "/" + solicitud.FechaVisita.Value.Month + "/" + solicitud.FechaVisita.Value.Year));
            }
            //Detalles
            fila1.Phrase = new Phrase("Detalles");
            atencion.AddCell(fila1);
            atencion.AddCell(solicitud.DetallesCaso);
            pdfDoc.Add(atencion);
            pdfDoc.Add(new Paragraph(" "));
                        
            pdfDoc.Add(new Paragraph(" "));
            string aprobacion;
            try
            {
                aprobacion = string.Format("LA ASISTENTE SOCIAL : " + BuscarAsistente(solicitud.Asistente) + " EVALUA LA SOLICITUD COMO : " + solicitud.AprobacionAsistente + " EN LA FECHA " + solicitud.FechaAprobacionAsistente.Value.Day + "/" + solicitud.FechaAprobacionAsistente.Value.Month + "/" + solicitud.FechaAprobacionAsistente.Value.Year);
            }
            catch (Exception)
            {

                aprobacion = "LA ASISTENTE AUN NO EVALUA LA SOLICITUD";
            }
            Paragraph asistente2 = new Paragraph(aprobacion);
            PdfPTable asistente = new PdfPTable(1);
            asistente.DefaultCell.Border = Rectangle.NO_BORDER;
            asistente.AddCell(asistente2);
            pdfDoc.Add(asistente);
            pdfDoc.Add(new Paragraph(" "));
            pdfDoc.Add(new Paragraph(" "));

            PdfPTable directorTabla = new PdfPTable(1);
            directorTabla.DefaultCell.Border = Rectangle.NO_BORDER;

            Paragraph director = new Paragraph("EL DIRECTOR ESTABLECE QUE LA SOLICITUD ES " + solicitud.AprobacionDirector.ToString());
            directorTabla.AddCell(director);
            pdfDoc.Add(directorTabla);
            pdfDoc.Add(new Paragraph(" "));
            pdfDoc.Add(new Paragraph(" "));
            pdfDoc.Add(new Paragraph(" "));
            pdfDoc.Add(new Paragraph(" "));
            pdfDoc.Add(new Paragraph(" "));
            pdfDoc.Add(new Paragraph(" "));
            pdfDoc.Add(new Paragraph(" "));
            //Jefatura aux2 = (new JefaturaBLL()).ObtenerJefe(Convert.ToInt32(DropDownList1.SelectedValue));

            //Paragraph firma = new Paragraph(string.Format(aux2.Nombre + "\n" + aux2.Tipo));
            //firma.Alignment = Element.ALIGN_CENTER;
            //pdfDoc.Add(firma);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" +
                                           "filename=" + string.Format(solicitud.IdSolicitud + "-" + solicitud.Beneficiario.Rut + ".pdf"));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}