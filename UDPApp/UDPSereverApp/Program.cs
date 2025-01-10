using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPSereverApp
{
    internal class Program
    {
        const int listenPort = 11000;
        const string host = "127.0.0.1";
        private static void StartListtener()
        {
            string message;
            UdpClient listener = new UdpClient(listenPort);
            IPAddress adderss = IPAddress.Parse(host);
            IPEndPoint remoteEndpoint = new IPEndPoint(adderss,listenPort);
            Console.Title = "UDP Server";
            Console.WriteLine(new string('*', 40));
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref remoteEndpoint);
                    message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    Console.WriteLine($"Received broadcasr from {remoteEndpoint} : {message}");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                listener.Close();
            }
        }
        static void Main(string[] args)
        {
            Thread th = new Thread(StartListtener);
            th.Start();
        }
    }
}
