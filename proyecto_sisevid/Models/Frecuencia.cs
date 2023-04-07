using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Frecuencia
    {

        string id;
        string descripcion;

        public Frecuencia(string id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public string Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public Frecuencia()
        {
            this.id = "";
            this.descripcion = "";
        }
    }

}