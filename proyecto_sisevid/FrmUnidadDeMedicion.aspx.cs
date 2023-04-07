using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;
using System.Web.UI.WebControls;

namespace proyecto_sisevid
{
    public partial class FrmUnidadDeMedicion : System.Web.UI.Page
    {
        protected UnidadDeMedicion[] arregloUnidadDeMedicion = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlUnidadDeMedicion objcontrolUnidadDeMedicion = new ControlUnidadDeMedicion();
            arregloUnidadDeMedicion = objcontrolUnidadDeMedicion.listar();

        }

        protected void btnGuardar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string Descripcion = txtDescripcion.Text;

            UnidadDeMedicion objUnidadDeMedicion = new UnidadDeMedicion(id, Descripcion);
            ControlUnidadDeMedicion objcontrolUnidadDeMedicion = new ControlUnidadDeMedicion(objUnidadDeMedicion);
            objcontrolUnidadDeMedicion.guardar();
            Response.Redirect("FrmUnidadDeMedicion.aspx");
        }

        protected void btnModificar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string Descripcion = txtDescripcion.Text;

            UnidadDeMedicion objUnidadDeMedicion = new UnidadDeMedicion(id, Descripcion);
            ControlUnidadDeMedicion objcontrolUnidadDeMedicion = new ControlUnidadDeMedicion(objUnidadDeMedicion);
            objcontrolUnidadDeMedicion.modificar();
            Response.Redirect("FrmUnidadDeMedicion.aspx");
        }

        protected void btnConsultar(object sender, CommandEventArgs e)
        {
            UnidadDeMedicion objUnidadDeMedicion = new UnidadDeMedicion(txtId.Text, "");
            ControlUnidadDeMedicion objcontrolUnidadDeMedicion = new ControlUnidadDeMedicion(objUnidadDeMedicion);
            objcontrolUnidadDeMedicion.consultar();
            txtId.Text = objUnidadDeMedicion.Id;
            txtDescripcion.Text = objUnidadDeMedicion.Descripcion;
        }

        protected void btnBorrar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;

            UnidadDeMedicion objUnidadDeMedicion = new UnidadDeMedicion(txtId.Text, "");
            ControlUnidadDeMedicion objcontrolUnidadDeMedicion = new ControlUnidadDeMedicion(objUnidadDeMedicion);
            objcontrolUnidadDeMedicion.borrar();
            Response.Redirect("FrmUnidadDeMedicion.aspx");
        }
    }
}