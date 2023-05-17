using System;

namespace proyecto_sisevid.Models
{
    public class ResultadoIndicador
    {
        int Id;
        double Resultado;
        DateTime fechaCalculo;
        int Fkidindicador;

        public int id { get => Id; set => Id = value; }
        public double resultado { get => Resultado; set => Resultado = value; }
        public DateTime FechaCalculo { get => fechaCalculo; set => fechaCalculo = value; }
        public int fkidindicador { get => Fkidindicador; set => Fkidindicador = value; }

        public ResultadoIndicador(int id, double resultado, DateTime fechaCalculo, int fkidindicador)
        {
            this.Id = id;
            this.Resultado = resultado;
            this.fechaCalculo = fechaCalculo;
            this.Fkidindicador = fkidindicador;
        }
        public ResultadoIndicador(int id)
        {
            this.Id = id;
            // this.Resultado = 0;
        }

        public ResultadoIndicador()
        {
            this.Id = 0;
            this.Resultado = 0;
            this.fechaCalculo = DateTime.Now;
            this.Fkidindicador = 0;
        }
    }
}