using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class TipoIndicador
    {
        private string id;
        private string nom;
        public string Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public TipoIndicador(string id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public TipoIndicador()
        {
            this.Id = "";
            this.Nom = "";
        }
    }
}