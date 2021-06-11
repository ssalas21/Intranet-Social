using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Dideco.BLL
{
    [DataObject]
    public class PersonalBLL
    {

        DBDidecoEntidades context;

        // Insertar y modificar personal
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public string AgregarPersonal(string user, string pass, string nombre, string rol)
        {
            context = new DBDidecoEntidades();
            Personal usuario = (from l in context.Personal where user == l.User select l).FirstOrDefault();
            if (usuario == null)
            {
                Personal aux = new Personal() { User = user, Pass = pass, Nombre = nombre, Rol = rol };
                context.Personal.AddObject(aux);
                context.SaveChanges();
                return "AGREGADO CORRECTAMENTE";
            }
            else
            {
                return "EL USUARIO YA EXISTE";
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void ModificarPersonal(string User, string Pass, string Nombre, string Rol)
        {
            context = new DBDidecoEntidades();
            Personal usuario = (from l in context.Personal where User == l.User select l).FirstOrDefault();
            usuario.Pass = Pass;
            usuario.Nombre = Nombre;
            context.SaveChanges();
        }

        //Listar secretarias
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Personal> ListarSecretarias()
        {
            context = new DBDidecoEntidades();
            return (from l in context.Personal where l.Rol == "Secretaria" select l).ToList();
        }
        
        //Listar asistentes
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Personal> ListarAsistentes()
        {
            context = new DBDidecoEntidades();
            return (from l in context.Personal where l.Rol == "Asistente" select l).ToList();
        }

        //Listar Directores
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Personal> ListarDirectores() {
            context = new DBDidecoEntidades();
            return (from l in context.Personal where l.Rol == "Director" select l).ToList();
        }



        //Validaciones de inicio de sesion y roles
        public bool ValidarUsuario(string user, string pass)
        {
            context = new DBDidecoEntidades();
            Personal aux = (from l in context.Personal where user == l.User && pass == l.Pass select l).FirstOrDefault();
            if (aux != null) return true;
            else return false;
        }

        public string[] ObtenerRoles(string user)
        {
            context = new DBDidecoEntidades();
            return (from l in context.Personal where user == l.User select l.Rol).ToArray();
        }

        public bool ValidarRol(string user, string rol)
        {
            context = new DBDidecoEntidades();
            Personal aux = (from l in context.Personal where user == l.User && rol == l.Rol select l).FirstOrDefault();
            if (aux != null) return true;
            else return false;
        }

        public string ObtenerNombre(string user)
        {
            context = new DBDidecoEntidades();
            return (from l in context.Personal where user == l.User select l.Nombre).FirstOrDefault();
        }

        public Personal ObtenerDatos(string rol) {
            context = new DBDidecoEntidades();
            return (from l in context.Personal where rol == l.Rol select l).FirstOrDefault();
        }

        public Personal ObtenerPersona(string user) {
            context = new DBDidecoEntidades();
            return (from l in context.Personal where user == l.User select l).FirstOrDefault();
        }

    }
}