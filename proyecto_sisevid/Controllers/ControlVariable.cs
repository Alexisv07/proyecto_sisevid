using proyecto_sisevid.Models;
using System;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlVariable
    {
        Variable objVariable;
        string baseDeDatos;

        public ControlVariable(Variable objVariable)
        {
            this.objVariable = objVariable;
            baseDeDatos = "BD_SISEVID_015224.mdf";

        }
        public ControlVariable()
        {
            this.objVariable = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public void guardar()
        {
            string nombre = objVariable.nombre;
            DateTime fechaCreacion = objVariable.FechaCreacion;
            string fkimailusuario = objVariable.fkimailusuario;

            string comandoSQL =
            String.Format("INSERT INTO variable(nombre,fechacreacion,fkimailusuario) VALUES ('{0}','{1}','{2}')", nombre, fechaCreacion, fkimailusuario);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Variable consultar()
        {
            string msg = "ok";
            int Id = objVariable.id;
            string comandoSQL =
            String.Format("SELECT * FROM variable WHERE id='{0}'", Id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objVariable.id = int.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objVariable.nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objVariable.FechaCreacion = DateTime.Parse(objDataSet.Tables[0].Rows[0][2].ToString());
                    objVariable.fkimailusuario = objDataSet.Tables[0].Rows[0][3].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objVariable;

        }
        public void modificar()
        {
            int Id = objVariable.id;
            string nombre = objVariable.nombre;
            DateTime fechaCr = objVariable.FechaCreacion;


            string comandoSQL =
            String.Format("UPDATE variable SET fechacreacion='{2}',nombre='{1}' WHERE id='{0}'", Id, nombre, fechaCr);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objVariable.id;
            string comandoSQL =
            String.Format("DELETE FROM variable WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Variable[] listar()
        {
            string msg = "ok";
            int i;
            Variable[] arregloVariable = null;
            string comandoSQL = String.Format("SELECT * FROM variable");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count >= 0)
                {
                    i = 0;
                    arregloVariable = new Variable[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objVariable = new Variable();
                        objVariable.id = int.Parse(objDataSet.Tables[0].Rows[i][0].ToString());
                        objVariable.nombre = objDataSet.Tables[0].Rows[i][1].ToString();
                        objVariable.FechaCreacion = DateTime.Parse(objDataSet.Tables[0].Rows[i][2].ToString());
                        objVariable.fkimailusuario = objDataSet.Tables[0].Rows[i][3].ToString();

                        arregloVariable[i] = objVariable;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloVariable;
        }
    }
}
