using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class ResponsableIndicador
    {
        string Fkidresponsable;
        int Fkidindicador;
        DateTime Fechaasignacion;
        string Fknomusuario;

        public string fkidresponsable { get => Fkidresponsable; set => Fkidresponsable = value; }
        public int fkidindicador { get => Fkidindicador; set => Fkidindicador = value; }
        public DateTime fechaasignacion { get => Fechaasignacion; set => Fechaasignacion = value; }
        public string fknomusuario { get => Fknomusuario; set => Fknomusuario = value; }

        public ResponsableIndicador(string fkidresponsable, int fkidindicador, DateTime fechaasignacion, string fknomusuario)
        {
            this.Fkidresponsable = fkidresponsable;
            this.Fkidindicador = fkidindicador;
            this.Fechaasignacion = fechaasignacion;
            this.Fknomusuario = fknomusuario;
        }

        public ResponsableIndicador()
        {
            this.Fkidresponsable = "";
            this.Fkidindicador = 0;
            this.Fechaasignacion = fechaasignacion;
            this.Fknomusuario = fknomusuario;
        }
    }
}