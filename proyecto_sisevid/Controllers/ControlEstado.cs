using proyecto_sisevid.Models;
using System;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlEstado
    {
        Estado objEstado;
        string baseDeDatos;

        public ControlEstado(Estado objEstado)
        {
            this.objEstado = objEstado;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlEstado()
        {
            this.objEstado = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {
            string id = objEstado.Id;
            string nom = objEstado.Nom;

            string comandoSQL =
            String.Format("INSERT INTO tblestado VALUES ('{0}','{1}')", id, nom);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void modificar()
        {
            string id = objEstado.Id;
            string nom = objEstado.Nom;

            string comandoSQL =
            String.Format("UPDATE tblestado SET nombre='{0}' WHERE id='{1}'", nom, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public Estado consultar()
        {
            string msg = "ok";
            string id = objEstado.Id;
            string comandoSQL =
            String.Format("SELECT * FROM tblestado WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objEstado.Id = objDataSet.Tables[0].Rows[0][0].ToString();
                    objEstado.Nom = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objEstado;
        }

        public void borrar()
        {
            string id = objEstado.Id;
            string nom = objEstado.Nom;

            string comandoSQL =
            String.Format("DELETE FROM tblestado WHERE id='{0}'", id, nom);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();

        }

        public Estado[] listar()
        {
            string msg = "ok";
            int i;
            Estado[] arregloEstado = null;
            string comandoSQL = String.Format("SELECT * FROM tblestado");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloEstado = new Estado[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objEstado = new Estado();
                        objEstado.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objEstado.Nom = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloEstado[i] = objEstado;
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