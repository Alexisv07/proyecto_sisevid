using proyecto_sisevid.Models;
using System;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlEvidencia
    {
        Evidencia objEvidencia;
        string baseDeDatos;

        public ControlEvidencia(Evidencia objEvidencia)
        {
            this.objEvidencia = objEvidencia;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }
        public ControlEvidencia()
        {
            this.objEvidencia = null;
            this.baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {
            int id = objEvidencia.id;
            DateTime fRegistro = objEvidencia.Fecharegistro;
            DateTime fCreacion = objEvidencia.FechaCreacion;
            string descripcion = objEvidencia.descripcion;
            string NomArchivo = objEvidencia.NomArchivo;
            string LinkArchivo = objEvidencia.LinkArchivo;
            string Observacion = objEvidencia.Observacion;
            int Fkidtipoevidencia = Convert.ToInt32(objEvidencia.Fkidtipoevidencia);
            string Fkidarticulo = objEvidencia.Fkidarticulo;
            string Fkidliteral = objEvidencia.Fkidliteral;
            string Fkidnumeral = objEvidencia.Fkidnumeral;
            string Fkidsubnumeral = objEvidencia.Fkidsubnumeral;
            string comandoSQL =
             String.Format("INSERT INTO tblevidencia (fecharegistro,fechacreacion,descripcion,nomarchivo,linkarchivo,observacion,fkidtipoevidencia,fkidarticulo,fkidliteral,fkidnumeral)  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", fRegistro, fCreacion, descripcion, NomArchivo, LinkArchivo, Observacion, Fkidtipoevidencia, Fkidarticulo, Fkidliteral, Fkidnumeral);
            if (Fkidnumeral.Length == 0)
            {
                comandoSQL =
                String.Format("INSERT INTO tblevidencia (fecharegistro,fechacreacion,descripcion,nomarchivo,linkarchivo,observacion,fkidtipoevidencia,fkidarticulo,fkidliteral)  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", fRegistro, fCreacion, descripcion, NomArchivo, LinkArchivo, Observacion, Fkidtipoevidencia, Fkidarticulo, Fkidliteral);
            }
            if (Fkidliteral.Length == 0)
            {
                comandoSQL =
                String.Format("INSERT INTO tblevidencia (fecharegistro,fechacreacion,descripcion,nomarchivo,linkarchivo,observacion,fkidtipoevidencia,fkidarticulo)  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", fRegistro, fCreacion, descripcion, NomArchivo, LinkArchivo, Observacion, Fkidtipoevidencia, Fkidarticulo);

            }

            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Evidencia consultar()
        {
            string msg = "ok";
            int id = objEvidencia.id;
            string comandoSQL =
            String.Format("SELECT * FROM tblevidencia WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objEvidencia.id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    objEvidencia.Fecharegistro = DateTime.Parse(objDataSet.Tables[0].Rows[0][1].ToString());
                    objEvidencia.FechaCreacion = DateTime.Parse(objDataSet.Tables[0].Rows[0][2].ToString());
                    objEvidencia.descripcion = objDataSet.Tables[0].Rows[0][3].ToString();
                    objEvidencia.NomArchivo = objDataSet.Tables[0].Rows[0][4].ToString();
                    objEvidencia.LinkArchivo = objDataSet.Tables[0].Rows[0][5].ToString();
                    objEvidencia.Observacion = objDataSet.Tables[0].Rows[0][6].ToString();
                    objEvidencia.Fkidtipoevidencia = Convert.ToInt32(objDataSet.Tables[0].Rows[0][7].ToString());
                    objEvidencia.Fkidarticulo = objDataSet.Tables[0].Rows[0][8].ToString();
                    objEvidencia.Fkidliteral = objDataSet.Tables[0].Rows[0][9].ToString();
                    objEvidencia.Fkidnumeral = objDataSet.Tables[0].Rows[0][10].ToString();
                    objEvidencia.Fkidsubnumeral = objDataSet.Tables[0].Rows[0][11].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objEvidencia;

        }
        public void modificar()
        {

            int id = objEvidencia.id;
            DateTime fRegistro = objEvidencia.Fecharegistro;
            DateTime fCreacion = objEvidencia.FechaCreacion;
            string descripcion = objEvidencia.descripcion;
            string NomArchivo = objEvidencia.NomArchivo;
            string LinkArchivo = objEvidencia.LinkArchivo;
            string Observacion = objEvidencia.Observacion;
            int Fkidtipoevidencia = Convert.ToInt32(objEvidencia.Fkidtipoevidencia);
            string Fkidarticulo = objEvidencia.Fkidarticulo;
            string Fkidliteral = objEvidencia.Fkidliteral;
            string Fkidnumeral = objEvidencia.Fkidnumeral;
            string Fkidsubnumeral = objEvidencia.Fkidsubnumeral;

            string comandoSQL =
            String.Format("UPDATE tblevidencia SET descripcion='{0}',nomarchivo='{1}',linkarchivo='{2}',observacion='{3}',fkidtipoevidencia='{4}',fkidarticulo='{5}',fkidliteral='{6}',fkidnumeral='{7}',fkidsubnumeral='{0}' WHERE id='{9}'", descripcion, NomArchivo, LinkArchivo, Observacion, Fkidtipoevidencia, Fkidarticulo, Fkidliteral, Fkidnumeral, id);
            if (Fkidnumeral.Length == 0)
            {

                comandoSQL =
               String.Format("UPDATE tblevidencia SET descripcion='{0}',nomarchivo='{1}',linkarchivo='{2}',observacion='{3}',fkidtipoevidencia='{4}',fkidarticulo='{5}',fkidliteral='{6}' WHERE id='{7}'", descripcion, NomArchivo, LinkArchivo, Observacion, Fkidtipoevidencia, Fkidarticulo, Fkidliteral, id);
            }
            if (Fkidliteral.Length == 0)
            {
                comandoSQL =
                String.Format("UPDATE tblevidencia SET descripcion='{0}',nomarchivo='{1}',linkarchivo='{2}',observacion='{3}',fkidtipoevidencia='{4}',fkidarticulo='{5}' WHERE id='{6}'", descripcion, NomArchivo, LinkArchivo, Observacion, Fkidtipoevidencia, Fkidarticulo, id);
            }
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objEvidencia.id;
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            string comandoSQL =
            String.Format("DELETE FROM tblevidencia WHERE id='{0}'", id);
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Evidencia[] listar()
        {
            string msg = "ok";
            int i;
            Evidencia[] arregloEvidencia = null;
            string comandoSQL = String.Format("SELECT e.id,e.fechacreacion,e.fecharegistro,e.descripcion,e.nomarchivo,e.linkarchivo,e.observacion, tip.nombre ,art.nombre,lit.descripcion,num.descripcion ,subnum.descripcion FROM tblevidencia as E JOIN tblarticulo as art on e.fkidarticulo=art.id JOIN tbltipoevidencia as Tip on e.fkidtipoevidencia=tip.id left JOIN tblliteral as lit on e.fkidliteral=lit.id left JOIN tblnumeral as num on e.fkidnumeral=num.id LEFT JOIN tblsubnumeral as subnum on e.fkidsubnumeral = subnum.id");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloEvidencia = new Evidencia[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objEvidencia = new Evidencia();
                        objEvidencia.id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                        objEvidencia.Fecharegistro = DateTime.Parse(objDataSet.Tables[0].Rows[0][1].ToString());
                        objEvidencia.FechaCreacion = DateTime.Parse(objDataSet.Tables[0].Rows[0][2].ToString());
                        objEvidencia.descripcion = objDataSet.Tables[0].Rows[0][3].ToString();
                        objEvidencia.NomArchivo = objDataSet.Tables[0].Rows[0][4].ToString();
                        objEvidencia.LinkArchivo = objDataSet.Tables[0].Rows[0][5].ToString();
                        objEvidencia.Observacion = objDataSet.Tables[0].Rows[0][6].ToString();
                        objEvidencia.Fkidtipoevidencia = Convert.ToInt32(objDataSet.Tables[0].Rows[0][7].ToString());
                        objEvidencia.Fkidarticulo = objDataSet.Tables[0].Rows[0][8].ToString();
                        objEvidencia.Fkidliteral = objDataSet.Tables[0].Rows[0][9].ToString();
                        objEvidencia.Fkidnumeral = objDataSet.Tables[0].Rows[0][10].ToString();
                        objEvidencia.Fkidsubnumeral = objDataSet.Tables[0].Rows[0][11].ToString();

                        arregloEvidencia[i] = objEvidencia;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloEvidencia;
        }
        public string[,] ListarTipo_Articulo(string tabla)
        {
            string[,] arreglo = null;
            string msg = "ok";
            int i;
            string comandoSQL = String.Format("SELECT id,nombre  FROM {0}", tabla);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arreglo = new string[objDataSet.Tables[0].Rows.Count, 2];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {

                        arreglo[i, 0] = objDataSet.Tables[0].Rows[i][0].ToString();
                        arreglo[i, 1] = objDataSet.Tables[0].Rows[i][1].ToString();
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arreglo;
        }
        public string[,] ListarOtros(string tabla, string foranea, string id)
        {
            string[,] arreglo = null;
            string msg = "ok";
            int i;
            string comandoSQL = String.Format("SELECT id,descripcion  FROM {0} WHERE {1}='{2}'", tabla, foranea, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arreglo = new string[objDataSet.Tables[0].Rows.Count, 2];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {

                        arreglo[i, 0] = objDataSet.Tables[0].Rows[i][0].ToString();
                        arreglo[i, 1] = objDataSet.Tables[0].Rows[i][1].ToString();
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arreglo;
        }
    }
}