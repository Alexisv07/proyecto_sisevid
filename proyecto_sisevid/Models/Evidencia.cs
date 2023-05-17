using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Evidencia
    {
        int Id;
        DateTime fecharegistro;
        DateTime fechaCreacion;
        string Descripcion;
        string nomArchivo;
        string linkArchivo;
        string observacion;
        int fkidtipoevidencia;
        string fkidarticulo;
        string fkidliteral;
        string fkidnumeral;
        string fkidsubnumeral;
        string fkidsub_subnumeral;

        public Evidencia(int id, DateTime fecharegistro, DateTime fechaCreacion, string descripcion, string nomArchivo, string linkArchivo, string observacion, int fkidtipoevidencia, string fkidarticulo, string fkidliteral, string fkidnumeral, string fkidsubnumeral, string fkidsub_subnumeral)
        {
            this.Id = id;
            this.Fecharegistro = fecharegistro;
            this.FechaCreacion = fechaCreacion;
            this.Descripcion = descripcion;
            this.NomArchivo = nomArchivo;
            this.LinkArchivo = linkArchivo;
            this.Observacion = observacion;
            this.Fkidtipoevidencia = fkidtipoevidencia;
            this.Fkidarticulo = fkidarticulo;
            this.Fkidliteral = fkidliteral;
            this.Fkidnumeral = fkidnumeral;
            this.Fkidsubnumeral = fkidsubnumeral;
            this.Fkidsub_subnumeral = fkidsub_subnumeral;
        }


        public int id { get => Id; set => Id = value; }
        public DateTime Fecharegistro { get => fecharegistro; set => fecharegistro = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public string descripcion { get => Descripcion; set => Descripcion = value; }
        public string NomArchivo { get => nomArchivo; set => nomArchivo = value; }
        public string LinkArchivo { get => linkArchivo; set => linkArchivo = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Fkidtipoevidencia { get => fkidtipoevidencia; set => fkidtipoevidencia = value; }
        public string Fkidarticulo { get => fkidarticulo; set => fkidarticulo = value; }
        public string Fkidliteral { get => fkidliteral; set => fkidliteral = value; }
        public string Fkidnumeral { get => fkidnumeral; set => fkidnumeral = value; }
        public string Fkidsubnumeral { get => fkidsubnumeral; set => fkidsubnumeral = value; }
        public string Fkidsub_subnumeral { get => fkidsub_subnumeral; set => fkidsub_subnumeral = value; }

        public Evidencia()
        {
            this.Id = 0;
            this.Fecharegistro = DateTime.Now;
            this.FechaCreacion = DateTime.Now;
            this.Descripcion = "";
            this.NomArchivo = "";
            this.LinkArchivo = "";
            this.Observacion = "";
            this.Fkidtipoevidencia = 0;
            this.Fkidarticulo = "";
            this.Fkidliteral = "";
            this.Fkidnumeral = "";
            this.Fkidsubnumeral = "";
            this.Fkidsub_subnumeral = "";
        }
    }
}