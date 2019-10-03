using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace ServidorDLL
{
    class ServidorTcp
    {
        public ServidorTcp()
        {
            try
            {
                TcpListener myList = new TcpListener(IPAddress.Any, 8010);
                myList.Start();
                //bool seguir = true;
                //while (seguir)
                //{


                Console.WriteLine("Servidor en el puerto 8010...");
                Console.WriteLine("Esperando...");

                Socket s = myList.AcceptSocket();
                Console.WriteLine("Conexion aceptada de " + s.RemoteEndPoint);

                byte[] b = new byte[100];
                int k = s.Receive(b);
                Console.WriteLine("Recibido...");

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(b[i]));

                TcpClient tcpclnt = new TcpClient();
                //Console.WriteLine("Conectando...");

                tcpclnt.Connect(((IPEndPoint)s.RemoteEndPoint).Address.ToString(), ((IPEndPoint)s.RemoteEndPoint).Port);

                string mensaje = Console.ReadLine();
                Stream st = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                //s.Send(asen.GetBytes("Se ha recibido el mensaje: "));
                byte[] ba = asen.GetBytes(mensaje);
                Console.WriteLine("Enviando respuesta...");
                st.Write(ba, 0, ba.Length);
                Console.WriteLine("\nMandamos la respuesta");
                s.Close();





                Console.Read();
                myList.Stop();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.StackTrace);
                Console.Read();
            }
        }


    }
}