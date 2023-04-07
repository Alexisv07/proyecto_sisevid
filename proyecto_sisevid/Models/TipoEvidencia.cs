using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class TipoEvidencia
    {
        private string id;
        private string name;

        public TipoEvidencia(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public TipoEvidencia()
        {
            this.id = id;
            this.Name = name;
        }
    }
}