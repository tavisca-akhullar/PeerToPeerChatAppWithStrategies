using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppReturns
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User(Console.ReadLine());
            ChatApplication chatApplication = new ChatApplication(user);
            chatApplication.startChat();
        }
    }
}
