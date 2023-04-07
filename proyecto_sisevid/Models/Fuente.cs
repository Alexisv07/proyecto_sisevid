using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Fuente
    {
        private string id;
        private string nom;

        public string Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public Fuente(string id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public Fuente()
        {
            this.Id = id;
            this.Nom = nom;
        } 


    }
}