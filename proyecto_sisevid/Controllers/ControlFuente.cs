using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlFuente
    {
        Fuente objFuente;
        string baseDeDatos;

        public ControlFuente(Fuente objFuente)
        {
            this.objFuente = objFuente;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlFuente()
        {
            this.objFuente = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {
            string id = objFuente.Id;
            string nom = objFuente.Nom;

            string comandoSQL =
            String.Format("INSERT INTO fuente (nombre) VALUES ('{0}')", nom);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public void modificar()
        {
            string id = objFuente.Id;
            string nom = objFuente.Nom;

            string comandoSQL =
            String.Format("UPDATE fuente SET nombre='{0}' WHERE id='{1}'", nom, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public Fuente consultar()
        {
            string msg = "ok";
            string id = objFuente.Id;
            string comandoSQL =
            String.Format("SELECT * FROM tipoindicador WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objFuente.Id = objDataSet.Tables[0].Rows[0][0].ToString();
                    objFuente.Nom = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objFuente;
        }

        public void borrar()
        {
            string id = objFuente.Id;
            string nom = objFuente.Nom;

            string comandoSQL =
            String.Format("DELETE FROM fuente WHERE id='{0}'", id, nom);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();

        }
        public Fuente[] listar()
        {
            string msg = "ok";
            int i;
            Fuente[] arregloFuente = null;
            string comandoSQL = String.Format("SELECT * FROM fuente");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloFuente = new Fuente[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objFuente = new Fuente();
                        objFuente.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objFuente.Nom = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloFuente[i] = objFuente;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloFuente;
        }
    }
}