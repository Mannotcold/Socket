using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TCPClient
{
    public class ClientTCP
    {

        // t dang thu tach ma tach quai ko dc á
        private IPAddress IP;
        private Socket client;

        void Connect()
        {
            IPEndPoint IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            client.Connect(IP);
            byte[] buf = Encoding.UTF8.GetBytes("Hello");
            client.Send(buf);

        }
    }
}
