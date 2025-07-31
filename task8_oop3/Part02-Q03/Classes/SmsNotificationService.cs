using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task8_oop3.Part02_Q03.Interfaces;

namespace task8_oop3.Part02_Q03.Classes
{
    internal class SmsNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"[SMS] To: {recipient}\nMessage: {message}\n");
        }
    }
}
