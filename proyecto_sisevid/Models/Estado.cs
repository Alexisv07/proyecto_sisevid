using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Estado
    {
        string id;
        string nom;

        public string Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        

        public Estado(string id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }
        public Estado()
        {
            this.Id = "";
            this.Nom = "";
        }
    }
}
