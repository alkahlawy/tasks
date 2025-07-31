using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8_oop3.Part02_Q03.Interfaces
{
    internal interface INotificationService
    {
        void SendNotification(string recipient, string message);
    }
}
