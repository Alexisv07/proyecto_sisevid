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
    public partial class FrmFrecuencia : System.Web.UI.Page
    {
        protected Frecuencia[] arregloFrecuencia = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia();
            arregloFrecuencia = objControlFrecuencia.listar();
        }

        protected void btnGuardar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string Descripcion = txtDescripcion.Text;

            Frecuencia objFrecuencia = new Frecuencia(id, Descripcion);
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            objControlFrecuencia.guardar();
            //txtId.Enabled = false; 
            Response.Redirect("FrmFrecuencia.aspx");
        }

        protected void btnModificar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string Descripcion = txtDescripcion.Text;

            Frecuencia objFrecuencia = new Frecuencia(id, Descripcion);
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            objControlFrecuencia.modificar();
            Response.Redirect("FrmFrecuencia.aspx");
        }

        protected void btnConsultar(object sender, CommandEventArgs e)
        {
            Frecuencia objFrecuencia = new Frecuencia(txtId.Text, "");
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            objFrecuencia = objControlFrecuencia.consultar();
            txtId.Text = objFrecuencia.Id;
            txtDescripcion.Text = objFrecuencia.Descripcion;
        }

        protected void btnBorrar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;

            Frecuencia objFrecuencia = new Frecuencia(id, "");
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            objControlFrecuencia.borrar();
            Response.Redirect("FrmFrecuencia.aspx");
        }
    }
}