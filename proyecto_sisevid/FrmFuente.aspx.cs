using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;
using System.Web.UI.WebControls;

namespace proyecto_sisevid
{
    public partial class FrmFuente : System.Web.UI.Page
    {
        protected Fuente[] arregloFuente = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlFuente objcontrolFuente = new ControlFuente();
            arregloFuente = objcontrolFuente.listar();

        }

        protected void btnGuardar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string nom = txtNom.Text;

            Fuente objFuente = new Fuente(id, nom);
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.guardar();
            //txtId.Enabled = false; 
            Response.Redirect("FrmFuente.aspx");
        }

        protected void btnModificar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string nom = txtNom.Text;

            Fuente objFuente = new Fuente(id, nom);
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.modificar();
            Response.Redirect("FrmFuente.aspx");
        }

        protected void btnConsultar(object sender, CommandEventArgs e)
        {
            Fuente objFuente = new Fuente(txtId.Text, "");
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objFuente = objControlFuente.consultar();
            txtId.Text = objFuente.Id;
            txtNom.Text = objFuente.Nom;
        }

        protected void btnBorrar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            Fuente objFuente = new Fuente(id, "");
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.borrar();
            Response.Redirect("FrmFuente.aspx");
        }
    }
}