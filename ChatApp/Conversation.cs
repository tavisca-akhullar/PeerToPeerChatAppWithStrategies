using System;
using System.Text;
using System.Net.Sockets;

namespace ChatApp
{
    public class Conversation
    {
        private IDisplay _display;

        public Conversation()
        {
            _display = new ConsoleDisplay();
        }
        public void SendMessage(Socket socket, String message)
        {
            byte[] messageSent = Encoding.ASCII.GetBytes(message);
            int byteSent = socket.Send(messageSent);
        }

        public void ReceiveMessage(Socket socket)
        {
            byte[] messageReceived = new byte[1024];
            int byteReceived = socket.Receive(messageReceived);
            string data = Encoding.ASCII.GetString(messageReceived, 0, byteReceived);
             _display.DisplayReceivedMessage(data);
            if (data.IndexOf("bye") > -1)
            {
                byte[] messageSent = Encoding.ASCII.GetBytes("bye");
                socket.Send(messageSent);
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
       


