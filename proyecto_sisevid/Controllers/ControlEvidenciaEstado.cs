using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlEvidenciaEstado
    {
        EvidenciaEstado objEvidenciaEstado;
        string baseDeDatos;

        public ControlEvidenciaEstado(EvidenciaEstado objEvidenciaEstado)
        {
            this.objEvidenciaEstado = objEvidenciaEstado;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public ControlEvidenciaEstado()
        {
            this.objEvidenciaEstado = objEvidenciaEstado;
            baseDeDatos = "bd_sisevid_015224.mdf";
        }

        public void guardar()
        {
            int id = objEvidenciaEstado.Id;
            int fkidevidencia = objEvidenciaEstado.Fkidevidencia;
            String fkidestado = objEvidenciaEstado.Fkidestado;
            String fkidusuario = objEvidenciaEstado.Fkidusuario;
            DateTime fecha = objEvidenciaEstado.Fehca;

            string comandoSQL =
            String.Format("INSERT INTO tblevidenciaestado VALUES ('{0}',{1})", id, fkidevidencia);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
    }
}