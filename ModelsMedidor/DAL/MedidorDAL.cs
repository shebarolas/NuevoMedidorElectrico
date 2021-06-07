using ModelsMedidor.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMedidor.DAL
{
    public class MedidorDAL : IMedidorDAL
    {
        private static List<Medidor> medidor = new List<Medidor>();

        
        private MedidorDAL()
        {
            llenarMedidores();
        }

        private static MedidorDAL instancia;

        public static IMedidorDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new MedidorDAL();
            }
            return instancia;
        }

        public void llenarMedidores()
        {
            Medidor medi;
            for (int i=1;i<30 ;i++)
            {
                medi = new Medidor(i);
                medidor.Add(medi);
            }
        }

        public List<Medidor> ObtenerMedidores()
        {
            return medidor;
        }
    }
}
