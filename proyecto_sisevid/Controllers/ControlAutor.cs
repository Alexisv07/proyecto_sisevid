using proyecto_sisevid.Models;
using System;
using System.Data;
using System.Xml.Linq;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace proyecto_sisevid.Controllers
{
    public class ControlAutor
    {
        Autor objAutor;
        string baseDeDatos;

        public ControlAutor(Autor objAutor)
        {
            this.objAutor = objAutor;
            baseDeDatos = "bd_sisevid_015224.mdf";

        }

        public ControlAutor()
        {
            this.objAutor = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }
        public void guardar()
        {
            string id = objAutor.Id;
            string ident = objAutor.Ident;
            string nom = objAutor.Nom;
            

            string comandoSQL =
            String.Format("INSERT INTO tblAutor VALUES ('{0}','{1}')",  ident, nom);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public void modificar()
        {
            string id = objAutor.Id;
            string nom = objAutor.Nom;
            string ident = objAutor.Ident;

            string comandoSQL =
            String.Format("UPDATE tblAutor SET nombre='{0}' WHERE ident='{1}'", id,  nom, ident);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public Autor consultar()
        {
            string msg = "ok";
            string id = objAutor.Id;
            string comandoSQL =
            String.Format("SELECT * FROM tblAutor WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objAutor.Id = objDataSet.Tables[0].Rows[0][0].ToString();
                    objAutor.Ident = objDataSet.Tables[0].Rows[0][1].ToString();
                    objAutor.Nom = objDataSet.Tables[0].Rows[0][2].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objAutor;

        }

        public void borrar()
        {
            string id = objAutor.Id;
            string ident = objAutor.Ident;
            string nom = objAutor.Nom;
            string comandoSQL =
            String.Format("DELETE FROM tblAutor WHERE  id='{0}'", id, nom, ident);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public Autor[] listar()
        {
            string msg = "ok";
            int i;
            Autor[] arregloAutor = null;
            string comandoSQL = String.Format("SELECT * FROM tblAutor");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloAutor = new Autor[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objAutor = new Autor();
                        objAutor.Id = objDataSet.Tables[0].Rows[i][0].ToString();
                        objAutor.Ident = objDataSet.Tables[0].Rows[i][1].ToString();
                        objAutor.Nom = objDataSet.Tables[0].Rows[i][2].ToString();

                        arregloAutor[i] = objAutor;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloAutor;
        }
    }
}