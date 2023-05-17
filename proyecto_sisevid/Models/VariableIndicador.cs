using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class VariableIndicador
    {
        int Id;
        int Fkidvariable;
        int Fkidindicador;
        double Dato;
        DateTime fechadatos;
        string Fknomusuario;

        public int id { get => Id; set => Id = value; }
        public int fkidvariable { get => Fkidvariable; set => Fkidvariable = value; }
        public int fkidindicador { get => Fkidindicador; set => Fkidindicador = value; }
        public double dato { get => Dato; set => Dato = value; }
        public DateTime Fechadatos { get => fechadatos; set => fechadatos = value; }
        public string fknomusuario { get => Fknomusuario; set => Fknomusuario = value; }

        public VariableIndicador(int id, int fkidvariable, int fkidindicador, double dato, DateTime fechadatos, string fknomusuario)
        {
            this.Id = id;
            this.Fkidvariable = fkidvariable;
            this.Fkidindicador = fkidindicador;
            this.Dato = dato;
            this.fechadatos = fechadatos;
            this.Fknomusuario = fknomusuario;
        }

        public VariableIndicador(int id)
        {
            this.Id = id;

        }

        public VariableIndicador()
        {
            this.Id = 0;
            this.Fkidvariable = 0;
            this.Fkidindicador = 0;
            this.Dato = 0;
            this.fechadatos = DateTime.Now;
            this.fknomusuario = "";
        }
    }
}