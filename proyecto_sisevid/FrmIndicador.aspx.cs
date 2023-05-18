using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto_sisevid
{
    public partial class FrmIndicador : System.Web.UI.Page
    {
        protected Indicador[] arregloIndicador = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlIndicador objControlIndicador = new ControlIndicador();
            arregloIndicador = objControlIndicador.listar();
        }
    }
}