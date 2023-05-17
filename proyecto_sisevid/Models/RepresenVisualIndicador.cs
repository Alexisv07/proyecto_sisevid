using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class RepresenVisualIndicador
    {
        int Fkidindicador;
        int Fkidrepresenvisual;

        public int fkidindicador { get => Fkidindicador; set => Fkidindicador = value; }
        public int fkidrepresenvisual { get => Fkidrepresenvisual; set => Fkidrepresenvisual = value; }

        public RepresenVisualIndicador(int fkidindicador, int fkidrepresenvisual)
        {
            this.Fkidindicador = fkidindicador;
            this.Fkidrepresenvisual = fkidrepresenvisual;
        }

        public RepresenVisualIndicador()
        {
            this.Fkidindicador = 0;
            this.Fkidrepresenvisual = 0;
        }
    }
}