using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlFuenteIndicador
    {
        FuenteIndicador objFuenteIndicador;
        string baseDeDatos;

        public ControlFuenteIndicador(FuenteIndicador objFuenteIndicador)
        {
            this.objFuenteIndicador = objFuenteIndicador;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlFuenteIndicador()
        {
            this.objFuenteIndicador = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {
            int fkidfuente = objFuenteIndicador.Fkidfuente;
            int fkidindicador = objFuenteIndicador.Fkidindicador;

            string comandoSQL =
            String.Format("INSERT INTO fuente_indicador VALUES ('{0}',{1})", fkidfuente, fkidindicador);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public string[,] consultarFuente_por_Indicador()
        {
            string msg = "ok";
            int i;
            string[,] matFuenteIndicador = null;
            int Fkidfuente = objFuenteIndicador.Fkidfuente;
            string comandoSQL =
            String.Format("SELECT fuente.id,indicador.id " +
                        "FROM fuente INNER JOIN indicador ON fuente.id=indicador.fkidindicador" +
                        " WHERE fuente.fkidfuente='{0}'", Fkidfuente);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    matFuenteIndicador = new string[objDataSet.Tables[0].Rows.Count, 2];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        matFuenteIndicador[i, 0] = objDataSet.Tables[0].Rows[i][0].ToString();
                        matFuenteIndicador[i, 1] = objDataSet.Tables[0].Rows[i][1].ToString();
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch(Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return matFuenteIndicador;
        }
        public void borrarDelaFuente()
        {
            int Fkidfuente = objFuenteIndicador.Fkidfuente;

            string comandoSQL =
            String.Format("DELETE FROM fuente_indicador WHERE Fkidfuente='{0}'", Fkidfuente);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
    }
}