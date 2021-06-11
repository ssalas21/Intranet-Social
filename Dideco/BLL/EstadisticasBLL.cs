using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dideco.Entity;
using System.ComponentModel;
using System.Data.Objects;
using System.Globalization;

namespace Dideco.BLL
{
    [DataObject]
    public class EstadisticasBLL
    {
        DBDidecoEntidades context;


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasPorRut(string rut)
        {
            context = new DBDidecoEntidades();
            List<Estadistica> listado = new List<Estadistica>();
            Estadistica aux1 = new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where rut == l.RutBeneficiario && l.AprobacionAsistente == "APROBADO" && l.AprobacionDirector == "APROBADO" select l).Count() };
            listado.Add(aux1);
            Estadistica aux2 = new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where rut == l.RutBeneficiario && (l.AprobacionAsistente == "RECHAZADO" || l.AprobacionDirector == "RECHAZADO") select l).Count() };
            listado.Add(aux2);
            Estadistica aux3 = new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where rut == l.RutBeneficiario && l.AprobacionDirector == "PENDIENTE" select l).Count() };
            listado.Add(aux3);
            return listado;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasPorFecha(DateTime inicio, DateTime fin)
        {
            context = new DBDidecoEntidades();
            List<Estadistica> listado = new List<Estadistica>();
            listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where (l.AprobacionAsistente == "RECHAZADO" || l.AprobacionDirector == "RECHAZADO") && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            return listado;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasPorMotivo(DateTime inicial, DateTime final, int motivo)
        {
            context = new DBDidecoEntidades();
            List<Estadistica> listado = new List<Estadistica>();
            switch (motivo)
            {
                case 0: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.Vivienda == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.Vivienda == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.Vivienda == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 1: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.Alimentacion == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.Alimentacion == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.Alimentacion == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;

                case 2: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.Salud == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.Salud == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.Salud == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 3: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.Infancia == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.Infancia == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.Infancia == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 4: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.Defunciones == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.Defunciones == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.Defunciones == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 5: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.Microemprendimiento == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.Microemprendimiento == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.Microemprendimiento == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 6: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.PSGubernamental == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.PSGubernamental == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.PSGubernamental == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 7: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.Maquinaria == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.Maquinaria == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.Maquinaria == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 8: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.PersonalMunicipal == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.PersonalMunicipal == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.PersonalMunicipal == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 9: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.RebajaAseo == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.RebajaAseo == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.RebajaAseo == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 10: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.EntregaAgua == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.EntregaAgua == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.EntregaAgua == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 11: listado.Add(new Estadistica() { Estado = "APROBADO", Cantidad = (from l in context.Solicitudes where l.Otros == true && l.AprobacionDirector == "APROBADO" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "RECHAZADO", Cantidad = (from l in context.Solicitudes where l.Otros == true && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "PENDIENTE", Cantidad = (from l in context.Solicitudes where l.Otros == true && l.AprobacionDirector == "PENDIENTE" && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count() });
                    break;
            }
            return listado;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasGlobalesPorMotivo(DateTime inicial, DateTime final, int motivo)
        {
            context = new DBDidecoEntidades();
            int total;// = (from l in context.Solicitudes select l).Count();
            int aux; //= (from l in context.Solicitudes where l.IdMotivo == id select l).Count();
            List<Estadistica> listado = new List<Estadistica>();
            try
            {
                switch (motivo)
                {
                    case 0:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.Vivienda == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "VIVIENDA", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                    case 1:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.Alimentacion == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "ALIMENTACION", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                    case 2:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.Salud == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "SALUD", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                    case 3:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.Infancia == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "INFANCIA", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                    case 4:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.Defunciones == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "DEFUNCIONES", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                    case 5:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.Microemprendimiento == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "MICROEMPRENDIMIENTO", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                    case 6:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.PSGubernamental == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "PROG. SOC. GUBERNAMENTAL", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                    case 7:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.Maquinaria == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "MAQUINARIA", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                    case 8:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.PersonalMunicipal == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "PERSONAL MUNICIPAL", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                    case 9:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.RebajaAseo == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "REBAJA ASEO", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                    case 10:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.EntregaAgua == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "ENTREGA AGUA", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                    case 11:
                        total = (from l in context.Solicitudes where l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        aux = (from l in context.Solicitudes where l.Otros == true && l.FechaSolicitud >= inicial && l.FechaSolicitud <= final select l).Count();
                        listado.Add(new Estadistica() { Estado = "OTROS", Cantidad = Convert.ToInt32(((aux * 100) / total)) });
                        listado.Add(new Estadistica() { Estado = "OTROS TIPOS DE SOLICITUDES", Cantidad = Convert.ToInt32((((total - aux) * 100) / total)) });
                        break;
                }
            }
            catch (Exception)
            {
            }
            return listado;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasPorLocalidadAprobados(string localidad, DateTime inicio, DateTime fin)
        {
            context = new DBDidecoEntidades();
            List<Estadistica> listado = new List<Estadistica>();
            listado.Add(new Estadistica() { Estado = "VIVIENDA", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "ALIMENTACION", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "SALUD", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "INFANCIA", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "DEFUNCIONES", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "MICROEMPRENDIMIENTO", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "PROG. SOC. GUBERNAMENTAL", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "MAQUINARIA", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "PERSONAL MUNICIPAL", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "REBAJA ASEO", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "ENTREGA DE AGUA", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "OTROS", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "APROBADO" && l.Beneficiario.Localidad == localidad && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            return listado;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasPorLocalidadPendientes(string localidad, DateTime inicio, DateTime fin)
        {
            context = new DBDidecoEntidades();
            List<Estadistica> listado = new List<Estadistica>();
            listado.Add(new Estadistica() { Estado = "VIVIENDA", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "ALIMENTACION", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "SALUD", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "INFANCIA", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "DEFUNCIONES", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "MICROEMPRENDIMIENTO", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "PROG. SOC. GUBERNAMENTAL", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "MAQUINARIA", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "PERSONAL MUNICIPAL", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "REBAJA ASEO", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "ENTREGA DE AGUA", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "OTROS", Cantidad = (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.Beneficiario.Localidad == localidad && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            return listado;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasPorLocalidadRechazados(string localidad, DateTime inicio, DateTime fin)
        {
            context = new DBDidecoEntidades();
            List<Estadistica> listado = new List<Estadistica>();
            listado.Add(new Estadistica() { Estado = "VIVIENDA", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "ALIMENTACION", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "SALUD", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "INFANCIA", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "DEFUNCIONES", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "MICROEMPRENDIMIENTO", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "PROG. SOC. GUBERNAMENTAL", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "MAQUINARIA", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "PERSONAL MUNICIPAL", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "REBAJA ASEO", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "ENTREGA DE AGUA", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "OTROS", Cantidad = (from l in context.Solicitudes where (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") && l.Beneficiario.Localidad == localidad && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            return listado;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasPorLocalidadTotalidad(string localidad, DateTime inicio, DateTime fin)
        {
            context = new DBDidecoEntidades();
            List<Estadistica> listado = new List<Estadistica>();
            listado.Add(new Estadistica() { Estado = "VIVIENDA", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "ALIMENTACION", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "SALUD", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "INFANCIA", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "DEFUNCIONES", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "MICROEMPRENDIMIENTO", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "PROG. SOC. GUBERNAMENTAL", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "MAQUINARIA", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "PERSONAL MUNICIPAL", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "REBAJA ASEO", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "ENTREGA DE AGUA", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            listado.Add(new Estadistica() { Estado = "OTROS", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin select l).Count() });
            return listado;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasEtarioTotales(string localidad, DateTime inicio, DateTime final, int motivo)
        {
            context = new DBDidecoEntidades();
            List<Estadistica> listado = new List<Estadistica>();
            switch (motivo)
            {
                case 0: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 1: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 2: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 3: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 4: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 5: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 6: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 7: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 8: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 9: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 10: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
                case 11: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final select l).Count() });
                    break;
            }

            return listado;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasEtarioAprobados(string localidad, DateTime inicio, DateTime final, int motivo)
        {
            context = new DBDidecoEntidades();
            List<Estadistica> listado = new List<Estadistica>();
            switch (motivo)
            {
                case 0: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
                case 1: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
                case 2: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
                case 3: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
                case 4: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
                case 5: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
                case 6: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
                case 7: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
                case 8: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
                case 9: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
                case 10: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
                case 11: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "APROBADO" select l).Count() });
                    break;
            }

            return listado;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasEtarioRechazados(string localidad, DateTime inicio, DateTime final, int motivo)
        {
            context = new DBDidecoEntidades();
            List<Estadistica> listado = new List<Estadistica>();
            switch (motivo)
            {
                case 0: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
                case 1: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
                case 2: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
                case 3: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
                case 4: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
                case 5: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
                case 6: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
                case 7: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
                case 8: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
                case 9: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
                case 10: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
                case 11: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && (l.AprobacionDirector == "RECHAZADO" || l.AprobacionAsistente == "RECHAZADO") select l).Count() });
                    break;
            }

            return listado;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica> ObtenerEstadisticasEtarioPendientes(string localidad, DateTime inicio, DateTime final, int motivo)
        {
            context = new DBDidecoEntidades();
            List<Estadistica> listado = new List<Estadistica>();
            switch (motivo)
            {
                case 0: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Vivienda == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
                case 1: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Alimentacion == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
                case 2: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Salud == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
                case 3: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Infancia == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
                case 4: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Defunciones == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
                case 5: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Microemprendimiento == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
                case 6: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.PSGubernamental == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
                case 7: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Maquinaria == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
                case 8: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.PersonalMunicipal == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
                case 9: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.RebajaAseo == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
                case 10: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.EntregaAgua == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
                case 11: listado.Add(new Estadistica() { Estado = "Adulto Joven 18-40", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 18 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 40 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Medio 41-64", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 41 && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) <= 64 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    listado.Add(new Estadistica() { Estado = "Adulto Mayor", Cantidad = (from l in context.Solicitudes where l.Beneficiario.Localidad == localidad && (DateTime.Now.Year - (int)l.Beneficiario.FechaNacimiento.Value.Year) >= 65 && l.Otros == true && l.FechaSolicitud >= inicio && l.FechaSolicitud <= final && l.AprobacionDirector == "PENDIENTE" select l).Count() });
                    break;
            }

            return listado;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica2> AudienciasPorLocalidad()
        {
            context = new DBDidecoEntidades();
            List<Estadistica2> listado = new List<Estadistica2>();

            Estadistica2 aux;

            aux = new Estadistica2() { Localidad = "CAMPICHE" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "CAMPICHE" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "CHILICAUQUÉN" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "CHILICAUQUÉN" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "EL CARDAL" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "EL CARDAL" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "EL RINCÓN" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "EL RINCÓN" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "EL RUNGUE" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "EL RUNGUE" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "EL PASO" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "EL PASO" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "HORCÓN" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "HORCÓN" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "LA CANELA" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "LA CANELA" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "LA CHOCOTA" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "LA CHOCOTA" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "LA ESTANCILLA" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "LA ESTANCILLA" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "LA GREDA" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "LA GREDA" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "LA LAGUNA" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "LA LAGUNA" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "LA QUEBRADA" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "LA QUEBRADA" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "LAS MELOSILLAS" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "LAS MELOSILLAS" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "LAS VENTANAS" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "LAS VENTANAS" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "LOS MAITENES" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "LOS MAITENES" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "LOS MAQUIS" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "LOS MAQUIS" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "MAITENCILLO" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "MAITENCILLO" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "POTRERILLOS" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "POTRERILLOS" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "PUCALÁN" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "PUCALÁN" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "PUCHUNCAVÍ" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "PUCHUNCAVÍ" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "SAN ANTONIO" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Localidad == "SAN ANTONIO" && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            return listado;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Estadistica2> AudienciasPorRut(string rut) {
            context = new DBDidecoEntidades();
            List<Estadistica2> listado = new List<Estadistica2>(); ;
            Estadistica2 aux;
            aux = new Estadistica2() { Localidad = "SOLICITADAS" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Rut == rut && l.FechaSolicitudAudiencia.Value.Year == DateTime.Now.Year && l.FechaSolicitudAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "SOLUCIONADA" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Rut == rut && l.Estado == "SOLUCIONADA" && l.FechaAudiencia.Value.Year == DateTime.Now.Year && l.FechaAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);

            aux = new Estadistica2() { Localidad = "ATENDIDA" };
            for (int j = 1; j < 12; j++)
            {
                aux.Cantidad[j - 1] = (from l in context.Audiencias where l.Beneficiario.Rut == rut && (l.Estado == "ATENDIDA" || l.Estado == "SOLUCIONADA") && l.FechaAudiencia.Value.Year == DateTime.Now.Year && l.FechaAudiencia.Value.Month == j select l).Count();

            }
            listado.Add(aux);            

            return listado;
        }

        public List<Solicitudes> ObtenerTransparencia(int motivo, int anno) {
            context = new DBDidecoEntidades();
            List<Solicitudes> listado = new List<Solicitudes>();
            if (motivo == 0) listado = (from l in context.Solicitudes where l.Vivienda == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 1) listado = (from l in context.Solicitudes where l.Alimentacion == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 2) listado = (from l in context.Solicitudes where l.Salud == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 3) listado = (from l in context.Solicitudes where l.Infancia == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 4) listado = (from l in context.Solicitudes where l.Defunciones == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 5) listado = (from l in context.Solicitudes where l.Microemprendimiento == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 6) listado = (from l in context.Solicitudes where l.PSGubernamental == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 7) listado = (from l in context.Solicitudes where l.Maquinaria == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 8) listado = (from l in context.Solicitudes where l.PersonalMunicipal == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 9) listado = (from l in context.Solicitudes where l.RebajaAseo == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 10) listado = (from l in context.Solicitudes where l.EntregaAgua == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            if (motivo == 11) listado = (from l in context.Solicitudes where l.Otros == true && l.FechaAprobacionDirector.Value.Year == anno && l.AprobacionDirector == "APROBADO" orderby l.FechaAprobacionDirector descending select l).ToList();
            return listado;
        }
    }
}