using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Variable
    {
        int Id;
        string Nombre;
        DateTime fechaCreacion;
        string Fkimailusuario;

        public int id { get => Id; set => Id = value; }
        public string nombre { get => Nombre; set => Nombre = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public string fkimailusuario { get => Fkimailusuario; set => Fkimailusuario = value; }

        public Variable(int id, string nombre, DateTime fechaCreacion, string fkimailusuario)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.fechaCreacion = fechaCreacion;
            this.Fkimailusuario = fkimailusuario;
        }
        public Variable(int id)
        {
            this.Id = id;

        }

        public Variable()
        {
            this.Id = 0;
            this.Nombre = "";
            this.fechaCreacion = DateTime.Now;
            this.Fkimailusuario = "";
        }
    }
}