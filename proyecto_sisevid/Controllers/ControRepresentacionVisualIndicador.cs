using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControRepresentacionVisualIndicador
    {
        RepresenVisualIndicador objRepresenVisualIndicador;
        string baseDeDatos;

        public ControRepresentacionVisualIndicador(RepresenVisualIndicador objRepresenVisual_Indicador)
        {
            this.objRepresenVisualIndicador = objRepresenVisual_Indicador;
            baseDeDatos = "bd_sisevid_015224.mdf";

        }
        public ControRepresentacionVisualIndicador()
        {
            this.objRepresenVisualIndicador = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {

            int fkidindicador = objRepresenVisualIndicador.fkidindicador;
            int fkidrepresenvisual = objRepresenVisualIndicador.fkidrepresenvisual;
            string comandoSQL =
            String.Format("INSERT INTO represenvisual_indicador VALUES ('{0}','{1}')", fkidindicador, fkidrepresenvisual);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public string consultarRepresenVisIndicador_por_Idindicador()
        {
            string msg = "ok";
            string RepresenVisualIndicador = null;
            int fkidindicador = objRepresenVisualIndicador.fkidindicador;
            string comandoSQL =

                String.Format("SELECT Ind.id FROM indicador as Ind  INNER JOIN represenvisual_indicador as RepViInd ON RepViInd.fkidindicador =Ind.id  " +
                " WHERE RepViInd.fkidindicador='{0}' ", fkidindicador);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    RepresenVisualIndicador = objDataSet.Tables[0].Rows[0][0].ToString();

                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return RepresenVisualIndicador;
        }


        public string consultarRepresenVisIndicador_por_IdRepresentacionVis()
        {
            string msg = "ok";
            string RepresenVisualIndicador = null;
            int fkidrepresenvisual = objRepresenVisualIndicador.fkidrepresenvisual;
            string comandoSQL =

                String.Format("SELECT RepVis.id  FROM represenvisual as RepVis  INNER JOIN represenvisual_indicador as RpvInd  ON RpvInd.fkidrepresenvisual =RepVis.id  " +
                " WHERE   RpvInd.fkidrepresenvisual='{1}' ", fkidrepresenvisual);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    RepresenVisualIndicador = objDataSet.Tables[0].Rows[0][1].ToString();

                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return RepresenVisualIndicador;
        }

        public RepresenVisualIndicador[] listar()
        {
            string msg = "ok";
            int i;
            RepresenVisualIndicador[] arregloEstado = null;
            string comandoSQL = String.Format("SELECT Ind.id, RepVis.id  FROM represenvisual as RepVis  INNER JOIN represenvisual_indicador as RpvInd  ON RpvInd.fkidrepresenvisual =RepVis.id  " +
                "INNER JOIN indicador as Ind ON RpvInd.fkidindicador = Ind.id  " +
                " WHERE  RepViInd.fkidindicador='{0}', RpvInd.fkidrepresenvisual='{1}'");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloEstado = new RepresenVisualIndicador[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objRepresenVisualIndicador = new RepresenVisualIndicador();
                        objRepresenVisualIndicador.fkidindicador = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objRepresenVisualIndicador.fkidrepresenvisual = Convert.ToInt32(objDataSet.Tables[0].Rows[i][1].ToString());
                        arregloEstado[i] = objRepresenVisualIndicador;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloEstado;
        }

    }
}
