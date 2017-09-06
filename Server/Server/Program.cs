using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        const int PortNum = 8080;
        const string ServerIP = "172.16.14.122";
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse(ServerIP);
            TcpListener listener = new TcpListener(ip, PortNum);
            Console.WriteLine("Listening...");
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            var person =Deserialize<Person>(dataReceived);
            Console.WriteLine("Received : " + person.Name);
            Console.Read();
        }
        public static T Deserialize<T>(string obj) where T : Person
        {
            return JsonConvert.DeserializeObject<T>(obj);
        }
    }
}
