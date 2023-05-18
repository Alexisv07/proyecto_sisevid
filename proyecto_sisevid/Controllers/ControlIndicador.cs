using Microsoft.SqlServer.Server;
using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlIndicador
    {
        Indicador objIndicador;
        string baseDeDatos;
        
        public ControlIndicador(Indicador objIndicador)
        {
            this.objIndicador = objIndicador;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlIndicador()
        {
            this.objIndicador = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {
            int id = objIndicador.Id;
            string codigo = objIndicador.Codigo;
            string nombre = objIndicador.Nombre;
            string objetivo = objIndicador.Objetivo;
            string alcance = objIndicador.Alcance;
            string formula = objIndicador.Formula;
            int fkidtipoindicador = objIndicador.Fkidtipoindicador;
            int fkidunidadmedicion = objIndicador.Fkidunidadmedicion;
            string meta = objIndicador.Meta;
            int fkidsentido = objIndicador.Fkidsentido;
            int fkidfrecuencia = objIndicador.Fkidfrecuencia;

            string comandoSQL =
            String.Format("INSERT INTO indicador VALUES ('{0}','{1}','{2}','{3}'" +
            "'{4}','{5}''{6}','{7}','{8}','{9}','{10}')", id, codigo, nombre, objetivo,
            alcance, formula, fkidtipoindicador, fkidunidadmedicion, meta,
            fkidsentido, fkidfrecuencia);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public Indicador consultar()
        {
            string msg = "ok";
            int id = objIndicador.Id;
            string comandoSQL =
            String.Format("SELECT * FROM indicador WHERE id={0}", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objIndicador.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objIndicador.Codigo = objDataSet.Tables[0].Rows[0][1].ToString();
                    objIndicador.Nombre = objDataSet.Tables[0].Rows[0][2].ToString();
                    objIndicador.Objetivo = objDataSet.Tables[0].Rows[0][3].ToString();
                    objIndicador.Alcance = objDataSet.Tables[0].Rows[0][4].ToString();
                    objIndicador.Formula = objDataSet.Tables[0].Rows[0][5].ToString();
                    objIndicador.Fkidtipoindicador = Convert.ToInt32(objDataSet.Tables[0].Rows[0][6].ToString());
                    objIndicador.Fkidunidadmedicion = Convert.ToInt32(objDataSet.Tables[0].Rows[0][7].ToString());
                    objIndicador.Meta = objDataSet.Tables[0].Rows[0][8].ToString();
                    objIndicador.Fkidsentido = Convert.ToInt32(objDataSet.Tables[0].Rows[0][9].ToString());
                    objIndicador.Fkidfrecuencia = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                }
             }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objIndicador;
        }

        public void modificar()
        {
            int id = objIndicador.Id;
            string codigo = objIndicador.Codigo;
            string nombre = objIndicador.Nombre;
            string objetivo = objIndicador.Objetivo;
            string alcance = objIndicador.Alcance;
            string formula = objIndicador.Formula;
            int fkidtipoindicador = objIndicador.Fkidtipoindicador;
            int fkidunidadmedicion = objIndicador.Fkidunidadmedicion;
            string meta = objIndicador.Meta;
            int fkidsentido = objIndicador.Fkidsentido;
            int fkidfrecuencia = objIndicador.Fkidfrecuencia;

            string comandoSQL =
            String.Format("UPDATE INTO indicador VALUES ('{0}','{1}','{2}','{3}'" +
            "'{4}','{5}''{6}','{7}','{8}','{9}','{10}')", id, codigo, nombre, objetivo,
            alcance, formula, fkidtipoindicador, fkidunidadmedicion, meta,
            fkidsentido, fkidfrecuencia);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public void borrar()
        {
            int id = objIndicador.Id;
            string comandoSQL =
            String.Format("DELETE FROM indicador WHERE id={0}", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public Indicador[] listar()
        {
            string msg = "ok";
            int i;
            Indicador[] arregloIndicador = null;
            string comandoSQL = String.Format("SELECT * FROM indicador");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);

            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloIndicador = new Indicador[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objIndicador = new Indicador();
                        objIndicador.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objIndicador.Codigo = objDataSet.Tables[0].Rows[i][1].ToString();
                        objIndicador.Nombre = objDataSet.Tables[0].Rows[i][2].ToString();
                        objIndicador.Objetivo = objDataSet.Tables[0].Rows[i][3].ToString();
                        objIndicador.Alcance = objDataSet.Tables[0].Rows[i][4].ToString();
                        objIndicador.Formula = objDataSet.Tables[0].Rows[i][5].ToString();
                        objIndicador.Fkidtipoindicador = Convert.ToInt32(objDataSet.Tables[0].Rows[i][6].ToString());
                        objIndicador.Fkidunidadmedicion = Convert.ToInt32(objDataSet.Tables[0].Rows[i][7].ToString());
                        objIndicador.Meta = objDataSet.Tables[0].Rows[i][8].ToString();
                        objIndicador.Fkidsentido = Convert.ToInt32(objDataSet.Tables[i].Rows[i][9].ToString());
                        objIndicador.Fkidfrecuencia = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());

                        arregloIndicador[i] = objIndicador;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return arregloIndicador;
        }
    }

}