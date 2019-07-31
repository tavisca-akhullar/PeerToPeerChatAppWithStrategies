using System;
using System.Net.Sockets;

namespace ChatAppReturns
{
    public class NetworkListener : INetworkOperator
    {
        public User User { get; set; }
        private Network _network { get; set; }
        private Socket _listenerSocket;
        private Socket _clientSocket;
        private Conversation _conversation;
        public NetworkListener(User user, Network network, Conversation conversation)
        {
            User = user;
            _network = network;
            _conversation = conversation;
        }

        public void StartListening()
        {
            _listenerSocket = _network.GetSocket(User.IpAddress);
            try
            {
                _network.BindSocket(_listenerSocket);
                _listenerSocket.Listen(10);
                while (true)
                {
                    Console.WriteLine("Waiting connection ... ");
                    Socket clientSocket = _listenerSocket.Accept();
                    while (true)
                    {
                        _conversation.ReceiveMessage(_clientSocket);
                        string input;
                        input = Console.ReadLine();
                        _conversation.SendMessage(_clientSocket, input);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
        }
    }
}


