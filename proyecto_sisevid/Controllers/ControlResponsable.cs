using proyecto_sisevid.Models;
using System;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlResponsable
    {
        Responsable objResponsable;
        string baseDeDatos;

        public ControlResponsable(Responsable objResponsable)
        {
            this.objResponsable = objResponsable;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlResponsable()
        {
            this.objResponsable = null;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {
            string cc = objResponsable.Cc;
            string Name = objResponsable.Name;
            string email = objResponsable.Email;


            string comandoSQL =
            String.Format("INSERT INTO responsable VALUES ('{0}','{1}', '{2}')", cc, Name, email);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public void modificar()
        {
                string cc = objResponsable.Cc;
                string Name = objResponsable.Name;
                string email = objResponsable.Email;

                string comandoSQL =
                String.Format("UPDATE responsable SET nombre='{0}', email='{1}' WHERE  cedula='{2}'", Name, email, cc);
                ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
                objControlConexion.abrirBD();
                objControlConexion.ejecutarComandoSQL(comandoSQL);
                objControlConexion.cerrarBD();
        }
        public Responsable consultar()
        {
            string msg = "ok";
            string cc = objResponsable.Cc;
            string comandoSQL =
            String.Format("SELECT * FROM responsable WHERE cedula='{0}'", cc);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objResponsable.Cc = objDataSet.Tables[0].Rows[0][0].ToString();
                    objResponsable.Name = objDataSet.Tables[0].Rows[0][1].ToString();
                    objResponsable.Email = objDataSet.Tables[0].Rows[0][2].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objResponsable;
        }
        public void borrar()
        {
            string cc = objResponsable.Cc;
            string Name = objResponsable.Name;
            string email = objResponsable.Email;

            string comandoSQL =
            String.Format("DELETE FROM responsable WHERE  cedula='{0}'", cc, Name, email);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Responsable[] listar()
        {
            string msg = "ok";
            int i;
            Responsable[] arregloResponsable = null;
            string comandoSQL = String.Format("SELECT * FROM responsable");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloResponsable = new Responsable[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objResponsable = new Responsable();
                        objResponsable.Cc = objDataSet.Tables[0].Rows[i][0].ToString();
                        objResponsable.Name = objDataSet.Tables[0].Rows[i][1].ToString();
                        objResponsable.Email = objDataSet.Tables[0].Rows[i][2].ToString();

                        arregloResponsable[i] = objResponsable;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloResponsable;
        }
    }
}