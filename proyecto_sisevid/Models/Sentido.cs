using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Sentido
    {
        string id;
        string nom;

        public Sentido(string id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public string Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public Sentido()
        {
            this.id = "";
            this.nom = "";
        }
    }
}