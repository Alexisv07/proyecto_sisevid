using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class EvidenciaEstado
    {
        int id;
        int fkidevidencia;
        string fkidestado;
        string fkidusuario;
        DateTime fehca;

        public EvidenciaEstado(int id, int fkidevidencia, string fkidestado, string fkidusuario, DateTime fehca)
        {
            this.id = id;
            this.fkidevidencia = fkidevidencia;
            this.fkidestado = fkidestado;
            this.fkidusuario = fkidusuario;
            this.fehca = fehca;
        }

        public int Id { get => id; set => id = value; }
        public int Fkidevidencia { get => fkidevidencia; set => fkidevidencia = value; }
        public string Fkidestado { get => fkidestado; set => fkidestado = value; }
        public string Fkidusuario { get => fkidusuario; set => fkidusuario = value; }
        public DateTime Fehca { get => fehca; set => fehca = value; }

        public EvidenciaEstado()
        {
            this.id = 0;
            this.fkidevidencia = 0;
            this.fkidestado = "";
            this.fkidusuario = "";
            this.fehca = DateTime.Now;
        }
    }
}