using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dideco.Entity
{
    public class EstadisticaMotivo
    {
        public string Motivo { get; set; }
        public int Aprobados { get; set; }
        public int Rechazados { get; set; }
        public int Pendientes { get; set; }
    }
}