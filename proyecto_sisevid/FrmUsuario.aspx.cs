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
    public partial class FrmUsuario : System.Web.UI.Page
    {
        protected Usuario[] arregloUsuario = null;
        protected Rol[] arregloRol = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlUsuario objControlUsuario = new ControlUsuario();
            arregloUsuario = objControlUsuario.listar();
            if (!IsPostBack)
            {
                ControlRol objControlRol = new ControlRol();
                arregloRol = objControlRol.listar();
                foreach (var objRol in arregloRol)
                {
                    DropDownList1.Items.Add(objRol.Id + ";" + objRol.Nombre);
                }
            }
        }

        protected void btnGuardar(object sender, CommandEventArgs e)
        {
            //Esto deberia ser una transacción en un proceso alaenado
            string nomU = txtNomUsuario.Text;
            string cont = txtContrasena.Text;
            Usuario objUsuario = new Usuario(nomU, cont);
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            objControlUsuario.guardar();
            for (int i = 0; i < ListBox1.Items.Count; i++) //me recorre los datos de la tabla intermedia para mostrarla en la vista
            {
                string[] cadena = ListBox1.Items[i].ToString().Split(';');
                int idRol = Convert.ToInt32(cadena[0]);
                RolUsuario objRolusuario = new RolUsuario(nomU, idRol);
                ControlRolUsuario objcontrolRolUsuario = new ControlRolUsuario(objRolusuario);
                objcontrolRolUsuario.guardar();
            }

            Response.Redirect("FrmUsuario.aspx");
        }

        protected void btnModificar(object sender, CommandEventArgs e)
        {
            string nomU = txtNomUsuario.Text;
            string cont = txtContrasena.Text;
            Usuario objUsuario = new Usuario(nomU, cont);
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            objControlUsuario.modificar();
            RolUsuario objRolUsuario = new RolUsuario(nomU, 0);
            ControlRolUsuario objControlRolUsuario = new ControlRolUsuario(objRolUsuario);
            objControlRolUsuario.borrarDelNomUsuario();

            for (int i = 0; i < ListBox1.Items.Count; i++)
            {
                string[] cadena = ListBox1.Items[i].ToString().Split(';');
                int idRol = Convert.ToInt32(cadena[0]);
                // int idRol = Convert.ToInt32(ListBox1.Items[i].ToString().Split(';')); Se anida la función
                objRolUsuario = new RolUsuario(nomU, idRol);
                objControlRolUsuario = new ControlRolUsuario(objRolUsuario);
                objControlRolUsuario.guardar();
            }
            Response.Redirect("FrmUsuario.aspx");
        }

        protected void btnConsultar(object sender, CommandEventArgs e)
        {
            Usuario objUsuario = new Usuario(txtNomUsuario.Text, "");
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            objUsuario = objControlUsuario.consultar();
            txtContrasena.Text = objUsuario.Contrasena;
            RolUsuario objRolUsuario = new RolUsuario(objUsuario.NomUsuario, 0);
            ControlRolUsuario objControlRolUsuario = new ControlRolUsuario(objRolUsuario);
            String[,] matRolUsuario = objControlRolUsuario.consultarRoles_por_NomUsuario();

            try
            {
                for (int i = 0; i < matRolUsuario.GetLength(0); i++)
                {
                    ListBox1.Items.Add(matRolUsuario[i, 0] + ";" + matRolUsuario[i, 1]);
                }
            }
            catch (Exception objException)
            {
                string msg = objException.Message;
            }
        }

        protected void btnBorrae(object sender, CommandEventArgs e)
        {
            string nomU = txtNomUsuario.Text;
            Usuario objUsuario = new Usuario(nomU, "");
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            objControlUsuario.borrar();
            Response.Redirect("FrmUsuario.aspx");
        }

        protected void BtnAgegarRol(object sender, CommandEventArgs e)
        {
            ListBox1.Items.Add(DropDownList1.SelectedValue);
            DropDownList1.Items.Remove(DropDownList1.SelectedValue);

            //Response.Redirect("~/usu.aspx?id=addEmployeeModal"); codigo para llevar a la vista en modal luego de ingresar un dato consultaro agregar

        }

        protected void BtnRemoverRol(object sender, CommandEventArgs e)
        {
            ListBox1.Items.Remove(ListBox1.SelectedValue);
        }
    }
}