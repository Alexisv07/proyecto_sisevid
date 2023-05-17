using proyecto_sisevid.Models;
using System;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlResultadoIndicador
    {
        ResultadoIndicador objResultado;
        string baseDeDatos;

        public ControlResultadoIndicador(ResultadoIndicador objResultado)
        {
            this.objResultado = objResultado;
            baseDeDatos = "BD_SISEVID_015224.mdf";

        }
        public ControlResultadoIndicador()
        {
            this.objResultado = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }

        public void guardar()
        {
            double Resultado = objResultado.resultado;
            DateTime fechaCalculo = objResultado.FechaCalculo;
            int fkidindicador = objResultado.fkidindicador;


            string comandoSQL =
            String.Format("INSERT INTO resultadoindicador(resultado,fechacalculo,fkidindicador) VALUES ('{0}','{1}','{2}')", Resultado, fechaCalculo, fkidindicador);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public ResultadoIndicador consultar()
        {
            string msg = "ok";
            int Id = objResultado.id;
            string comandoSQL =
            String.Format("SELECT * FROM resultadoindicador WHERE id='{0}'", Id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objResultado.id = int.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objResultado.resultado = double.Parse(objDataSet.Tables[0].Rows[0][1].ToString());
                    objResultado.FechaCalculo = DateTime.Parse(objDataSet.Tables[0].Rows[0][2].ToString());
                    objResultado.fkidindicador = int.Parse(objDataSet.Tables[0].Rows[0][3].ToString());
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objResultado;

        }
        public void modificar()
        {
            int Id = objResultado.id;
            double Resultado = objResultado.resultado;
            DateTime fechaC = objResultado.FechaCalculo;


            string comandoSQL =
            String.Format("UPDATE resultadoindicador SET fechacalculo='{2}',resultado='{1}' WHERE id='{0}'", Id, Resultado, fechaC);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objResultado.id;
            string comandoSQL =
            String.Format("DELETE FROM resultadoindicador WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public ResultadoIndicador[] listar()
        {
            string msg = "ok";
            int i;
            ResultadoIndicador[] arregloResultado = null;
            string comandoSQL = String.Format("SELECT * FROM resultadoindicador");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count >= 0)
                {
                    i = 0;
                    arregloResultado = new ResultadoIndicador[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objResultado = new ResultadoIndicador();
                        objResultado.id = int.Parse(objDataSet.Tables[0].Rows[i][0].ToString());
                        objResultado.resultado = int.Parse(objDataSet.Tables[0].Rows[i][1].ToString());
                        objResultado.FechaCalculo = DateTime.Parse(objDataSet.Tables[0].Rows[i][2].ToString());
                        objResultado.fkidindicador = int.Parse(objDataSet.Tables[0].Rows[i][3].ToString());

                        arregloResultado[i] = objResultado;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloResultado;
        }
        public string consultarResultadoindicador_por_Idindicador()
        {
            string msg = "ok";

            string resultadoIndicador = null;
            int idIndi = objResultado.fkidindicador;
            string comandoSQL =
            String.Format("SELECT ind.id FROM indicador as ind  INNER JOIN resultadoindicador as rti ON rti.fkidindicador=ind.id WHERE rti.fkidindicador='{0}'", idIndi);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    resultadoIndicador = objDataSet.Tables[0].Rows[0][3].ToString();

                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return resultadoIndicador;
        }
    }
}
