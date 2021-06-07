using ModelsMedidor.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMedidor.DAL
{
    public class LecturaDAL : ILecturaDAL
    {
        private LecturaDAL()
        {

        }

        private static LecturaDAL instancia;

        public static ILecturaDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new LecturaDAL();
            }
            return instancia;
        }

        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/lecturas.txt";

        public void IngresarLectura(Lectura lec)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(lec.Num_medidor + "|" + lec.Fecha.ToString("yyyy-MM-dd-HH-mm-ss")+ "|" + lec.Num_consumo);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public List<Lectura> ObtenerLecturas()
        {
            List<Lectura> lectura_lista = new List<Lectura>();

            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto = "";
                    do
                    {
                        texto = reader.ReadLine();

                        if (texto != null)
                        {
                            string[] arry = texto.Trim().Split('|');
                            char delimitador = '-';
                            string[] fechapala = arry[1].Split(delimitador);
                            string fechafin = "";
                            for (int i =0;i<fechapala.Length ;i++)
                            {
                                if (i < fechapala.Length - 4)
                                {
                                    fechafin = fechafin[i] + "/";
                                }
                                if (i == fechapala.Length - 4)
                                {
                                    fechafin = fechapala[i];
                                }

                                if (i == fechapala.Length - 3)
                                {
                                    fechafin = " " + fechapala[i];
                                }

                                if (i == fechapala.Length - 2)
                                {
                                    fechafin = ":" + fechapala[i];
                                   
                                }

                                if(i == fechapala.Length - 1)
                                {
                                    fechafin = ":" + fechapala[i];
                                }
                            }

                            int num_medidor = int.Parse(arry[0]);
                            DateTime fecha = DateTime.Parse(fechafin);
                            double val_consumo = double.Parse(arry[2]);
                            fecha.ToString("yyyy-MM-dd-HH-mm-ss");

                            Lectura lec = new Lectura();
                            lec.Num_medidor = num_medidor;
                            lec.Fecha = fecha;
                            lec.Num_consumo = val_consumo;

                            lectura_lista.Add(lec);
                        }
                    } while (texto != null);
                }
            }
            catch (Exception ex)
            {
                lectura_lista = null;
            }

            return lectura_lista;
        }

    }
}
