using System;
using System.Net;
using System.Net.Sockets;

namespace ChatApp
{
    public class NetworkClient : INetworkOperator
    {
        public User User { get; set; }
        private Network _network;
        private Socket _listenerSocket;
        private IPEndPoint _localEndPoint;
        private Conversation _conversation;
        private NetworkListener _listener;
        private IDisplay _display;
        public NetworkClient(User networkClient, Network network, Conversation conversation)
        {
             User = networkClient;
            _network = network;
            _conversation = conversation;
            _display = new ConsoleDisplay();
        }
        public void Connect()
        {
            _listenerSocket = _network.GetSocket(User.IpAddress);
            try
            {
               
                    _network.Connect(_listenerSocket);
                    // Console.WriteLine(" connected to -> {0} ",
                    while (true)
                    {
                        string input;
                        input = Console.ReadLine();
                        _conversation.SendMessage(_listenerSocket, input);
                        _conversation.ReceiveMessage(_listenerSocket);
                       

                    }
                 //   _connection.CloseConnection(_listenerSocket);
                    _listener.StartListening();
                
                }
            catch
            {
                _display.DisplayMessage("Unbale to connect");
            }
        }

    }
}
       


