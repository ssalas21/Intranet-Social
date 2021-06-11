using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Dideco.BLL
{
    [DataObject]

    public class UsoVehiculosBLL
    {
        DBDidecoEntidades context;

        public void AgregarUso(string placa, DateTime fecha, int cantidadUso) {
            context = new DBDidecoEntidades();
            UsoVehiculos aux = new UsoVehiculos() {Placa=placa, FechaUso=fecha, CantidadUso=cantidadUso };
            context.UsoVehiculos.AddObject(aux);
            context.SaveChanges();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<UsoVehiculos> ObtenerUsoVehiculos() {
            context = new DBDidecoEntidades();
            return (from l in context.UsoVehiculos select l).ToList();
        }

        public List<UsoVehiculos> ObtenerUsoVehiculo(string placa) {
            context = new DBDidecoEntidades();
            return (from l in context.UsoVehiculos where placa == l.Placa select l).ToList();
        }

    }
}