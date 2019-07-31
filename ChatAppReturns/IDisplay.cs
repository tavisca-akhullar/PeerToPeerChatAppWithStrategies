using System;

namespace ChatAppReturns
{
    interface IDisplay
    {
        string message { get; set; }
        void DisplayMessage(String message);
    }
}


