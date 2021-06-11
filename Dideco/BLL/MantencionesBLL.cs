using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Dideco.Entity;

namespace Dideco.BLL
{

    [DataObject]

    public class MantencionesBLL
    {

        DBDidecoEntidades context;

        public string AgregarMantencion(string placa, string detalle, Archivo archivo, int proxima)
        {
            context = new DBDidecoEntidades();
            Mantenciones aux = new Mantenciones() { Placa = placa, Fecha = DateTime.Now, Tipo = "MANTENCION", Detalle = detalle };
            Vehiculos aux2 = (from l in context.Vehiculos where placa == l.Placa select l).FirstOrDefault();
            if (aux2.Tipo == "RETROEXCAVADORA" || aux2.Tipo == "MOTONIVELADORA" || aux2.Tipo == "EXCAVADORA") aux2.ProximaMantencion = aux2.ProximaMantencion + 300;
            else aux2.ProximaMantencion = proxima;
            context.Mantenciones.AddObject(aux);
            string resultado = SubirArchivoAdjunto(archivo, aux.Placa);
            if (resultado.Equals("No se pudo subir archivo")) return "No se pudo subir archivo";
            if (resultado.Equals("Archivo no permitido")) return "Archivo no permitido";
            aux.Adjunto = resultado;
            context.SaveChanges();
            return "Reparación agregado correctamente";               
        }

        public string AgregarReparacion(string placa, string detalle, Archivo archivo) {
            context = new DBDidecoEntidades();
            Mantenciones aux = new Mantenciones() { Placa = placa, Fecha = DateTime.Now, Tipo = "REPARACION", Detalle = detalle };            
            context.Mantenciones.AddObject(aux);
            string resultado = SubirArchivoAdjunto(archivo, aux.Placa);
            if (resultado.Equals("No se pudo subir archivo")) return "No se pudo subir archivo";
            if (resultado.Equals("Archivo no permitido")) return "Archivo no permitido";
            aux.Adjunto = resultado;
            context.SaveChanges();
            return "Reparación agregado correctamente";            
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Mantenciones> ObtenerMantencionesTodas() {
            context = new DBDidecoEntidades();
            return (from l in context.Mantenciones where l.Tipo == "MANTENCION" orderby l.Fecha descending select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Mantenciones> ObtenerMantencionesVehiculo(string placa) {
            context = new DBDidecoEntidades();
            return (from l in context.Mantenciones where l.Placa == placa && l.Tipo == "MANTENCION" orderby l.Fecha descending select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Mantenciones> ObtenerReparacionesTodas() {
            context = new DBDidecoEntidades();
            return (from l in context.Mantenciones where l.Tipo == "REPARACION" orderby l.Fecha descending select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Mantenciones> ObtenerReparacionesVehiculo(string placa) {
            context = new DBDidecoEntidades();
            return (from l in context.Mantenciones where placa == l.Placa && l.Tipo == "REPARACION" orderby l.Fecha descending select l).ToList();
        }

        public Mantenciones ObtenerUltimaMantencion(string placa) {
            context = new DBDidecoEntidades();
            return (from l in context.Mantenciones where placa == l.Placa && l.Tipo == "MANTENCION" select l).LastOrDefault();
        }

        public string SubirArchivoAdjunto(Archivo archivo, string placa)
        {
            Boolean fileOK = false;
            if (archivo.Adjunto.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(archivo.Adjunto.FileName).ToLower();
                String[] allowedExtensions = { ".rar", ".RAR" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    archivo.Adjunto.PostedFile.SaveAs(string.Format("{0}{1}-{2}", archivo.Ruta, placa, archivo.Adjunto.FileName));
                    return string.Format("{0}{1}-{2}", archivo.Ruta, placa, archivo.Adjunto.FileName);
                }
                catch (Exception)
                {
                    return "No se pudo subir archivo";
                }
            }
            else
            {
                return "Archivo no permitido";
            }
        }

        public Mantenciones ObtenerMantencion(int idMantencion) {
            context = new DBDidecoEntidades();
            return (from l in context.Mantenciones where idMantencion == l.IdMantenciones select l).FirstOrDefault();
        }

    }
}