using System;

namespace ChatApp
{
    interface IDisplay
    {
        string message { get; set; }
        void DisplayMessage(String message);
    }
}
       


