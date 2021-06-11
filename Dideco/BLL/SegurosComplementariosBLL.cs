using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Dideco.Entity;


namespace Dideco.BLL
{

    [DataObject]
    public class SegurosComplementariosBLL
    {
        DBDidecoEntidades context;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SegurosComplementarios> ObtenerTodosSeguros() {
            context = new DBDidecoEntidades();
            return (from l in context.SegurosComplementarios orderby l.FechaTermino ascending select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SegurosComplementarios> ObtenerSegurosPorPlaca(String placa){
            context = new DBDidecoEntidades();
            return (from l in context.SegurosComplementarios where l.Placa == placa orderby l.FechaTermino descending select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public SegurosComplementarios ObtenerSeguroVigentePorPlaca(String placa) {
            context = new DBDidecoEntidades();
            return (from l in context.SegurosComplementarios where DateTime.Compare((DateTime)l.FechaTermino, DateTime.Now) >= 0 && l.Placa == placa select l).LastOrDefault();
        }
        

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SegurosComplementarios> ObtenerSegurosVigentes()
        {
            context = new DBDidecoEntidades();
            return (from l in context.SegurosComplementarios where DateTime.Compare((DateTime)l.FechaTermino, DateTime.Now) >= 0 select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SegurosComplementarios> ObtenerSegurosPorVencer()
        {
            context = new DBDidecoEntidades();
            List<SegurosComplementarios> aux = ObtenerTodosSeguros();
            List<SegurosComplementarios> listado = new List<SegurosComplementarios>();
            foreach (SegurosComplementarios item in aux){
                int dias = Convert.ToDateTime(item.FechaTermino).Subtract(DateTime.Now).Days;
                if (dias <= 60 && dias >= 0) { 
                    listado.Add(item);
                }
            }
          
            return listado;
        }

        public string AgregarSeguro(String placa, DateTime fechaInicio, DateTime fechaTermino, Archivo adjunto) {
            context = new DBDidecoEntidades();
            SegurosComplementarios seguro = new SegurosComplementarios() { Placa = placa, FechaInicio = fechaInicio, FechaTermino = fechaTermino };
            context.SegurosComplementarios.AddObject(seguro);
            string resultado = SubirArchivoAdjunto(adjunto, seguro.Placa, seguro.IdSeguro);
            if (resultado.Equals("No se pudo subir archivo")) return "No se pudo subir archivo";
            if (resultado.Equals("Archivo no permitido")) return "Archivo no permitido";
            seguro.Adjunto = resultado;
            context.SaveChanges();
            return "Seguro agregado Correctamente";
        
        }

        public string SubirArchivoAdjunto(Archivo archivo, string placa, int id) {
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
                    archivo.Adjunto.PostedFile.SaveAs(string.Format("{0}{1}{3}-{2}", archivo.Ruta, placa, archivo.Adjunto.FileName,id.ToString()));
                    return string.Format("{0}{1}{3}-{2}", archivo.Ruta, placa, archivo.Adjunto.FileName,id.ToString());
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

        public SegurosComplementarios ObtenerSeguro(int id) {
            context = new DBDidecoEntidades();
            return (from l in context.SegurosComplementarios where l.IdSeguro == id select l).FirstOrDefault();
        }

    }
}