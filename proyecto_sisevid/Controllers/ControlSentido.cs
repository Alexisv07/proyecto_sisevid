using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlSentido
    {
        Sentido objSentido;
        string baseDeDatos;

        public ControlSentido(Sentido objSentido)
        {
            this.objSentido = objSentido;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlSentido()
        {
            this.objSentido = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }
        public void guardar()
        {
            string id = objSentido.Id;
            string nom = objSentido.Nom;

            string comandoSQL =
            String.Format("INSERT INTO sentido  (nombre) VALUES ('{0}')", nom);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void modificar()
        {
            string id = objSentido.Id;
            string nom = objSentido.Nom;

            string comandoSQL =
            String.Format("UPDATE sentido SET nombre='{0}' WHERE id='{1}'", nom, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Sentido consultar()
        {
            string msg = "ok";
            string id = objSentido.Id;
            string comandoSQL =
            String.Format("SELECT * FROM sentido WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objSentido.Id = objDataSet.Tables[0].Rows[0][0].ToString();
                    objSentido.Nom = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objSentido;
        }
        public void borrar()
        {
            string id = objSentido.Id;
            string nom = objSentido.Nom;

            string comandoSQL =
            String.Format("DELETE FROM sentido WHERE id='{0}'", id, nom);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Sentido[] listar()
        {
            string msg = "ok";
            int i;
            Sentido[] arregloSentido = null;
            string comandoSQL = String.Format("SELECT * FROM sentido");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloSentido = new Sentido[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objSentido = new Sentido();
                        objSentido.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objSentido.Nom = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloSentido[i] = objSentido;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloSentido;
        }
    }
}