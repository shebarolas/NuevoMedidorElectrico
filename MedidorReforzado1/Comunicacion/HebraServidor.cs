using ModelsMedidor.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using ServidorSocketUtils;
using System.Net.Sockets;

namespace MedidorReforzado1.Comunicacion
{
    public class HebraServidor
    {

        private ILecturaDAL lecDAL = LecturaDAL.GetInstancia();

        public void Ejecutar()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("ServidoR Iniciado en el puerto " + puerto);

            ServerSocket server = new ServerSocket(puerto);

            if (server.Iniciar())
            {
                Console.WriteLine("Servidor Iniciado");
                while (true)
                {
                    Console.WriteLine("Esperando a Cliente.......");
                    Socket cliente_socket = server.ObtenerCliente();
                    ClienteCom cliente = new ClienteCom(cliente_socket);
                    Console.WriteLine("Cliente Conectado");

                    HebraCliente hebra_cliente = new HebraCliente(cliente);
                    Thread thread = new Thread(new ThreadStart(hebra_cliente.Ejecutar));
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
            else
            {
                Console.WriteLine("Error eñ puerto " + puerto + " esta ocupado");
            }
        }

    }
}
