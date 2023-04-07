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
    public partial class FrmRepresenVisual : System.Web.UI.Page
    {
        protected RepresenVisual[] arregloRepresenVisual = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlRepresenVisual controlRepresenVisual = new ControlRepresenVisual();
            arregloRepresenVisual = controlRepresenVisual.listar();
        }

        protected void btnGuardar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string Name = txtName.Text;

            RepresenVisual objRepresenVisual = new RepresenVisual(id, Name);
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.guardar();
            //txtId.Enabled = false; 
            Response.Redirect("FrmRepresenVisual.aspx");
        }

        protected void btnModificar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;
            string Name = txtName.Text;

            RepresenVisual objRepresenVisual = new RepresenVisual(id, Name);
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.modificar();
            Response.Redirect("FrmRepresenVisual.aspx");
        }

        protected void Consultar(object sender, CommandEventArgs e)
        {
            RepresenVisual objRepresenVisual = new RepresenVisual(txtId.Text, "");
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.consultar();
            txtId.Text = objRepresenVisual.Id;
            txtName.Text = objRepresenVisual.Name;
        }

        protected void btnBorrar(object sender, CommandEventArgs e)
        {
            string id = txtId.Text;

            RepresenVisual objRepresenVisual = new RepresenVisual(id, "");
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.borrar();  
            Response.Redirect("FrmRepresenVisual.aspx");
        }
    }
}