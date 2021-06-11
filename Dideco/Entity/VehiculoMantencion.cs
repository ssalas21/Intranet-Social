using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dideco.Entity
{
    public class VehiculoMantencion
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anno { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaRevision { get; set; }
        public int Uso { get; set; }
        public int Restante { get; set; }
        public int ProximaMantencion { get; set; }
    }
}