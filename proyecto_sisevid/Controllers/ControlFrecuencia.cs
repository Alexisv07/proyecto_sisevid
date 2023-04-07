using proyecto_sisevid.Models;
using System;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlFrecuencia
    {
        Frecuencia objFrecuencia;
        string baseDeDatos;

        public ControlFrecuencia(Frecuencia objFrecuencia)
        {
            this.objFrecuencia = objFrecuencia;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlFrecuencia()
        {
            this.objFrecuencia = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {
            string Id = objFrecuencia.Id;
            string Descripcion = objFrecuencia.Descripcion;

            string comandoSQL =
            String.Format("INSERT INTO frecuencia (descripcion) VALUES ('{0}')", Descripcion);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void modificar()
        {
            string Id = objFrecuencia.Id;
            string descripcion = objFrecuencia.Descripcion;

            string comandoSQL =
            String.Format("UPDATE frecuencia SET descripcion='{0}' WHERE id='{1}'", descripcion, Id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public Frecuencia consultar()
        {
            string msg = "ok";
            string Id = objFrecuencia.Id;
            string comandoSQL =
            String.Format("SELECT * FROM frecuencia WHERE id='{0}'", Id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objFrecuencia.Id = objDataSet.Tables[0].Rows[0][0].ToString();
                    objFrecuencia.Descripcion = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objFrecuencia;
        }

        public void borrar()
        {
            string Id  = objFrecuencia.Id;
            string descriocion = objFrecuencia.Descripcion;

            string comandoSQL =
            String.Format("DELETE FROM frecuencia WHERE id='{0}'", Id, descriocion);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();

        }

        public Frecuencia[] listar()
        {
            string msg = "ok";
            int i;
            Frecuencia[] arregloFrecuencia = null;
            string comandoSQL = String.Format("SELECT * FROM frecuencia");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloFrecuencia = new Frecuencia[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objFrecuencia = new Frecuencia();
                        objFrecuencia.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objFrecuencia.Descripcion = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloFrecuencia[i] = objFrecuencia;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloFrecuencia;
        }

    }
}

