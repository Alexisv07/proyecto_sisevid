using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlTipoEvidencia
    {
        TipoEvidencia objTipoEvidencia;
        string baseDeDatos;

        public ControlTipoEvidencia(TipoEvidencia objTipoEvidencia)
        {
            this.objTipoEvidencia = objTipoEvidencia;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlTipoEvidencia()
        {
            this.objTipoEvidencia = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }
        public void guardar()
        {
            string id = objTipoEvidencia.Id;
            string name = objTipoEvidencia.Name;

            string comandoSQL =
            String.Format("INSERT INTO tbltipoevidencia (nombre) VALUES ('{0}')", name);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void modificar()
        {
            string id = objTipoEvidencia.Id;
            string name = objTipoEvidencia.Name;

            string comandoSQL =
            String.Format("UPDATE tbltipoevidencia SET nombre='{0}' WHERE id='{1}'", name, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public TipoEvidencia consultar()
        {
            string msg = "ok";
            string id = objTipoEvidencia.Id;
            string comandoSQL =
            String.Format("SELECT * FROM tbltipoevidencia WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objTipoEvidencia.Id = objDataSet.Tables[0].Rows[0][0].ToString();
                    objTipoEvidencia.Name = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objTipoEvidencia;
        }
        public void borrar()
        {
            string id = objTipoEvidencia.Id;
            string name = objTipoEvidencia.Name;

            string comandoSQL =
            String.Format("DELETE FROM tbltipoevidencia WHERE id='{0}'", id, name);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public TipoEvidencia[] listar()
        {
            string msg = "ok";
            int i;
            TipoEvidencia[] arregloTipoEvidencia = null;
            string comandoSQL = String.Format("SELECT * FROM tbltipoevidencia");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloTipoEvidencia = new TipoEvidencia[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objTipoEvidencia = new TipoEvidencia();
                        objTipoEvidencia.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objTipoEvidencia.Name = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloTipoEvidencia[i] = objTipoEvidencia;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloTipoEvidencia;
        }
    }
}