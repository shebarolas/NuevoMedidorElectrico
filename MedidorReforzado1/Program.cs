using MedidorReforzado1.Comunicacion;
using ModelsMedidor.DAL;
using ModelsMedidor.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedidorReforzado1
{
    public class Program
    {

        private static ILecturaDAL DALectura = LecturaDAL.GetInstancia();

        static void Main(string[] args)
        {
            HebraServidor servidor = new HebraServidor();
            Thread thread = new Thread(new ThreadStart(servidor.Ejecutar));
            thread.IsBackground = true;
            thread.Start();
            while (Menu()) ;
        }

        static bool Menu()
        {
            bool opc = true;

            Console.WriteLine("Bienvenido Servidor");
            Console.WriteLine("1. Ingresar Datos o Lecturas");
            Console.WriteLine("2. Mostrar Datos");
            Console.WriteLine("3. Salir");
            switch (Console.ReadLine().Trim())
            {

                case "1":
                    IngresoLec();
                    break;
                case "2":
                    Mostrar();
                    break;
                case "3":
                    opc = false;
                    break;
                default:
                    Console.WriteLine("Datos Nuevamente");
                    break;
            }

            return opc;
        }

        static void IngresoLec()
        {
            string medidor;
            string fecha;
            string consumo;
            bool ayuda = true;
            do
            {
                Console.WriteLine("Ingresar Medidor");
                medidor = Console.ReadLine().Trim();

                if (medidor != null)
                {
                    ayuda = false;
                    break;
                }

            } while (ayuda);

            ayuda = true;

            do
            {
                Console.WriteLine("Ingresar Fecha");
                fecha = Console.ReadLine().Trim();
                if (fecha != null)
                {
                    ayuda = false;
                    break;
                }
            } while (ayuda);
            ayuda = true;
            do
            {
                Console.WriteLine("Ingresar Consumo");
                consumo = Console.ReadLine().Trim();
                if (consumo != null)
                {
                    ayuda = false;
                    break;
                }


            } while (ayuda);

            int medidorr = Int32.Parse(medidor);
            DateTime dateTime = DateTime.Parse(fecha);
            double valor_consumo = Double.Parse(consumo);

            Lectura lec = new Lectura();

            lec.Fecha = dateTime;
            lec.Num_consumo = valor_consumo;
            lec.Num_medidor = medidorr;

            lock(DALectura){
                DALectura.IngresarLectura(lec);
            }


        }

        static void Mostrar()
        {
            List<Lectura> lista_lec = DALectura.ObtenerLecturas();
           
            for (int i = 0; i < lista_lec.Count; i++)
            {
                Lectura lec = lista_lec[i];

                Console.WriteLine("Numero medidor: " + lec.Num_medidor + "Fecha" + lec.Fecha + "Consumo" + lec.Num_consumo);
            }
        }

    }

   
}
