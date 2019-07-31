namespace ChatAppReturns
{
    public class ChatApplication
    {
        private User user;
        private Network _network;
        private Conversation _conversation;
        private NetworkClient _networkClient;

        public ChatApplication(User user)
        {
            _network = new Network();
            _conversation = new Conversation();
            _networkClient = new NetworkClient(user,_network,_conversation);
        }

        public void startChat()
        {
            _networkClient.Connect();
        }


    }
}


