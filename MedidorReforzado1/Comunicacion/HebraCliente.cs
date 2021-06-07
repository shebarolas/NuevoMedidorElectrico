using ModelsMedidor.DAL;
using ModelsMedidor.DTO;
using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorReforzado1.Comunicacion
{
    class HebraCliente
    {
        private ClienteCom clienteCom;

        private ILecturaDAL DALLectura = LecturaDAL.GetInstancia();
        private IMedidorDAL DALMedidor = MedidorDAL.GetInstancia();

        public HebraCliente(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }

        public void Ejecutar()
        {
            clienteCom.Escribir("Hola Cliente, Porfavor Ingrese los datos del medidor para lectura");
            string texto = clienteCom.Leer();
            string[] array = texto.Trim().Split('|');
            string[] fechapala = array[1].Split('-');
            string fechafin=  "";
            for (int i =0; i< fechapala.Length ;i++)
            {
                if (i < fechapala.Length - 4)
                {
                    fechafin = fechapala[i] + "/";
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

                if (i == fechapala.Length - 1)
                {
                    fechafin = ":" + fechapala[i];
                }
            }
            array[2] = array[2].Replace(".", ",");
            int medidor = Int32.Parse(array[0]);
            if (Val_Medidor(medidor))
            {
                DateTime fechas = DateTime.Parse(fechafin);
                double consumo = double.Parse(array[2]);
                fechas.ToString("yyyy-MM-dd-HH-mm-ss");
                Lectura lec = new Lectura();
                lec.Num_consumo = consumo;
                lec.Num_medidor = medidor;
                lec.Fecha = fechas;
                clienteCom.Escribir("OK");
                clienteCom.Desconectar();
            }
            else
            {
                clienteCom.Escribir("ERROR");
                clienteCom.Desconectar();
            }
        }


        public bool Val_Medidor(int medidor)
        {
            List<Medidor> medidorr = new List<Medidor>();
            medidorr = DALMedidor.ObtenerMedidores();

            if (medidorr.Exists(x => x.Num_medidor == medidor))
            {
                return true;
            }
            else
            {
                return false;
            }

            

        }

    }
}
