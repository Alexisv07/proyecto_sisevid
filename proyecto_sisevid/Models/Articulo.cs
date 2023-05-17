using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Articulo
    {
        string id;
        string nombre;
        string descripcion;
        string fkidtitulo;
        string fkidcapitulo;
        string fkidseccion;

        public Articulo(string id, string nombre, string descripcion, string fkidtitulo, string fkidcapitulo, string fkidseccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fkidtitulo = fkidtitulo;
            this.fkidcapitulo = fkidcapitulo;
            this.fkidseccion = fkidseccion;
        }

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Fkidtitulo { get => fkidtitulo; set => fkidtitulo = value; }
        public string Fkidcapitulo { get => fkidcapitulo; set => fkidcapitulo = value; }
        public string Fkidseccion { get => fkidseccion; set => fkidseccion = value; }

        public Articulo()
        {
            this.id = " ";
            this.nombre = " ";
            this.descripcion = " ";
            this.fkidtitulo = " ";
            this.fkidcapitulo = " ";
            this.fkidseccion = " ";
        }
    }
}