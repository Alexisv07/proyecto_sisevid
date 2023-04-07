using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;
using System.Web.UI.WebControls;

namespace proyecto_sisevid
{
    public partial class FrmEstado : System.Web.UI.Page
    {
        protected Estado[] arregloEstado = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlEstado onjControlEstado = new ControlEstado();
            arregloEstado = onjControlEstado.listar();

        }

        protected void btnGuardar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string nom = txtNom.Text;

            Estado objEstado = new Estado(id, nom);
            ControlEstado objControlEstado = new ControlEstado(objEstado);
            objControlEstado.guardar();
            //txtId.Enabled = false; 
            Response.Redirect("FrmEstado.aspx");
        }

        protected void btnModificar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string nom = txtNom.Text;

            Estado objEstado = new Estado(id, nom);
            ControlEstado objControlEstado = new ControlEstado(objEstado);
            objControlEstado.modificar();
            Response.Redirect("FrmEstado.aspx");
        }

        protected void brnConsultar(object sender, CommandEventArgs e)
        {
            Estado objEstado = new Estado(txtId.Text, "");
            ControlEstado objControlEstado = new ControlEstado(objEstado);
            objEstado = objControlEstado.consultar();
            txtId.Text = objEstado.Id;
            txtNom.Text = objEstado.Nom;
        }

        protected void btnBorrar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            TipoIndicador objTipoIndicador = new TipoIndicador(id, "");
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objControlTipoIndicador.borrar();
            Response.Redirect("FrmEstado.aspx");
        }
    }
}