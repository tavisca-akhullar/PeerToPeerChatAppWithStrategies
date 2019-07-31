using System;

namespace ChatAppReturns
{
    public class User
    {
        public String Name { get; }
        public String IpAddress { get; }


        public User(String userIp)
        {
            String[] userDetails = userIp.Split('@');
            Name = userDetails[0];
            IpAddress = userDetails[1];
        }
    }
}


