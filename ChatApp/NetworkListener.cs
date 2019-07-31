using System;
using System.Net.Sockets;

namespace ChatApp
{
    public class NetworkListener : INetworkOperator
    {
        public User User { get; set; }
        private Network _network { get; set; }
        private Socket _listenerSocket;
        private Socket _clientSocket;
        private Conversation _conversation;
        private IDisplay _display;
        public NetworkListener(User user, Network network, Conversation conversation )
        {
             User = user;
            _network = network;
            _conversation = conversation;
            _display = new ConsoleDisplay();
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
                    _display.DisplayMessage("Waiting connection ... ");
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
                _display.DisplayMessage(e.ToString());
                
            }
        }
    }
}