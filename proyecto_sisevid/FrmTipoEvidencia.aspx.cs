using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace proyecto_sisevid
{
    public partial class FrmTipoEvidencia : System.Web.UI.Page
    {
        protected TipoEvidencia[] arregloTipoEvidencia = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlTipoEvidencia objControlTipoEvidencia = new ControlTipoEvidencia();
            arregloTipoEvidencia = objControlTipoEvidencia.listar();
        }

        protected void btnGuardar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string name = txtNom.Text;

            TipoEvidencia objTipoEvidencia = new TipoEvidencia(id, name);
            ControlTipoEvidencia objControlTipoEvidencia = new ControlTipoEvidencia(objTipoEvidencia);
            objControlTipoEvidencia.guardar();
            //txtId.Enabled = false; 
            Response.Redirect("FrmTipoEvidencia.aspx");
        }

        protected void btnModifcar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string name = txtNom.Text;

            TipoEvidencia objTipoEvidencia = new TipoEvidencia(id, name);
            ControlTipoEvidencia objControlTipoEvidencia = new ControlTipoEvidencia(objTipoEvidencia);
            objControlTipoEvidencia.modificar();
            Response.Redirect("FrmTipoEvidencia.aspx");
        }

        protected void btnConsultar(object sender, CommandEventArgs e)
        {
            TipoEvidencia objTipoEvidencia = new TipoEvidencia(txtId.Text, "");
            ControlTipoEvidencia objControlTipoEvidencia = new ControlTipoEvidencia(objTipoEvidencia);
            objControlTipoEvidencia.consultar();
            txtId.Text = objTipoEvidencia.Id;
            txtNom.Text = objTipoEvidencia.Name;
        }

        protected void btnBorrar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;

            TipoEvidencia objTipoEvidencia = new TipoEvidencia(id, "");
            ControlTipoEvidencia objControlTipoEvidencia = new ControlTipoEvidencia(objTipoEvidencia);
            objControlTipoEvidencia.borrar();
            Response.Redirect("FrmTipoEvidencia.aspx");
        }
    }
}