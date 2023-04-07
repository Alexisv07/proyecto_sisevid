using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class UnidadDeMedicion
    {
        private string id;
        private string descripcion;

        public UnidadDeMedicion(string id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public string Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public UnidadDeMedicion()
        {
            this.id = "";
            this.Descripcion = "";
        }
    }
}