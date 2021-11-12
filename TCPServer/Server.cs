using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Project1
{
    class Server
    {
        private IPAddress IP;
        private int port;
        private List<Socket> ClientSockets;
        private Socket serverSocket;
        private string db;
        private int buffer;
        private byte[] request;


        public Server(IPAddress _ip, int _port, string _db, int _buffer)
        {
            IP = _ip;
            port = _port;
            db = _db;
            buffer = _buffer;
            request = new byte[buffer];
            ClientSockets = new List<Socket>();
        }

        public void Start()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IP, port));
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallBack, null);
        }

        private void AcceptCallBack(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            ClientSockets.Add(socket);
            socket.BeginReceive(request, 0, buffer, SocketFlags.None, ReceiveCallBack, socket);
            serverSocket.BeginAccept(AcceptCallBack, null);
        }

        private void ReceiveCallBack(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            byte[] resbuffer = new byte[received];
            Array.Copy(request, resbuffer, received);
            //socket.SendTo(resbuffer,)
            string req = Encoding.UTF8.GetString(resbuffer);

            if (req == "test") MessageBox.Show("Server received test request");

        }

    }
}
