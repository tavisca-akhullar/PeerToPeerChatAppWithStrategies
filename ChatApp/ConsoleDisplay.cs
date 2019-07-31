using System;

namespace ChatApp
{
    public class ConsoleDisplay : IDisplay
    {
        public string message { get; set; }

        public void DisplayMessage(String message)
        {
            Console.WriteLine(message);
        }
    }
}
       


