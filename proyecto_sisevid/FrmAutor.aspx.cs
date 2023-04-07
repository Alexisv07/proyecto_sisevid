using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;
using System.Web.UI.WebControls;

namespace proyecto_sisevid
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected Autor[] arregloAutor = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlAutor objControlAutor = new ControlAutor();
            arregloAutor = objControlAutor.listar();

        }

        protected void btnGuardar(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string ident = txtIdent.Text;
            string nom = txtNom.Text;

            Autor objAutor = new Autor(id, ident, nom);
            ControlAutor objControlAutor = new ControlAutor(objAutor);
            objControlAutor.guardar();
            Response.Redirect("FrmAutor.aspx");
        }

        protected void btnModificar(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string ident = txtIdent.Text;
            string nom = txtNom.Text;

            Autor objAutor = new Autor(id, ident, nom);
            ControlAutor objControlAutor = new ControlAutor(objAutor);
            objControlAutor.modificar();
            Response.Redirect("FrmAutor.aspx");
        }
        protected void btnConsultar(object sender, CommandEventArgs e)
        {
            Autor objAutor = new Autor(txtId.Text, "", "");
            ControlAutor objControlAutor = new ControlAutor(objAutor);
            objAutor = objControlAutor.consultar();
            txtId.Text = objAutor.Id;
            txtIdent.Text = objAutor.Ident;
            txtNom.Text = objAutor.Nom;
        }

        protected void btnBorrar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            Autor objAutor = new Autor(id, "", "");
            ControlAutor objControlAutor = new ControlAutor(objAutor);
            objControlAutor.borrar();
            Response.Redirect("FrmAutor.aspx");
        }
    }
}