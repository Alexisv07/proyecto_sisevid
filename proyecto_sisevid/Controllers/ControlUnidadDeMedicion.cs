using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlUnidadDeMedicion
    {
        UnidadDeMedicion objUnidadDeMedicion;
        string baseDeDatos;

        public ControlUnidadDeMedicion(UnidadDeMedicion objUnidadDeMedicion)
        {
            this.objUnidadDeMedicion = objUnidadDeMedicion;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlUnidadDeMedicion()
        {
            this.objUnidadDeMedicion = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }
        public void guardar()
        {
            string Id = objUnidadDeMedicion.Id;
            string Descripcion = objUnidadDeMedicion.Descripcion;

            string comandoSQL =
            String.Format("INSERT INTO unidad_de_medicion (descripcion) VALUES ('{0}')", Descripcion);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void modificar()
        {
            string Id = objUnidadDeMedicion.Id;
            string Descripcion = objUnidadDeMedicion.Descripcion;

            string comandoSQL =
            String.Format("UPDATE unidad_de_medicion SET descripcion='{0}' WHERE id='{1}'", Descripcion, Id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public UnidadDeMedicion consultar()
        {
            string msg = "ok";
            string Id = objUnidadDeMedicion.Id;
            string comandoSQL =
            String.Format("SELECT * FROM unidad_de_medicion WHERE id='{0}'", Id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objUnidadDeMedicion.Id = objDataSet.Tables[0].Rows[0][0].ToString();
                    objUnidadDeMedicion.Descripcion = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objUnidadDeMedicion;
        }
        public void borrar()
        {
            string Id = objUnidadDeMedicion.Id;
            string Descripcion = objUnidadDeMedicion.Descripcion;

            string comandoSQL =
            String.Format("DELETE FROM unidad_de_medicion WHERE id='{0}'", Id, Descripcion);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();

        }
        public UnidadDeMedicion[] listar()
        {
            string msg = "ok";
            int i;
            UnidadDeMedicion[] arregloUnidadDeMedicion = null;
            string comandoSQL = String.Format("SELECT * FROM unidad_de_medicion");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloUnidadDeMedicion = new UnidadDeMedicion[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objUnidadDeMedicion = new UnidadDeMedicion();
                        objUnidadDeMedicion.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objUnidadDeMedicion.Descripcion = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloUnidadDeMedicion[i] = objUnidadDeMedicion;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloUnidadDeMedicion;
        }
    }
}