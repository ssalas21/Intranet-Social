using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Dideco.BLL
{
    [DataObject]
    public class BeneficiarioBLL
    {

        DBDidecoEntidades context;

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AgregarBeneficiario(string rut, string nombre, string direccion, string contacto, string localidad) { 
            context = new DBDidecoEntidades();
            Beneficiario aux = (from l in context.Beneficiario where rut == l.Rut select l).FirstOrDefault();
            if (aux == null) {
                context.Beneficiario.AddObject((new Beneficiario() { Rut = rut, Nombre = nombre.ToUpper(), Direccion = direccion.ToUpper(), Contacto = contacto.ToUpper(), Localidad = localidad.ToUpper() }));
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Beneficiario> ListarBeneficiarios() {
            context = new DBDidecoEntidades();
            return (from l in context.Beneficiario orderby l.Nombre ascending select l).ToList();
        }

        public Beneficiario BuscarPorRut(string rut) {
            context = new DBDidecoEntidades();
            return (from l in context.Beneficiario where rut == l.Rut select l).FirstOrDefault();            
        }

        public string ObtenerNombreBeneficiario(string rut) {
            context = new DBDidecoEntidades();
            return (from l in context.Beneficiario where rut == l.Rut select l.Nombre).FirstOrDefault().ToString();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public List<Beneficiario> BuscarPorNombreRut(string nombre) {
            context = new DBDidecoEntidades();
            return (from l in context.Beneficiario where l.Nombre.Contains(nombre) || l.Rut.Contains(nombre) select l).ToList();
        }

        public void ActualizarFechas() {
            context = new DBDidecoEntidades();
            List<Beneficiario> listado = (from l in context.Beneficiario where l.FechaNacimiento == null select l).ToList();
            foreach (Beneficiario item in listado){
                item.FechaNacimiento = DateTime.Now;
            }
            context.SaveChanges();
	{
		 
	}
        }
    }
}