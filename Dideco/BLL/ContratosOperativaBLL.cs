using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.UI.WebControls;
using Dideco.Entity;

namespace Dideco.BLL
{
    [DataObject]
    public class ContratosOperativaBLL
    {
        DBDidecoEntidades context;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ContratosOperativa> ObtenerContratos()
        {
            context = new DBDidecoEntidades();
            return (from l in context.ContratosOperativa select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ContratosView> ObtenerContratosVigentes()
        {
            context = new DBDidecoEntidades();
            List<ContratosOperativa> listado = (from l in context.ContratosOperativa where DateTime.Compare(l.FechaExpiracion, DateTime.Now) >=0 orderby l.FechaExpiracion ascending select l).ToList();
            List<ContratosView> listado2 = new List<ContratosView>();
            foreach (ContratosOperativa item in listado)
            {
                int gastos = (new GastosContratosBLL()).GastosContrato(item.IdContrato);
                if (item.Monto >= gastos) listado2.Add((new ContratosView(){Nombre = item.Nombre, IdContrato = item.IdContrato, Detalle = item.Detalle, FechaExpiracion = item.FechaExpiracion, FechaInicio = item.FechaInicio, Monto = Convert.ToInt32(item.Monto), Gastos = gastos, Adjunto = item.Adjunto}));
            }
            return listado2;
        }

        public ContratosView ObtenerContrato(int idContrato)
        {
            context = new DBDidecoEntidades();
            ContratosOperativa aux = (from l in context.ContratosOperativa where idContrato == l.IdContrato select l).FirstOrDefault();
            ContratosView aux2 = new ContratosView() {IdContrato = aux.IdContrato, Adjunto = aux.Adjunto, Detalle = aux.Detalle, FechaExpiracion = aux.FechaExpiracion, FechaInicio = aux.FechaInicio, Monto = Convert.ToInt32(aux.Monto), Nombre = aux.Nombre };
            aux2.Gastos = (new GastosContratosBLL()).GastosContrato(idContrato);
            return aux2;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ContratosView> ContratosExpirando()
        {
            context = new DBDidecoEntidades();
            List<ContratosView> listado = ObtenerContratosVigentes();
            List<ContratosView> listado2 = new List<ContratosView>();
            foreach (ContratosView item in listado)
            {
                int gastos = (new GastosContratosBLL()).GastosContrato(item.IdContrato);
                int valor = item.FechaExpiracion.Subtract(DateTime.Now).Days;
                if ((item.Monto * 0.8) < gastos || item.FechaExpiracion.Subtract(DateTime.Now).Days < 30) listado2.Add(item);                
            }
            return listado2;
        }

        public string AgregarContrato(string nombre, string detalle, DateTime fechaInicio, DateTime fechaExpiracion, int monto, Archivo archivo)
        {
            context = new DBDidecoEntidades();
            ContratosOperativa aux = new ContratosOperativa() { Nombre = nombre, Detalle = detalle, FechaInicio = fechaInicio, FechaExpiracion = fechaExpiracion, Monto = monto, Estado = "VIGENTE" };
            context.ContratosOperativa.AddObject(aux);
            string resultado = SubirArchivoAdjunto(archivo, aux.IdContrato);
            if (resultado.Equals("No se pudo subir el archivo")) return "No se pudo subir el archivo";
            if (resultado.Equals("Archivo no permitido")) return "Archivo no permitido";
            aux.Adjunto = resultado;
            context.SaveChanges();
            return "Contrato agregado correctamente";
        }

        public string SubirArchivoAdjunto(Archivo archivo, int idContrato)
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
                    archivo.Adjunto.PostedFile.SaveAs(string.Format("{0}{1}-{2}", archivo.Ruta, idContrato, archivo.Adjunto.FileName));
                    return string.Format("{0}{1}-{2}", archivo.Ruta, idContrato, archivo.Adjunto.FileName);
                }
                catch (Exception)
                {
                    return "No se pudo subir el archivo";
                }
            }
            else
            {
                return "Archivo no permitido";
            }
        }


        public void ModificarContrato(int idContrato, DateTime fechaExp, int suma) {
            context = new DBDidecoEntidades();
            ContratosOperativa aux = (from l in context.ContratosOperativa where idContrato == l.IdContrato select l).FirstOrDefault();
            aux.FechaExpiracion = fechaExp;
            aux.Monto = aux.Monto + suma;
            context.SaveChanges();
        }

        public void ModificarContrato2(int idContrato, int suma)
        {
            context = new DBDidecoEntidades();
            ContratosOperativa aux = (from l in context.ContratosOperativa where idContrato == l.IdContrato select l).FirstOrDefault();            
            aux.Monto = aux.Monto + suma;
            context.SaveChanges();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ContratosView> BuscarContratos(string nombre) {
            try
            {
                nombre = nombre.ToUpper().Trim();
            }
            catch (Exception)
            {
              
            } 
            context = new DBDidecoEntidades();
            List<ContratosOperativa> listado = (from l in context.ContratosOperativa where l.Nombre.Contains(nombre) select l).ToList();
            List<ContratosView> listado2 = new List<ContratosView>();
            foreach (ContratosOperativa item in listado)
            {
                int gastos = (new GastosContratosBLL()).GastosContrato(Convert.ToInt32(item.IdContrato));
                listado2.Add(new ContratosView() {Adjunto = item.Adjunto, Detalle = item.Detalle, Monto = Convert.ToInt32(item.Monto), FechaInicio = item.FechaInicio, FechaExpiracion = item.FechaExpiracion, Nombre = item.Nombre, IdContrato = item.IdContrato, Gastos = gastos });
            }
            return listado2;
        }

        public void ActualizarVigencias() {
            context = new DBDidecoEntidades();
            List<ContratosOperativa> listado = (from l in context.ContratosOperativa where l.Estado == "VIGENTE" select l).ToList();
            foreach (ContratosOperativa item in listado)
            {
                int gastos = (new GastosContratosBLL()).GastosContrato(item.IdContrato);
                if (gastos >= item.Monto || item.FechaExpiracion.CompareTo(DateTime.Now) > 0) item.Estado = "VENCIDO";
            }
            context.SaveChanges();
        }

    }
}