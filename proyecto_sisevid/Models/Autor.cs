using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Autor
    {
        private string id;
        private string ident;
        private string nom;
        
        public string Id { get => id; set => id = value; }
        public string Ident { get => ident; set => ident = value; }
        public string Nom { get => nom; set => nom = value; }

        public Autor(string id, string ident, string nom)
        {
            this.id = id;
            this.ident = ident;
            this.nom = nom;
            
        }
        public Autor()
        {
            this.id = "";
            this.ident = "";
            this.nom = "";
        }

    }

}