using System;
using System.Net;
using System.Net.Sockets;

namespace ChatAppReturns
{
    public class Network
    {

        private IPEndPoint localEndPoint { get; }

        public Network()
        {

        }
        public Socket GetSocket(String address)
        {
            IPAddress ipAddr = IPAddress.Parse(address);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
            return new Socket(ipAddr.AddressFamily,
                 SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(Socket sender)
        {
            sender.Connect(localEndPoint);
        }

        public void BindSocket(Socket listenerSocket)
        {
            listenerSocket.Bind(localEndPoint);
        }

    }
}


