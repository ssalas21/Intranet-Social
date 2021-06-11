using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Dideco.BLL
{
    [DataObject]
    public class GastosContratosBLL
    {
        DBDidecoEntidades context;

        public int GastosContrato(int idContrato) {
            context = new DBDidecoEntidades();
            List<GastosContratosOperativa> listado = (from l in context.GastosContratosOperativa where l.IdContrato == idContrato select l).ToList();
            int gastos = 0;
            foreach (GastosContratosOperativa item in listado)
            {
                gastos = gastos + item.Gasto;
            }
            return gastos;
        }

        public void AgregarGasto(int idContrato, string detalle, int gasto) {
            context = new DBDidecoEntidades();
            GastosContratosOperativa aux = new GastosContratosOperativa() {IdContrato = idContrato, Detalle = detalle, Gasto = gasto};
            context.GastosContratosOperativa.AddObject(aux);
            context.SaveChanges();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<GastosContratosOperativa> ObtenerListadoGastos(int idContrato) {
            context = new DBDidecoEntidades();
            return (from l in context.GastosContratosOperativa where idContrato == l.IdContrato select l).ToList();
        }
    
    }
}