using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMedidor.DTO
{
    public class Lectura
    {

        private int num_medidor;
        private DateTime fecha;
        private double num_consumo;

        public int Num_medidor { get => num_medidor; set => num_medidor = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double Num_consumo { get => num_consumo; set => num_consumo = value; }
    }
}
