using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlArticulo
    {
        Articulo objArticulo;
        string baseDeDatos;

        public ControlArticulo(Articulo objArticulo)
        {
            this.objArticulo = objArticulo;
            baseDeDatos = "bd_sisevid_015224.mdf";

        }
        public ControlArticulo()
        {
            this.objArticulo = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {
            string id = objArticulo.Id;
            string nombre = objArticulo.Nombre;
            string descripcion = objArticulo.Descripcion;
            string fkidtitulo = objArticulo.Fkidtitulo;
            string fkidcapitulo = objArticulo.Fkidcapitulo;
            string fkidseccion = objArticulo.Fkidseccion;

            string comandoSQL =
            String.Format("INSERT INTO fuente VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", id, nombre, descripcion, fkidtitulo, fkidcapitulo, fkidseccion);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Articulo consultar()
        {
            string msg = "ok";
            string id = objArticulo.Id;
            string comandoSQL =
            String.Format("SELECT * FROM tblarticulo WHERE id={0}", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objArticulo.Id = objDataSet.Tables[0].Rows[0][0].ToString();
                    objArticulo.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objArticulo.Descripcion = objDataSet.Tables[0].Rows[0][2].ToString();
                    objArticulo.Fkidtitulo = objDataSet.Tables[0].Rows[0][3].ToString();
                    objArticulo.Fkidcapitulo = objDataSet.Tables[0].Rows[0][4].ToString();
                    objArticulo.Fkidseccion = objDataSet.Tables[0].Rows[0][5].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objArticulo;

        }
        public void modificar()
        {
            string id = objArticulo.Id;
            string nombre = objArticulo.Nombre;
            string descripcion = objArticulo.Descripcion;
            string fkidtitulo = objArticulo.Fkidtitulo;
            string fkidcapitulo = objArticulo.Fkidcapitulo;
            string fkidseccion = objArticulo.Fkidseccion;

            string comandoSQL =
                String.Format("UPDATE tblarticulo SET nombre='{1}', descripcion='{2}' WHERE id={0}", id, nombre, descripcion);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            string id = objArticulo.Id;
            string comandoSQL =
            String.Format("DELETE FROM tblarticulo WHERE id={0}", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Articulo[] listar()
        {
            string msg = "ok";
            int i;
            Articulo[] arregloArticulo = null;
            string comandoSQL = String.Format("SELECT * FROM tblarticulo");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloArticulo = new Articulo[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objArticulo = new Articulo();
                        objArticulo.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objArticulo.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();
                        objArticulo.Descripcion = objDataSet.Tables[0].Rows[i][2].ToString();
                        objArticulo.Fkidtitulo = objDataSet.Tables[0].Rows[i][3].ToString();
                        objArticulo.Fkidcapitulo = objDataSet.Tables[0].Rows[i][4].ToString();
                        objArticulo.Fkidseccion = objDataSet.Tables[0].Rows[i][5].ToString();

                        arregloArticulo[i] = objArticulo;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return arregloArticulo;
        }
    }
}
