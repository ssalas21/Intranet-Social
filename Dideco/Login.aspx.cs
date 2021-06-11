using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security;
using Dideco.BLL;

namespace Dideco
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole(Login1.UserName, "SecreDideco")) Response.Redirect("~/Secretaria/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "Asistente")) Response.Redirect("~/Asistente/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "Dideco")) Response.Redirect("~/Director/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "Administrador")) Response.Redirect("~/Administrador/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "ReportesDideco")) Response.Redirect("~/Reportes/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "SecreAlcaldia")) Response.Redirect("~/SecreAlcaldia/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "Alcalde")) Response.Redirect("~/Alcalde/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "DirectorAreaOperativa")) Response.Redirect("~/DirectorAreaOperativa/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "Educacion")) Response.Redirect("~/Educacion/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "Finanzas")) Response.Redirect("~/Finanzas/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "Informatica")) Response.Redirect("~/Informatica/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "Ambiente")) Response.Redirect("~/Ambiente/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "DirectorObras")) Response.Redirect("~/DirectorObras/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "RRPP")) Response.Redirect("~/RRPP/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "DirectorSecplan")) Response.Redirect("~/DirectorSecplan/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "DirectorTransito")) Response.Redirect("~/DirectorTransito/Index.aspx");
            if (Roles.IsUserInRole(Login1.UserName, "Transparencia")) Response.Redirect("~/Transparencia/Index.aspx");
        }                
    }
}