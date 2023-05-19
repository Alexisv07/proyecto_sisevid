using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace proyecto_sisevid
{
    public partial class FrmIndicador : System.Web.UI.Page
    {
        protected Indicador[] arregloIndicador = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlIndicador objControlIndicador = new ControlIndicador();
            arregloIndicador = objControlIndicador.listar();
        }

        protected void btnGuardar(object sender, CommandEventArgs e)
        {
            int id = int.Parse(TextId.Text);
            string codigo = TextCod.Text;
            string nombre = textNom.Text;
            string objetivo = TextObje.Text;
            string alcance = TextAlc.Text;
            string formula = TextFormu.Text;
            int fkidtipoindicador = int.Parse(TextTipoIndi.Text);
            int fkidunidadmedicion = int.Parse(TextUndMedi.Text);
            string meta = TextMet.Text;
            int fkidsentido = int.Parse(TextIdSneti.Text);
            int fkidfrecuencia = int.Parse(TextIdFrecu.Text);

            Indicador objIndicador = new Indicador(id, codigo, nombre, objetivo, alcance, formula, fkidtipoindicador, fkidunidadmedicion, meta, fkidsentido, fkidfrecuencia);
            ControlIndicador objControlIndicador = new ControlIndicador(objIndicador);
            objControlIndicador.guardar();
            Response.Redirect("FrmIndicador.aspx");
        }
    }
}