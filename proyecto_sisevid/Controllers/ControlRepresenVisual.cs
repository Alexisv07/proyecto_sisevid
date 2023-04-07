using proyecto_sisevid.Models;
using System;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlRepresenVisual
    {
        RepresenVisual objRepresenVisual;
        string baseDeDatos;

        public ControlRepresenVisual(RepresenVisual objRepresenVisual)
        {
            this.objRepresenVisual = objRepresenVisual;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlRepresenVisual()
        {
            this.objRepresenVisual = objRepresenVisual;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {
            string id = objRepresenVisual.Id;
            string name = objRepresenVisual.Name;

            string comandoSQL =
            String.Format("INSERT INTO represenvisual (nombre) VALUES ('{0}')", name);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void modificar()
        {
            string id = objRepresenVisual.Id;
            string name = objRepresenVisual.Name;

            string comandoSQL =
            String.Format("UPDATE represenvisual SET nombre='{0}' WHERE id='{1}'", name, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public RepresenVisual consultar()
        {
            string msg = "ok";
            string id = objRepresenVisual.Id;
            string comandoSQL =
            String.Format("SELECT * FROM represenvisual WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objRepresenVisual.Id = objDataSet.Tables[0].Rows[0][0].ToString();
                    objRepresenVisual.Name = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objRepresenVisual;
        }
        public void borrar()
        {
            string id = objRepresenVisual.Id;
            string nom = objRepresenVisual.Name;

            string comandoSQL =
            String.Format("DELETE FROM represenvisual WHERE id='{0}'", id, nom);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();

        }
        public RepresenVisual[] listar()
        {
            string msg = "ok";
            int i;
            RepresenVisual[] arregloRepresenVisual = null;
            string comandoSQL = String.Format("SELECT * FROM represenvisual");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloRepresenVisual = new RepresenVisual[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objRepresenVisual = new RepresenVisual();
                        objRepresenVisual.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objRepresenVisual.Name = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloRepresenVisual[i] = objRepresenVisual;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloRepresenVisual;
        }
    }
}