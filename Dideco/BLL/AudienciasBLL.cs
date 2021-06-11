using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Dideco.BLL
{
    [DataObject]
    public class AudienciasBLL
    {
        DBDidecoEntidades context;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Audiencias> ObtenerAudienciasPendientes() {
            context = new DBDidecoEntidades();
            return (from l in context.Audiencias where l.AtendidoPorAlcaldesa == false && l.FechaAudiencia != null && l.Estado == "PENDIENTE" orderby l.FechaAudiencia descending select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Audiencias> ObtenerAudienciasPendientesPorFecha(DateTime fecha)
        {
            context = new DBDidecoEntidades();
            return (from l in context.Audiencias where l.AtendidoPorAlcaldesa == false && l.FechaAudiencia.Value.Day == fecha.Day && l.FechaAudiencia.Value.Month == fecha.Month && l.FechaAudiencia.Value.Year == fecha.Year orderby l.FechaAudiencia ascending select l).ToList();
        }

        public void AgregarAudiencia(Beneficiario user1, DateTime fecha, string solicitud, string tipo) {
            context = new DBDidecoEntidades();
            Beneficiario user3 = (from l in context.Beneficiario where user1.Rut == l.Rut select l).FirstOrDefault();
            if (user3 != null)
            {
                user3.Nombre = user1.Nombre;
                user3.Direccion = user1.Direccion;
                user3.Contacto = user1.Contacto;
                user3.Localidad = user1.Localidad;                
                context.SaveChanges();
                context.Audiencias.AddObject(new Audiencias() { RutBeneficiario = user1.Rut, FechaSolicitudAudiencia = fecha, AtendidoPorAlcaldesa = false, Solicitud = solicitud, Estado = "PENDIENTE", Tipo = tipo });
                context.SaveChanges();
            }
            else
            {
                context.Beneficiario.AddObject(user1);
                context.SaveChanges();
                context.Audiencias.AddObject(new Audiencias() { RutBeneficiario = user1.Rut, FechaSolicitudAudiencia = fecha, AtendidoPorAlcaldesa = false, Solicitud = solicitud, Estado = "PENDIENTE", Tipo = tipo });
                context.SaveChanges();
            }
        }

        public void AtenderAudiencia (int idAudiencia, DateTime fecha, string solicitud, string compromiso, string derivacion) {
            context = new DBDidecoEntidades();
            Audiencias aux = (from l in context.Audiencias where l.IdAudiencias == idAudiencia select l).FirstOrDefault();
            aux.FechaAudiencia = fecha;
            aux.Solicitud = solicitud;
            aux.Compromiso = compromiso;
            aux.AtendidoPorAlcaldesa = true;
            aux.Estado = "DERIVADA";
            aux.Derivacion = derivacion;
            aux.FechaDerivacion = DateTime.Now;
            context.SaveChanges();
        }

        public void EntregarSolucionAlcaldeDinero(int idAudiencia, DateTime fecha, string solicitud, string compromiso, string solucion, int monto) {
            context = new DBDidecoEntidades();
            Audiencias aux = (from l in context.Audiencias where l.IdAudiencias == idAudiencia select l).FirstOrDefault();
            aux.FechaAudiencia = fecha;
            aux.Solicitud = solicitud;
            aux.Compromiso = compromiso;
            aux.AtendidoPorAlcaldesa = true;
            aux.Estado = "SOLUCIONADA";
            aux.Solucion = solucion;
            aux.MontoEntregado = monto;
            aux.FechaSolucion = DateTime.Now;
            context.SaveChanges();
        }

        public void EntregarSolucionAlcaldeSinDinero(int idAudiencia, DateTime fecha, string solicitud, string compromiso, string solucion)
        {
            context = new DBDidecoEntidades();
            Audiencias aux = (from l in context.Audiencias where l.IdAudiencias == idAudiencia select l).FirstOrDefault();
            aux.FechaAudiencia = fecha;
            aux.Solicitud = solicitud;
            aux.Compromiso = compromiso;
            aux.AtendidoPorAlcaldesa = true;
            aux.Estado = "SOLUCIONADA";
            aux.Solucion = solucion;            
            aux.FechaSolucion = DateTime.Now;
            context.SaveChanges();
        }
               

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Audiencias> ObtenerAudienciasSinAsignar() {
            context = new DBDidecoEntidades();
            return (from l in context.Audiencias where l.FechaAudiencia == null orderby l.IdAudiencias ascending select l).ToList();
        }

        public int ConteoAudienciasSinAsignar() {
            context = new DBDidecoEntidades();
            return (from l in context.Audiencias where l.FechaAudiencia == null orderby l.IdAudiencias ascending select l).Count();
        }

        public int ConteoAudienciasSinAtender() {
            context = new DBDidecoEntidades();
            return (from l in context.Audiencias where l.FechaAudiencia != null && l.AtendidoPorAlcaldesa != true select l).Count();
        }

        public string AsignarHorario(DateTime fecha, int idAudiencia) {
            context = new DBDidecoEntidades();
            Audiencias aux = (from l in context.Audiencias where l.FechaAudiencia == fecha select l).FirstOrDefault();
            if (aux != null)
            {
                return "NO SE PUEDE ASIGNAR EL HORARIO, YA QUE, YA SE ENCUENTRA ASIGNADO <br/>";
            }
            else {
                Audiencias aux2 = (from l in context.Audiencias where l.IdAudiencias == idAudiencia select l).FirstOrDefault();
                aux2.FechaAudiencia = fecha;
                context.SaveChanges();
                return "HORARIO ASIGNADO CORRECTAMENTE <br/>";
            }

        }

        public Audiencias ObtenerAudiencia(int idAudiencia) {
            context = new DBDidecoEntidades();
            return (from l in context.Audiencias where l.IdAudiencias == idAudiencia select l).FirstOrDefault();
        }

        public void CancelarAudiencia(int idAudiencia) {
            context = new DBDidecoEntidades();
            Audiencias aux = (from l in context.Audiencias where l.IdAudiencias == idAudiencia select l).FirstOrDefault();
            aux.FechaAudiencia = DateTime.Now;
            aux.Estado = "CANCELADA";
            context.SaveChanges();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Audiencias> ObtenerAudienciasPorRut(string rut) {
            context = new DBDidecoEntidades();
            return (from l in context.Audiencias where l.RutBeneficiario == rut && l.FechaAudiencia != null orderby l.FechaAudiencia descending select l).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Audiencias> ObtenerAudienciasSinSolucionPorDepartamento(string departamento) {
            context = new DBDidecoEntidades();
            return (from l in context.Audiencias where l.Derivacion == departamento && l.FechaDerivacion != null && l.FechaSolucion == null select l).ToList();             
        }

        public int ObtenerAudienciasSinSolucionPorDepartamentoCantidad(string departamento)
        {
            context = new DBDidecoEntidades();
            return (from l in context.Audiencias where l.Derivacion == departamento && l.FechaDerivacion != null && l.FechaSolucion == null select l).Count();
        }

        public void SolucionarAudiencia(int idAudiencia, string solucion) { 
            context = new DBDidecoEntidades();
            Audiencias aux = (from l in context.Audiencias where l.IdAudiencias == idAudiencia select l).FirstOrDefault();
            aux.Solucion = solucion;
            aux.FechaSolucion = DateTime.Now;
            aux.Estado = "SOLUCIONADA";
            context.SaveChanges();
        }

        public void ActualizarAudiencia(int idAudiencia, int idDepto) {
            context = new DBDidecoEntidades();
            Audiencias aux = (from l in context.Audiencias where l.IdAudiencias == idAudiencia select l).FirstOrDefault();
            aux.FechaAsignacion = DateTime.Now;
            aux.IdDepto = idDepto;
            context.SaveChanges();
        }

                      
    }
}