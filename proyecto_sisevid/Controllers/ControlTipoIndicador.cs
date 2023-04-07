using proyecto_sisevid.Models;
using System;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlTipoIndicador
    {
        TipoIndicador objTipoIndicador;
        string baseDeDatos;

        public ControlTipoIndicador(TipoIndicador objTipoIndicador)
        {
            this.objTipoIndicador = objTipoIndicador;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlTipoIndicador()
        {
            this.objTipoIndicador = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {
            string id = objTipoIndicador.Id;
            string nom = objTipoIndicador.Nom;

            string comandoSQL =
            String.Format("INSERT INTO tipoindicador (nombre) VALUES ('{0}')",nom);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public void modificar()
        {
            string id = objTipoIndicador.Id;
            string nom = objTipoIndicador.Nom;

            string comandoSQL =
            String.Format("UPDATE tipoindicador SET nombre='{0}' WHERE id='{1}'", nom, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public TipoIndicador consultar()
        {
            string msg = "ok";
            string id = objTipoIndicador.Id;
            string comandoSQL =
            String.Format("SELECT * FROM tipoindicador WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objTipoIndicador.Id = objDataSet.Tables[0].Rows[0][0].ToString();
                    objTipoIndicador.Nom = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objTipoIndicador;
        }

        public void borrar()
        {
            string id = objTipoIndicador.Id;
            string nom = objTipoIndicador.Nom;

            string comandoSQL =
            String.Format("DELETE FROM tipoindicador WHERE id='{0}'", id, nom);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();

        }
        public TipoIndicador[] listar()
        {
            string msg = "ok";
            int i;
            TipoIndicador[] arregloTipoloIndicador = null;
            string comandoSQL = String.Format("SELECT * FROM tipoindicador");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloTipoloIndicador = new TipoIndicador[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objTipoIndicador = new TipoIndicador();
                        objTipoIndicador.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objTipoIndicador.Nom = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloTipoloIndicador[i] = objTipoIndicador;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloTipoloIndicador;
        }
    }
}