using Dideco.BLL;
using Dideco.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dideco.Alcalde
{
    public partial class EstadoAudiencia : System.Web.UI.Page
    {
        protected string cancelada;
        protected string pendiente;
        protected string solucionada;
        protected string atendida;

        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
        }



        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string[] aux = new string[] { "Rut" };
            try
            {
                GvBeneficiarios.DataSourceID = "";
                GvBeneficiarios.DataSource = (new BeneficiarioBLL()).BuscarPorNombreRut(TxtNombre.Text);
                GvBeneficiarios.DataKeyNames = aux;
                GvBeneficiarios.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void GvBeneficiarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelBusqueda.Visible = false;
            PanelAudiencias.Visible = true;
            List<Estadistica2> listado = new EstadisticasBLL().AudienciasPorRut(GvBeneficiarios.SelectedValue.ToString());
            foreach (Estadistica2 item in listado)
            {
                if (item.Localidad == "SOLICITADAS") pendiente = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "SOLUCIONADA") solucionada = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "ATENDIDA") atendida = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
            }
        }

        protected void GvAudiencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvAudiencias.SelectedValue);
            Audiencias aux = (new AudienciasBLL()).ObtenerAudiencia(id);
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            string ruta = Server.MapPath("~/img");
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(ruta + "/Encabezado2.jpg");
            imagen.ScalePercent(40f);
            imagen.Alignment = Element.ALIGN_LEFT;
            pdfDoc.Add(imagen);
            iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance(ruta + "/Pie2.jpg");
            imagen2.ScalePercent(40f);
            imagen2.SetAbsolutePosition(130, 4);
            imagen2.Alignment = Element.ALIGN_MIDDLE;
            pdfDoc.Add(imagen2);
            Paragraph titulo = new Paragraph();
            titulo.Add(new Chunk("FICHA DE AUDIENCIAS").SetUnderline(0, -1));
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
            datosPersonales.AddCell(aux.Beneficiario.Nombre);
            //Agregar RUT
            fila1.Phrase = new Phrase("RUT");
            datosPersonales.AddCell(fila1);
            datosPersonales.AddCell(aux.Beneficiario.Rut);
            //Agregar fecha de nacimiento
            fila1.Phrase = new Phrase("Fecha de nacimiento");
            datosPersonales.AddCell(fila1);
            datosPersonales.AddCell(string.Format(aux.Beneficiario.FechaNacimiento.Value.Day + "/" + aux.Beneficiario.FechaNacimiento.Value.Month + "/" + aux.Beneficiario.FechaNacimiento.Value.Year));
            //Agregar Genero
            fila1.Phrase = new Phrase("Genero");
            datosPersonales.AddCell(fila1);
            datosPersonales.AddCell(aux.Beneficiario.Genero);
            //Edad
            fila1.Phrase = new Phrase("Edad");
            datosPersonales.AddCell(fila1);
            TimeSpan aux2 = (DateTime.Now - (DateTime)aux.Beneficiario.FechaNacimiento);
            int edad = aux2.Days / 365;
            datosPersonales.AddCell(edad.ToString());

            pdfDoc.Add(datosPersonales);
            pdfDoc.Add(new Paragraph(" "));

            pdfDoc.Add(new Chunk("                            Audiencia"));
            //Atencion
            PdfPTable atencion = new PdfPTable(2);

            //Estado de audiencia
            fila1.Phrase = new Phrase("Estado de audiencia");
            atencion.AddCell(fila1);
            atencion.AddCell(aux.Estado);

            //Fecha solicitud de audiencia
            fila1.Phrase = new Phrase("Fecha de solicitud de audiencia");
            atencion.AddCell(fila1);
            atencion.AddCell(string.Format(aux.FechaSolicitudAudiencia.Value.Day + "/" + aux.FechaSolicitudAudiencia.Value.Month + "/" + aux.FechaSolicitudAudiencia.Value.Year));

            //Fecha de audiencia
            fila1.Phrase = new Phrase("Fecha de audiencia");
            atencion.AddCell(fila1);
            atencion.AddCell(string.Format(aux.FechaAudiencia.Value.Day + "/" + aux.FechaAudiencia.Value.Month + "/" + aux.FechaAudiencia.Value.Year));

            //Hora de audiencia
            fila1.Phrase = new Phrase("Hora de audiencia");
            atencion.AddCell(fila1);
            atencion.AddCell(string.Format(aux.FechaAudiencia.Value.Hour + ":" + aux.FechaAudiencia.Value.Minute));

            //Solicitud            
            fila1.Phrase = new Phrase("Solicitud");
            atencion.AddCell(fila1);
            atencion.AddCell(aux.Solicitud);

            //Compromiso
            fila1.Phrase = new Phrase("Compromiso");
            atencion.AddCell(fila1);
            if (aux.Compromiso == null || aux.Compromiso == "") atencion.AddCell("SIN COMPROMISO");
            else atencion.AddCell(aux.Compromiso);

            //Derivacion
            fila1.Phrase = new Phrase("Derivación");
            atencion.AddCell(fila1);
            if (aux.Derivacion == null || aux.Derivacion == "") atencion.AddCell("NO SE DERIVO");
            else atencion.AddCell(aux.Derivacion);

            //Fecha de derivacion
            fila1.Phrase = new Phrase("Fecha de derivación");
            atencion.AddCell(fila1);
            if (aux.FechaDerivacion == null) atencion.AddCell("NO SE DERIVO");
            else atencion.AddCell(string.Format(aux.FechaDerivacion.Value.Day + "/" + aux.FechaDerivacion.Value.Month + "/" + aux.FechaDerivacion.Value.Year));

            //Solucion
            fila1.Phrase = new Phrase("Solución");
            atencion.AddCell(fila1);
            if (aux.Solucion == null || aux.Solucion == "") atencion.AddCell("SIN SOLUCIÓN");
            else atencion.AddCell(aux.Solucion);

            //Fecha de Solución
            fila1.Phrase = new Phrase("Fecha de solución");
            atencion.AddCell(fila1);
            if (aux.FechaSolucion == null) atencion.AddCell("SIN SOLUCIÓN");
            else atencion.AddCell(string.Format(aux.FechaSolucion.Value.Day + "/" + aux.FechaSolucion.Value.Month + "/" + aux.FechaSolucion.Value.Year));

            //Monto entregado
            fila1.Phrase = new Phrase("Entrega de dinero");
            atencion.AddCell(fila1);
            if (aux.MontoEntregado == null) atencion.AddCell("NO SE ENTREGARON RECURSOS");
            else atencion.AddCell(string.Format(aux.MontoEntregado.ToString()));

            pdfDoc.Add(atencion);
            pdfDoc.Add(new Paragraph(" "));


            //Jefatura aux2 = (new JefaturaBLL()).ObtenerJefe(Convert.ToInt32(DropDownList1.SelectedValue));

            //Paragraph firma = new Paragraph(string.Format(aux2.Nombre + "\n" + aux2.Tipo));
            //firma.Alignment = Element.ALIGN_CENTER;
            //pdfDoc.Add(firma);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" +
                                           "filename=" + string.Format(aux.IdAudiencias + "-" + aux.Beneficiario.Rut + ".pdf"));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}