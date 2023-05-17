using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;

namespace proyecto_sisevid
{

    public partial class FrmEvidencia : System.Web.UI.Page
    {
        protected Evidencia[] arregloEvidencia = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlEvidencia objControlEvidencia = new ControlEvidencia();
            arregloEvidencia = objControlEvidencia.listar();
        }

        protected void fechaR(object sender, EventArgs e)
        {
            string fecha = txtFechaR.Text;
            _ = DateTime.Parse(fecha);

            DateTime ahora = DateTime.Now;
            ahora = ahora.AddYears(1);

            if (fecha.CompareTo(ahora) <= 0)
            {
                int resultado = ahora.CompareTo(ahora);
                if (resultado > 0)
                    Response.Write("<script> alert(" + "' Ya existe una fecha registrada'" + ") </script>");
                else if (resultado < 0)
                    Response.Write("<script> alert(" + "' Ocurrio un error al realizar el registro '" + ") </script>");
                else if (resultado > 0)
                    Response.Write("~/indicador.aspx");
            }

            txtFechaR.AccessKey = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {

            }
            else
            {
                txtArchi.Text = "Debes seleccionar un Archivo";
            }
        }
    }
}