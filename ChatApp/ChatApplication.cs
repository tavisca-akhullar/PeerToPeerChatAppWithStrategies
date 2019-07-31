namespace ChatApp
{
    public class ChatApplication
    {
        private User user;
        private Network _network;
        private Conversation _conversation;
        private NetworkListener _networkListener;

        public ChatApplication(User user )
        {
            _network = new Network();
            _conversation = new Conversation();
            _networkListener = new NetworkListener(user, _network,_conversation);
        }

        public void startChat()
        {
            _networkListener.StartListening();
        }


    }
    }
       


