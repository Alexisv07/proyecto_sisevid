using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class FuenteIndicador
    {
        int fkidfuente;
        int fkidindicador;

        public FuenteIndicador(int fkidfuente, int fkidindicador)
        {
            this.fkidfuente = fkidfuente;
            this.fkidindicador = fkidindicador;
        }

        public int Fkidfuente { get => fkidfuente; set => fkidfuente = value; }
        public int Fkidindicador { get => fkidindicador; set => fkidindicador = value; }

        public FuenteIndicador()
        {
            this.fkidfuente=0;
            this.fkidindicador=0;
        }
    }
}