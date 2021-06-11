using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.BLL;
using Dideco.Entity;

namespace Dideco.DirectorAreaOperativa
{
    public partial class Index2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
            LblCantidad2.Text = (new VehiculosBLL().RevisionExpirando().Count().ToString());
            LblAudiencias.Text = (new AudienciasBLL()).ObtenerAudienciasSinSolucionPorDepartamentoCantidad("AREA OPERATIVA").ToString();
            List<ContratosView> listado = (new ContratosOperativaBLL()).ContratosExpirando();
            LblContratos.Text = listado.Count().ToString();
            LblProximaMantencion.Text = ((new VehiculosBLL().ProximaMantencion()).Count().ToString());
            LblPermisos.Text = (new VehiculosBLL()).PermisoExpirando().Count().ToString();
            LblSeguroComplementario.Text = (new SegurosComplementariosBLL()).ObtenerSegurosPorVencer().Count().ToString();
        }
    }
}