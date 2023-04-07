using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class RepresenVisual
    {
        private string id;
        private string name;

        public RepresenVisual(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public RepresenVisual()
        {
            this.id = "";
            this.Name = "";
        }
    }
}