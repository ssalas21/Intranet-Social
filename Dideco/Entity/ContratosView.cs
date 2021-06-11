using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dideco.Entity
{
    public class ContratosView
    {
        public int IdContrato { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int Monto { get; set; }
        public int Gastos { get; set; }
        public string Adjunto { get; set; }
    }
}