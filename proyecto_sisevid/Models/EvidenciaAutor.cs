using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class EvidenciaAutor
    {
        int id;
        int fkidevidencia;
        int fkiautor;

        public EvidenciaAutor(int id, int fkidevidencia, int fkiautor)
        {
            this.id = id;
            this.fkidevidencia = fkidevidencia;
            this.fkiautor = fkiautor;
        }

        public int Id { get => id; set => id = value; }
        public int Fkidevidencia { get => fkidevidencia; set => fkidevidencia = value; }
        public int Fkiautor { get => fkiautor; set => fkiautor = value; }

        public EvidenciaAutor()
        {
            this.id = 0;
            this.fkidevidencia = 0;
            this.fkiautor = 0;
        }
    }
}