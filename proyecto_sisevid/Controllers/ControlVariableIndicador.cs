using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlVariableIndicador
    {
        VariableIndicador objvariableIndicador;
        string baseDeDatos;

        public ControlVariableIndicador(VariableIndicador objvariable_Indicador)
        {
            this.objvariableIndicador = objvariable_Indicador;
            baseDeDatos = "bd_sisevid_015224.mdf";

        }
        public ControlVariableIndicador()
        {
            this.objvariableIndicador = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {

            int fkidvariable = objvariableIndicador.fkidvariable;
            int fkidindicador = objvariableIndicador.fkidindicador;
            double dato = objvariableIndicador.dato;
            DateTime fechadato = objvariableIndicador.Fechadatos;
            string fknomusuario = objvariableIndicador.fknomusuario;
            string comandoSQL =
            String.Format("INSERT INTO variable_indicador VALUES ('{0}','{1}','{2}','{3}','{4}')", fkidvariable, fkidindicador, dato, fechadato, fknomusuario);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public VariableIndicador consultar()
        {
            string msg = "ok";
            int id = objvariableIndicador.id;
            string comandoSQL =
            String.Format("SELECT * FROM variable_indicador WHERE id={0}", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objvariableIndicador.id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objvariableIndicador.fkidvariable = Convert.ToInt32(objDataSet.Tables[0].Rows[0][1].ToString());
                    objvariableIndicador.fkidindicador = Convert.ToInt32(objDataSet.Tables[0].Rows[0][2].ToString());
                    objvariableIndicador.dato = Convert.ToDouble(objDataSet.Tables[0].Rows[0][3].ToString());
                    objvariableIndicador.Fechadatos = DateTime.Parse(objDataSet.Tables[0].Rows[0][4].ToString());
                    objvariableIndicador.fknomusuario = objDataSet.Tables[0].Rows[0][5].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objvariableIndicador;

        }
        public void modificar()
        {

            int id = objvariableIndicador.id;
            int fkidvariable = objvariableIndicador.fkidvariable;
            int fkidindicador = objvariableIndicador.fkidindicador;
            double dato = objvariableIndicador.dato;
            DateTime fechadato = objvariableIndicador.Fechadatos;
            string fknomusuario = objvariableIndicador.fknomusuario;

            string comandoSQL =
            String.Format("UPDATE variable_indicador SET fkidvariable='{1}' ,fkidindicador='{2}' ,dato='{3}' ,fechadato='{4}', fknomusuario='{5}' " +
            " WHERE id={0}", id, fkidvariable, fkidindicador, dato, fechadato, fknomusuario);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objvariableIndicador.id;
            string comandoSQL =
            String.Format("DELETE FROM variable_indicador WHERE id={0}", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public VariableIndicador[] listar()
        {
            string msg = "ok";
            int i;
            VariableIndicador[] arreglovariable_indicador = null;
            string comandoSQL = String.Format("SELECT * FROM variable_indicador");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arreglovariable_indicador = new VariableIndicador[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objvariableIndicador = new VariableIndicador();
                        objvariableIndicador.id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objvariableIndicador.fkidvariable = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        objvariableIndicador.fkidindicador = Convert.ToInt32(objDataSet.Tables[0].Rows[i][2].ToString());
                        objvariableIndicador.dato = Convert.ToDouble(objDataSet.Tables[0].Rows[i][3].ToString());
                        objvariableIndicador.Fechadatos = DateTime.Parse(objDataSet.Tables[0].Rows[i][4].ToString());
                        objvariableIndicador.fknomusuario = objDataSet.Tables[0].Rows[i][5].ToString();

                        arreglovariable_indicador[i] = objvariableIndicador;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return arreglovariable_indicador;
        }
    }
}