using Dideco.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dideco.Entity;

namespace Dideco.Alcalde
{
    public partial class Index : System.Web.UI.Page
    {
        protected string campiche;
        protected string chilicauquen;
        protected string cardal;
        protected string rincon;
        protected string rungue;
        protected string paso;
        protected string horcon;
        protected string canela;
        protected string chocota;
        protected string estancilla;
        protected string greda;
        protected string laguna;
        protected string quebrada;
        protected string melosillas;
        protected string ventanas;
        protected string maitenes;
        protected string maquis;
        protected string maitencillo;
        protected string potrerillos;
        protected string pucalan;
        protected string puchuncavi;
        protected string sanAntonio;

        List<Audiencias> listado = new AudienciasBLL().ObtenerAudienciasPendientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            LblCantidad2.Text = new AudienciasBLL().ConteoAudienciasSinAtender().ToString();
            string usuario = HttpContext.Current.User.Identity.Name;
            LblUsuario2.Text = (new PersonalBLL()).ObtenerNombre(usuario);
            List<Estadistica2> listado = new EstadisticasBLL().AudienciasPorLocalidad();
            foreach (Estadistica2 item in listado)
            {
                if (item.Localidad == "CAMPICHE") campiche = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "CHILICAUQUÉN") chilicauquen = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "EL CARDAL") cardal = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "EL RINCÓN") rincon = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "EL RUNGUE") rungue = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "EL PASO") paso = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "HORCÓN") horcon = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "LA CANELA") canela = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "LA CHOCOTA") chocota = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "LA ESTANCILLA") estancilla = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "LA GREDA") greda = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "LA LAGUNA") laguna = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "LA QUEBRADA") quebrada = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "LAS MELOSILLAS") melosillas = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "LAS VENTANAS") ventanas = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "LOS MAITENES") maitenes = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "LOS MAQUIS") maquis = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "MAITENCILLO") maitencillo = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "POTRERILLOS") potrerillos = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "PUCALÁN") pucalan = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "PUCHUNCAVÍ") puchuncavi = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
                if (item.Localidad == "SAN ANTONIO") sanAntonio = "[" + item.Cantidad[0].ToString() + ", " + item.Cantidad[1].ToString() + ", " + item.Cantidad[2].ToString() + ", " + item.Cantidad[3].ToString() + ", " + item.Cantidad[4].ToString() + ", " + item.Cantidad[5].ToString() + ", " + item.Cantidad[6].ToString() + ", " + item.Cantidad[7].ToString() + ", " + item.Cantidad[8].ToString() + ", " + item.Cantidad[9].ToString() + ", " + item.Cantidad[10].ToString() + ", " + item.Cantidad[11].ToString() + "]";
            }
            LblYear.Text = DateTime.Now.Year.ToString();

        }
    }
}