using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMedidor.DTO
{
    public class Medidor
    {
        private int num_medidor;

        public int Num_medidor { get => num_medidor; set => num_medidor = value; }

        public Medidor(int medidor)
        {
            this.num_medidor = medidor;
        }


    }
}
