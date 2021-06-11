using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Dideco.Entity;

namespace Dideco.BLL
{
    [DataObject]
    public class VehiculosBLL
    {
        DBDidecoEntidades context;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Vehiculos> ObtenerVehiculos()
        {
            context = new DBDidecoEntidades();
            return (from l in context.Vehiculos select l).ToList();
        }

        public Vehiculos ObtenerVehiculo(string placa)
        {
            context = new DBDidecoEntidades();
            return (from l in context.Vehiculos where placa == l.Placa select l).FirstOrDefault();
        }

        public void ModificarRevision(string placa, DateTime revision)
        {
            context = new DBDidecoEntidades();
            Vehiculos aux = (from l in context.Vehiculos where placa == l.Placa select l).FirstOrDefault();
            aux.FechaRevision = revision;
            context.SaveChanges();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<VehiculoMantencion> ProximaMantencion()
        {
            context = new DBDidecoEntidades();
            List<Vehiculos> listado = ObtenerVehiculos();
            List<VehiculoMantencion> listado2 = new List<VehiculoMantencion>();
            foreach (Vehiculos item in listado)
            {
                if (item.Tipo == "RETROEXCAVADORA" || item.Tipo == "MOTONIVELADORA" || item.Tipo == "EXCAVADORA")
                {
                    List<UsoVehiculos> aux = (from l in context.UsoVehiculos where item.Placa == l.Placa select l).ToList();
                    int uso = aux.Sum(ax => ax.CantidadUso);
                    if (item.ProximaMantencion - uso < 30)
                    {
                        listado2.Add(new VehiculoMantencion() { Anno = item.Anno, FechaRevision = item.FechaRevision, Marca = item.Marca, Modelo = item.Modelo, Placa = item.Placa, ProximaMantencion = item.ProximaMantencion, Tipo = item.Tipo, Uso = uso, Restante = item.ProximaMantencion - uso });
                    }
                }
                else
                {
                    List<UsoVehiculos> aux = (from l in context.UsoVehiculos where item.Placa == l.Placa select l).ToList();
                    int uso = aux.Sum(ax => ax.CantidadUso);
                    if (item.ProximaMantencion - uso < 300)
                    {
                        listado2.Add(new VehiculoMantencion() { Anno = item.Anno, FechaRevision = item.FechaRevision, Marca = item.Marca, Modelo = item.Modelo, Placa = item.Placa, ProximaMantencion = item.ProximaMantencion, Tipo = item.Tipo, Uso = uso, Restante = item.ProximaMantencion - uso });
                    }
                }
            }
            return listado2;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Vehiculos> RevisionExpirando()
        {
            context = new DBDidecoEntidades();
            return (from l in context.Vehiculos where l.FechaRevision.Month.Equals(DateTime.Now.Month) && l.FechaRevision.Year.Equals(DateTime.Now.Year) select l).ToList();            
        }

        public string ObtenerTipo(string placa) {
            context = new DBDidecoEntidades();
            return (from l in context.Vehiculos where placa == l.Placa select l.Tipo).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Vehiculos> PermisoExpirando() {
            context = new DBDidecoEntidades();
            return (from l in context.Vehiculos where l.FechaPermiso.Value.Month.Equals(DateTime.Now.Month) && l.FechaPermiso.Value.Year.Equals(DateTime.Now.Year) select l).ToList();
        }

        public string ActualizarPermiso(string placa, DateTime fecha) {
            context = new DBDidecoEntidades();
            Vehiculos aux = (from l in context.Vehiculos where l.Placa == placa select l).FirstOrDefault();
            aux.FechaPermiso = fecha;
            context.SaveChanges();
            return "Actualización correcta";
        }
    }
}