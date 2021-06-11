using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Dideco.Entity;

namespace Dideco.BLL
{
    [DataObject]
    public class SolicitudesBLL
    {
        DBDidecoEntidades context;

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AgregarSolicitud(Beneficiario user1, bool vivienda, bool alimentacion, bool salud, bool infancia, bool defunciones, bool microemprendimiento, bool psgubernamental, bool maquinaria, bool personalMunicipal, bool rebajaAseo, bool entregaAgua, bool otros, string user2, string detalle, Boolean rgh, string asistente, string porcentaje)
        {
            context = new DBDidecoEntidades();
            Beneficiario user3 = (from l in context.Beneficiario where user1.Rut == l.Rut select l).FirstOrDefault();
            if (user3 != null)
            {
                user3.Nombre = user1.Nombre;
                user3.Direccion = user1.Direccion;
                user3.Contacto = user1.Contacto;
                user3.Localidad = user1.Localidad;
                context.SaveChanges();
                int anno = DateTime.Now.Year;
                int folio = (from k in context.Solicitudes where k.FechaSolicitud.Value.Year == anno select k).Count();
                Solicitudes solicitud = new Solicitudes() { Vivienda = vivienda, Alimentacion = alimentacion, Salud = salud, Infancia = infancia, Defunciones = defunciones, Microemprendimiento = microemprendimiento, PSGubernamental = psgubernamental, Maquinaria = maquinaria, PersonalMunicipal = personalMunicipal, RebajaAseo = rebajaAseo, EntregaAgua = entregaAgua, Otros = otros, RutBeneficiario = user3.Rut, UserPersonal = user2, FechaSolicitud = DateTime.Now, DetallesCaso = detalle.ToUpper(), RegistroSocialHogar = rgh, Asistente = asistente, AprobacionAsistente = "PENDIENTE", AprobacionDirector = "PENDIENTE", Visita = "NO", FolioAno = folio + 1, PorcentajeRSH = porcentaje };
                context.Solicitudes.AddObject(solicitud);
                context.SaveChanges();
            }
            else
            {
                context.Beneficiario.AddObject(user1);
                context.SaveChanges();
                int anno = DateTime.Now.Year;
                int folio = (from k in context.Solicitudes where k.FechaSolicitud.Value.Year == anno select k).Count();
                Solicitudes solicitud = new Solicitudes() { Vivienda = vivienda, Alimentacion = alimentacion, Salud = salud, Infancia = infancia, Defunciones = defunciones, Microemprendimiento = microemprendimiento, PSGubernamental = psgubernamental, Maquinaria = maquinaria, PersonalMunicipal = personalMunicipal, RebajaAseo = rebajaAseo, EntregaAgua = entregaAgua, Otros = otros, RutBeneficiario = user1.Rut, UserPersonal = user2, FechaSolicitud = DateTime.Now, DetallesCaso = detalle.ToUpper(), RegistroSocialHogar = rgh, Asistente = asistente, AprobacionAsistente = "PENDIENTE", AprobacionDirector = "PENDIENTE", Visita = "NO", FolioAno = folio + 1, PorcentajeRSH = porcentaje };
                context.Solicitudes.AddObject(solicitud);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Solicitudes> ObtenerSolicitudes()
        {
            context = new DBDidecoEntidades();
            return (from l in context.Solicitudes select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Solicitudes> ObtenerSolicitudesPorAsistentePendientes(string user)
        {
            context = new DBDidecoEntidades();
            return (from l in context.Solicitudes where user == l.Asistente && l.AprobacionAsistente == "PENDIENTE" orderby l.FechaSolicitud ascending select l).ToList();
        }

        public int ObtenerCantidadSolicitudesPendientesAsistente(string user)
        {
            context = new DBDidecoEntidades();
            return (from l in context.Solicitudes where user == l.Asistente && l.AprobacionAsistente == "PENDIENTE" orderby l.FechaSolicitud ascending select l).Count();
        }

        public int ObtenerCantidadSolicitudesPendientesAsistentes()
        {
            context = new DBDidecoEntidades();
            return (from l in context.Solicitudes where l.AprobacionAsistente == "PENDIENTE" orderby l.FechaSolicitud ascending select l).Count();
        }

        public int ObtenerCantidadSolicitudesPendientesDirector()
        {
            context = new DBDidecoEntidades();
            return (from l in context.Solicitudes where l.AprobacionDirector == "PENDIENTE" && l.AprobacionAsistente == "APROBADO" select l).Count();
        }

        public Solicitudes ObtenerSolicitudPorId(int id)
        {
            context = new DBDidecoEntidades();
            return (from l in context.Solicitudes where l.IdSolicitud == id select l).FirstOrDefault();
        }

        public void ActualizarSolicitud(int id, string visita, string detalle, bool vivienda, bool alimentacion, bool salud, bool infancia, bool defunciones, bool microemprendimiento, bool psGubernamental, bool maquinaria, bool personalMunicipal, bool rebajaAseo, bool entregaAgua, bool otros, string situacion)
        {
            context = new DBDidecoEntidades();
            Solicitudes solicitud = (from l in context.Solicitudes where l.IdSolicitud == id select l).FirstOrDefault();
            solicitud.DetallesCaso = detalle;
            solicitud.SituacionFamiliar = situacion;
            solicitud.Visita = visita;
            solicitud.Vivienda = vivienda;
            solicitud.Alimentacion = alimentacion;
            solicitud.Salud = salud;
            solicitud.Infancia = infancia;
            solicitud.Defunciones = defunciones;
            solicitud.Microemprendimiento = microemprendimiento;
            solicitud.PSGubernamental = psGubernamental;
            solicitud.Maquinaria = maquinaria;
            solicitud.PersonalMunicipal = personalMunicipal;
            solicitud.RebajaAseo = rebajaAseo;
            solicitud.EntregaAgua = entregaAgua;
            solicitud.Otros = otros;
            context.SaveChanges();
        }

        public void ActualizarSolicitudConFecha(int id, string visita, string detalle, DateTime fechaVisita, bool vivienda, bool alimentacion, bool salud, bool infancia, bool defunciones, bool microemprendimiento, bool psGubernamental, bool maquinaria, bool personalMunicipal, bool rebajaAseo, bool entregaAgua, bool otros, string situacion)
        {
            context = new DBDidecoEntidades();
            Solicitudes solicitud = (from l in context.Solicitudes where l.IdSolicitud == id select l).FirstOrDefault();
            solicitud.SituacionFamiliar = situacion;
            solicitud.FechaVisita = fechaVisita;
            solicitud.DetallesCaso = detalle;
            solicitud.Visita = visita;
            solicitud.Vivienda = vivienda;
            solicitud.Alimentacion = alimentacion;
            solicitud.Salud = salud;
            solicitud.Infancia = infancia;
            solicitud.Defunciones = defunciones;
            solicitud.Microemprendimiento = microemprendimiento;
            solicitud.PSGubernamental = psGubernamental;
            solicitud.Maquinaria = maquinaria;
            solicitud.PersonalMunicipal = personalMunicipal;
            solicitud.RebajaAseo = rebajaAseo;
            solicitud.EntregaAgua = entregaAgua;
            solicitud.Otros = otros;
            context.SaveChanges();
        }

        public void AprobarSolicitudPorAsistenteFecha(int id, string visita, string detalle, bool vivienda, bool alimentacion, bool salud, bool infancia, bool defunciones, bool microemprendimiento, bool psGubernamental, bool maquinaria, bool personalMunicipal, bool rebajaAseo, bool entregaAgua, bool otros, DateTime fecha, string situacion)
        {
            context = new DBDidecoEntidades();
            Solicitudes solicitud = (from l in context.Solicitudes where l.IdSolicitud == id select l).FirstOrDefault();
            solicitud.DetallesCaso = detalle;
            solicitud.SituacionFamiliar = situacion;
            solicitud.AprobacionAsistente = "APROBADO";
            solicitud.FechaAprobacionAsistente = DateTime.Now;
            solicitud.Visita = visita;
            solicitud.Vivienda = vivienda;
            solicitud.Alimentacion = alimentacion;
            solicitud.Salud = salud;
            solicitud.Infancia = infancia;
            solicitud.Defunciones = defunciones;
            solicitud.Microemprendimiento = microemprendimiento;
            solicitud.PSGubernamental = psGubernamental;
            solicitud.Maquinaria = maquinaria;
            solicitud.PersonalMunicipal = personalMunicipal;
            solicitud.RebajaAseo = rebajaAseo;
            solicitud.EntregaAgua = entregaAgua;
            solicitud.Otros = otros;
            solicitud.FechaVisita = fecha;
            context.SaveChanges();
        }

        public void AprobarSolicitudPorAsistente(int id, string visita, string detalle, bool vivienda, bool alimentacion, bool salud, bool infancia, bool defunciones, bool microemprendimiento, bool psGubernamental, bool maquinaria, bool personalMunicipal, bool rebajaAseo, bool entregaAgua, bool otros, string situacion)
        {
            context = new DBDidecoEntidades();
            Solicitudes solicitud = (from l in context.Solicitudes where l.IdSolicitud == id select l).FirstOrDefault();
            solicitud.DetallesCaso = detalle;
            solicitud.SituacionFamiliar = situacion;
            solicitud.AprobacionAsistente = "APROBADO";
            solicitud.FechaAprobacionAsistente = DateTime.Now;
            solicitud.Visita = visita;
            solicitud.Vivienda = vivienda;
            solicitud.Alimentacion = alimentacion;
            solicitud.Salud = salud;
            solicitud.Infancia = infancia;
            solicitud.Defunciones = defunciones;
            solicitud.Microemprendimiento = microemprendimiento;
            solicitud.PSGubernamental = psGubernamental;
            solicitud.Maquinaria = maquinaria;
            solicitud.PersonalMunicipal = personalMunicipal;
            solicitud.RebajaAseo = rebajaAseo;
            solicitud.EntregaAgua = entregaAgua;
            solicitud.Otros = otros;
            context.SaveChanges();
        }

        public void RechazarSolicitudPorAsistente(int id, string aux, string detalle, bool vivienda, bool alimentacion, bool salud, bool infancia, bool defunciones, bool microemprendimiento, bool psGubernamental, bool maquinaria, bool personalMunicipal, bool rebajaAseo, bool entregaAgua, bool otros, string situacion)
        {
            context = new DBDidecoEntidades();
            Solicitudes solicitud = (from l in context.Solicitudes where l.IdSolicitud == id select l).FirstOrDefault();
            solicitud.DetallesCaso = detalle;
            solicitud.SituacionFamiliar = situacion;
            solicitud.AprobacionAsistente = "RECHAZADO";
            solicitud.FechaAprobacionAsistente = DateTime.Now;
            solicitud.Visita = aux;
            solicitud.Vivienda = vivienda;
            solicitud.Alimentacion = alimentacion;
            solicitud.Salud = salud;
            solicitud.Infancia = infancia;
            solicitud.Defunciones = defunciones;
            solicitud.Microemprendimiento = microemprendimiento;
            solicitud.PSGubernamental = psGubernamental;
            solicitud.Maquinaria = maquinaria;
            solicitud.PersonalMunicipal = personalMunicipal;
            solicitud.RebajaAseo = rebajaAseo;
            solicitud.EntregaAgua = entregaAgua;
            solicitud.Otros = otros;
            context.SaveChanges();
        }

        public void RechazarSolicitudPorAsistenteFecha(int id, string aux, string detalle, bool vivienda, bool alimentacion, bool salud, bool infancia, bool defunciones, bool microemprendimiento, bool psGubernamental, bool maquinaria, bool personalMunicipal, bool rebajaAseo, bool entregaAgua, bool otros, DateTime fechaVisita, string situacion)
        {
            context = new DBDidecoEntidades();
            Solicitudes solicitud = (from l in context.Solicitudes where l.IdSolicitud == id select l).FirstOrDefault();
            solicitud.DetallesCaso = detalle;
            solicitud.SituacionFamiliar = situacion;
            solicitud.AprobacionAsistente = "RECHAZADO";
            solicitud.FechaAprobacionAsistente = DateTime.Now;
            solicitud.Visita = aux;
            solicitud.Vivienda = vivienda;
            solicitud.Alimentacion = alimentacion;
            solicitud.Salud = salud;
            solicitud.Infancia = infancia;
            solicitud.Defunciones = defunciones;
            solicitud.Microemprendimiento = microemprendimiento;
            solicitud.PSGubernamental = psGubernamental;
            solicitud.Maquinaria = maquinaria;
            solicitud.PersonalMunicipal = personalMunicipal;
            solicitud.RebajaAseo = rebajaAseo;
            solicitud.EntregaAgua = entregaAgua;
            solicitud.Otros = otros;
            solicitud.FechaVisita = fechaVisita;
            context.SaveChanges();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Solicitudes> ObtenerSolicitudesPorRut(string rut)
        {
            context = new DBDidecoEntidades();
            return (from l in context.Solicitudes where rut == l.RutBeneficiario orderby l.IdSolicitud descending select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Solicitudes> SolicitudesDirectorPendientes()
        {
            context = new DBDidecoEntidades();
            return (from l in context.Solicitudes where l.AprobacionAsistente == "APROBADO" && l.AprobacionDirector == "PENDIENTE" orderby l.IdSolicitud ascending select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Solicitudes> SolicitudesDirectorSinAprobarPorAsistente()
        {
            context = new DBDidecoEntidades();
            return (from l in context.Solicitudes where l.AprobacionAsistente == "PENDIENTE" orderby l.IdSolicitud ascending select l).ToList();
        }

        public void AprobarSolicitudPorDirector(int id, string observacion)
        {
            context = new DBDidecoEntidades();
            Solicitudes solicitud = (from l in context.Solicitudes where id == l.IdSolicitud select l).FirstOrDefault();
            solicitud.AprobacionDirector = "APROBADO";
            solicitud.FechaAprobacionDirector = DateTime.Now;
            solicitud.ObservacionDideco = observacion;
            context.SaveChanges();
        }

        public void RechazarSolicitudPorDirector(int id, string observacion)
        {
            context = new DBDidecoEntidades();
            Solicitudes solicitud = (from l in context.Solicitudes where id == l.IdSolicitud select l).FirstOrDefault();
            solicitud.AprobacionDirector = "RECHAZADO";
            solicitud.FechaAprobacionDirector = DateTime.Now;
            solicitud.ObservacionDideco = observacion;
            context.SaveChanges();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Solicitudes> ObtenerSolicitudesPorFecha(DateTime inicio, DateTime fin)
        {
            context = new DBDidecoEntidades();
            return (from l in context.Solicitudes where l.FechaSolicitud >= inicio && l.FechaSolicitud <= fin orderby l.IdSolicitud descending select l).ToList();
        }

        public List<SolicitudesTotalidad> ObtenerSolicitudesExcel(DateTime inicio, DateTime fin)
        {
            context = new DBDidecoEntidades();
            List<SolicitudesTotalidad> listado = new List<SolicitudesTotalidad>();
            List<Solicitudes> solicitudes = ObtenerSolicitudesPorFecha(inicio, fin);
            foreach (Solicitudes item in solicitudes)
            {
                listado.Add(new SolicitudesTotalidad()
                {
                    Folio = item.IdSolicitud,
                    Vivienda = (item.Vivienda.Equals(true) ? "SI" : "NO"),
                    Alimentacion = (item.Alimentacion.Equals(true) ? "SI" : "NO"),
                    AprobacionAsistente = item.AprobacionAsistente,
                    AprobacionDirector = item.AprobacionDirector,
                    Asistente = (new PersonalBLL()).ObtenerNombre(item.Asistente),
                    Contacto = item.Beneficiario.Contacto,
                    Defunciones = (item.Defunciones.Equals(true) ? "SI" : "NO"),
                    Domicilio = item.Beneficiario.Direccion,
                    EntregaAgua = (item.EntregaAgua.Equals(true) ? "SI" : "NO"),
                    FechaAprobacionAsistente = (item.FechaAprobacionAsistente.HasValue ? Convert.ToDateTime(item.FechaAprobacionAsistente) : DateTime.MinValue),
                    FechaAprobacionDirector = (item.FechaAprobacionDirector.HasValue ? Convert.ToDateTime(item.FechaAprobacionDirector) : DateTime.MinValue),
                    FechaSolicitud = Convert.ToDateTime(item.FechaSolicitud),
                    FechaVisita = (item.FechaVisita.HasValue ? Convert.ToDateTime(item.FechaVisita) : DateTime.MinValue),
                    Infancia = (item.Infancia.Equals(true) ? "SI" : "NO"),
                    Localidad = item.Beneficiario.Localidad.ToString(),
                    Maquinaria = (item.Maquinaria.Equals(true) ? "SI" : "NO"),
                    Microemprendimiento = (item.Microemprendimiento.Equals(true) ? "SI" : "NO"),
                    NombreBeneficiario = item.Beneficiario.Nombre,
                    Otros = (item.Otros.Equals(true) ? "SI" : "NO"),
                    PersonalMunicipal = (item.PersonalMunicipal.Equals(true) ? "SI" : "NO"),
                    PSGubernamental = (item.PSGubernamental.Equals(true) ? "SI" : "NO"),
                    RebajaAseo = (item.RebajaAseo.Equals(true) ? "SI" : "NO"),
                    RegistroSocialHogares = (item.RegistroSocialHogar.Equals(true) ? "SI" : "NO"),
                    Rut = item.RutBeneficiario,
                    Salud = (item.Salud.Equals(true) ? "SI" : "NO"),
                    Visita = (item.Visita.Equals(true) ? "SI" : "NO"),
                    PorcentajeRSH = Convert.ToInt32(item.PorcentajeRSH)
                });
            }
            return listado;
        }


        public int AgregarSolicitud2(Beneficiario user1, bool vivienda, bool alimentacion, bool salud, bool infancia, bool defunciones, bool microemprendimiento, bool psgubernamental, bool maquinaria, bool personalMunicipal, bool rebajaAseo, bool entregaAgua, bool otros, string user2, string detalle, Boolean rgh, string asistente, string porcentaje, int idAudiencia)
        {
            context = new DBDidecoEntidades();
            Beneficiario user3 = (from l in context.Beneficiario where user1.Rut == l.Rut select l).FirstOrDefault();
            if (user3 != null)
            {
                user3.Nombre = user1.Nombre;
                user3.Direccion = user1.Direccion;
                user3.Contacto = user1.Contacto;
                user3.Localidad = user1.Localidad;
                context.SaveChanges();
                int anno = DateTime.Now.Year;
                int folio = (from k in context.Solicitudes where k.FechaSolicitud.Value.Year == anno select k).Count();
                Solicitudes solicitud = new Solicitudes() { Vivienda = vivienda, Alimentacion = alimentacion, Salud = salud, Infancia = infancia, Defunciones = defunciones, Microemprendimiento = microemprendimiento, PSGubernamental = psgubernamental, Maquinaria = maquinaria, PersonalMunicipal = personalMunicipal, RebajaAseo = rebajaAseo, EntregaAgua = entregaAgua, Otros = otros, RutBeneficiario = user3.Rut, UserPersonal = user2, FechaSolicitud = DateTime.Now, DetallesCaso = detalle.ToUpper(), RegistroSocialHogar = rgh, Asistente = asistente, AprobacionAsistente = "PENDIENTE", AprobacionDirector = "PENDIENTE", FolioAno = folio + 1, PorcentajeRSH = porcentaje, IdAudiencia = idAudiencia };
                context.Solicitudes.AddObject(solicitud);
                context.SaveChanges();
                return solicitud.IdSolicitud;
            }
            else
            {
                context.Beneficiario.AddObject(user1);
                context.SaveChanges();
                int anno = DateTime.Now.Year;
                int folio = (from k in context.Solicitudes where k.FechaSolicitud.Value.Year == anno select k).Count();
                Solicitudes solicitud = new Solicitudes() { Vivienda = vivienda, Alimentacion = alimentacion, Salud = salud, Infancia = infancia, Defunciones = defunciones, Microemprendimiento = microemprendimiento, PSGubernamental = psgubernamental, Maquinaria = maquinaria, PersonalMunicipal = personalMunicipal, RebajaAseo = rebajaAseo, EntregaAgua = entregaAgua, Otros = otros, RutBeneficiario = user1.Rut, UserPersonal = user2, FechaSolicitud = DateTime.Now, DetallesCaso = detalle.ToUpper(), RegistroSocialHogar = rgh, Asistente = asistente, AprobacionAsistente = "PENDIENTE", AprobacionDirector = "PENDIENTE", Visita = "NO", FolioAno = folio + 1, PorcentajeRSH = porcentaje };
                context.Solicitudes.AddObject(solicitud);
                context.SaveChanges();
                return solicitud.IdSolicitud;
            }
        }


    }
}