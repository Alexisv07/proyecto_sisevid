using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlEvidenciaAutor
    {
        EvidenciaAutor objEvidenciaAutor;
        string baseDeDatos;

        public ControlEvidenciaAutor(EvidenciaAutor objEvidenciaAutor)
        {
            this.objEvidenciaAutor = objEvidenciaAutor;
            baseDeDatos = "bd_sisevid_015224.mdf";

        }
        public ControlEvidenciaAutor()
        {
            this.objEvidenciaAutor = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }
        public void guardar()
        {
            int fkidevidencia = objEvidenciaAutor.Fkidevidencia;
            int fkidautor = objEvidenciaAutor.Fkiautor;


            string comandoSQL =
            String.Format("INSERT INTO tblevidenciaautor (fkidevidencia,fkiautor) VALUES ('{0}',{1})", fkidevidencia, fkidautor);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public string[,] consultarAutor_por_IdEvidencia()
        {
            string msg = "ok";
            int i;
            string[,] matEvidenciaAutor = null;
            int fkidevidencia = objEvidenciaAutor.Fkidevidencia;
            string comandoSQL =
            String.Format("SELECT Aut.id, Aut.nombre FROM tblAutor as Aut INNER JOIN tblEvidenciaAutor as EvidAut " +
            "ON Aut.id = EvidAut.fkiautor JOIN tblEvidencia as Evid ON EvidAut.fkidEvidencia = Evid.Id " +
            "WHERE EvidAut.fkidevidencia ='{0}'", fkidevidencia);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    matEvidenciaAutor = new string[objDataSet.Tables[0].Rows.Count, 2];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        matEvidenciaAutor[i, 0] = objDataSet.Tables[0].Rows[i][0].ToString();
                        matEvidenciaAutor[i, 1] = objDataSet.Tables[0].Rows[i][1].ToString();
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return matEvidenciaAutor;
        }
        public void borrar()
        {
            int fkidevidencia = objEvidenciaAutor.Fkidevidencia;
            string comandoSQL =
            String.Format("DELETE FROM tblEvidenciaAutor WHERE fkidEvidencia='{0}'", fkidevidencia);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
    }
}
