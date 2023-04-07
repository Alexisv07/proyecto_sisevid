using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Responsable
    {
        private string cc;
        private string name;
        private string email;

        public Responsable(string cc, string name, string email)
        {
            this.cc = cc;
            this.name = name;
            this.email = email;
        }

        public string Cc { get => cc; set => cc = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }

        public Responsable()
        {
            this.cc = "";
            this.Name = "";
            this.email = "";
        }
    }
}