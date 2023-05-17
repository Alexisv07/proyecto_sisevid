using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Indicador
    {
        int id;
        string codigo;
        string nombre;
        string objetivo;
        string alcance;
        string formula;
        int fkidtipoindicador;
        int fkidunidadmedicion;
        string meta;
        int fkidsentido;
        int fkidfrecuencia;

        public Indicador(int id, string codigo, string nombre, string objetivo, string alcance, 
            string formula, int fkidtipoindicador, int fkidunidadmedicion, string meta, int fkidsentido, int fkidfrecuencia)
        {
            this.id = id;
            this.codigo = codigo;
            this.nombre = nombre;
            this.objetivo = objetivo;
            this.alcance = alcance;
            this.formula = formula;
            this.fkidtipoindicador = fkidtipoindicador;
            this.fkidunidadmedicion = fkidunidadmedicion;
            this.meta = meta;
            this.fkidsentido = fkidsentido;
            this.fkidfrecuencia = fkidfrecuencia;
        }

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Objetivo { get => objetivo; set => objetivo = value; }
        public string Alcance { get => alcance; set => alcance = value; }
        public string Formula { get => formula; set => formula = value; }
        public int Fkidtipoindicador { get => fkidtipoindicador; set => fkidtipoindicador = value; }
        public int Fkidunidadmedicion { get => fkidunidadmedicion; set => fkidunidadmedicion = value; }
        public string Meta { get => meta; set => meta = value; }
        public int Fkidsentido { get => fkidsentido; set => fkidsentido = value; }
        public int Fkidfrecuencia { get => fkidfrecuencia; set => fkidfrecuencia = value; }

        public Indicador()
        {
            this.id = 0;
            this.codigo = "";
            this.nombre = "";
            this.objetivo = "";
            this.alcance = "";
            this.formula = "";
            this.fkidtipoindicador = 0;
            this.fkidunidadmedicion = 0;
            this.meta = "";
            this.fkidsentido = 0;
            this.fkidfrecuencia = 0;
        }
    }
}