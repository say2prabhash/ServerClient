using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("prabhash");
            IPAddress ipAddress = IPAddress.Parse("172.16.14.141");
            TcpClient tcpclnt = new TcpClient();
            tcpclnt.Connect(ipAddress, 8080);
            NetworkStream stream = tcpclnt.GetStream();
            string output = JsonConvert.SerializeObject(person);
            byte[] b = ASCIIEncoding.ASCII.GetBytes(output);
            stream.Write(b, 0, b.Length);
            stream.Close();
        }
    }
}
