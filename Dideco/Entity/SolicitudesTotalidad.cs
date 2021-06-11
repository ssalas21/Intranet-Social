using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dideco.Entity
{
    public class SolicitudesTotalidad
    {

        public int Folio { get; set; }
        public string NombreBeneficiario { get; set; }
        public string Rut { get; set; }
        public string Domicilio { get; set; }
        public string Contacto { get; set; }
        public string Localidad { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Vivienda { get; set; }
        public string Alimentacion { get; set; }
        public string Salud { get; set; }
        public string Infancia { get; set; }
        public string Defunciones { get; set; }
        public string Microemprendimiento { get; set; }
        public string PSGubernamental { get; set; }
        public string Maquinaria { get; set; }
        public string PersonalMunicipal { get; set; }
        public string RebajaAseo { get; set; }
        public string EntregaAgua { get; set; }
        public string Otros { get; set; }
        public string RegistroSocialHogares { get; set; }
        public string Visita { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Asistente { get; set; }        
        public string AprobacionAsistente { get; set; }
        public DateTime FechaAprobacionAsistente { get; set; }
        public string AprobacionDirector { get; set; }
        public DateTime FechaAprobacionDirector { get; set; }
        public int PorcentajeRSH { get; set; }

    }
}