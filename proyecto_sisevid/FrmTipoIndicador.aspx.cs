using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;
using System.Web.UI.WebControls;

namespace proyecto_sisevid
{
    public partial class FrmTipoIndicador : System.Web.UI.Page
    {
        protected TipoIndicador[] arregloTipoIndicador = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador();
            arregloTipoIndicador = objControlTipoIndicador.listar();

        }

        protected void btnGuardar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string nom = txtNom.Text;

            TipoIndicador objTipoIndicador = new TipoIndicador(id, nom);
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objControlTipoIndicador.guardar();
            //txtId.Enabled = false; 
            Response.Redirect("FrmTipoIndicador.aspx");
        }

        protected void btnModificar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string nom = txtNom.Text;

            TipoIndicador objTipoIndicador = new TipoIndicador(id, nom);
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objControlTipoIndicador.modificar();
            Response.Redirect("FrmTipoIndicador.aspx");
        }

        protected void btnCosultar(object sender, CommandEventArgs e)
        {
            TipoIndicador objTipoIndicador = new TipoIndicador(txtId.Text, "");
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objTipoIndicador = objControlTipoIndicador.consultar();
            txtId.Text = objTipoIndicador.Id;
            txtNom.Text = objTipoIndicador.Nom;
        }

        protected void btnBorrar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            TipoIndicador objTipoIndicador = new TipoIndicador(id, "");
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objControlTipoIndicador.borrar();
            Response.Redirect("FrmTipoIndicador.aspx");

        }

        protected void txtNom_TextChanged(object sender, EventArgs e)
        {
            if (txtNom.Text=="" && txtId.Text=="")
            {
                Button1.Enabled = false;
            }
            else if (txtNom.Text != "" && txtId.Text != "")
            {
                Button1.Enabled = false;
            }
            else if (txtNom.Text != "" && txtId.Text == "")
            {
                Button1.Enabled = true;
            }

        }
    }
}