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
    public partial class FrmSentido : System.Web.UI.Page
    {
        protected Sentido[] arregloSentido = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlSentido objControlSentido = new ControlSentido();
            arregloSentido = objControlSentido.listar();
        }

        protected void btnGuardar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string nom = txtNom.Text;

            Sentido objSentido = new Sentido(id, nom);
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            objControlSentido.guardar();
            Response.Redirect("FrmSentido.aspx");
        }

        protected void btnModificar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string nom = txtNom.Text;

            Sentido objSentido = new Sentido(id, nom);
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            objControlSentido.modificar();
            Response.Redirect("FrmSentido.aspx");
        }

        protected void btnConsultar(object sender, CommandEventArgs e)
        {
            Sentido objSentido = new Sentido(txtId.Text, "");
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            objControlSentido.consultar();
            txtId.Text = objSentido.Id;
            txtNom.Text = objSentido.Nom;
        }

        protected void btnBorrar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;

            Sentido objSentido = new Sentido(id, "");
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            objControlSentido.borrar();
            Response.Redirect("FrmSentido.aspx");
        }
    }
}