using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace proyecto_sisevid
{
    public partial class FrmResponsable : System.Web.UI.Page
    {
        protected Responsable[] arregloResponsable = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlResponsable objControlResponsable = new ControlResponsable();
            arregloResponsable = objControlResponsable.listar();
        }

        protected void btnGuardar(object sender, CommandEventArgs e)
        {
            string cc = txtId.Text;
            string Name = txtName.Text;
            string Email = txtEmail.Text;


            Responsable objResponsable = new Responsable(cc, Name, Email);
            ControlResponsable objControlResponsable = new ControlResponsable(objResponsable);
            objControlResponsable.guardar();
            Response.Redirect("FrmResponsable.aspx");
        }

        protected void btnModificar(object sender, CommandEventArgs e)
        {
            string cc = txtId.Text;
            string Name = txtName.Text;
            string Email = txtEmail.Text;


            Responsable objResponsable = new Responsable(cc, Name, Email);
            ControlResponsable objControlResponsable = new ControlResponsable(objResponsable);
            objControlResponsable.modificar();
            Response.Redirect("FrmResponsable.aspx");
        }

        protected void btnConsultar(object sender, CommandEventArgs e)
        {
            Responsable objResponsable = new Responsable(txtId.Text, "", "");
            ControlResponsable objControlResponsable = new ControlResponsable(objResponsable);
            objControlResponsable.consultar();
            txtId.Text = objResponsable.Cc;
            txtName.Text = objResponsable.Name;
            txtEmail.Text = objResponsable.Email;
        }

        protected void btnBorrar(object sender, CommandEventArgs e)
        {
            string cc = txtId.Text;
            Responsable objResponsable = new Responsable(txtId.Text, "", "");
            ControlResponsable objControlResponsable = new ControlResponsable(objResponsable);
            objControlResponsable.borrar();
            Response.Redirect("FrmResponsable.aspx");
        }
    }
}