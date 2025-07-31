using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task8_oop3.Part02_Q02.Interfaces;

namespace task8_oop3.Part02_Q02.Classes
{
    internal class BasicAuthenticationService : IAuthenticationService
    {
        private Dictionary<string, (string Password, string Role)> users = new Dictionary<string, (string, string)>
        {
            { "admin", ("admin123", "Administrator") },
            { "mohamed", ("kahlawy123", "User") },
            { "salma", ("salmapass", "Manager") }
        };
        public bool AuthenticateUser(string username, string password)
        {
            if (users.ContainsKey(username) && users[username].Password == password)
            {
                return true;
            }
            return false;
        }

        public bool AuthorizeUser(string username, string role)
        {
            if (users.ContainsKey(username) && users[username].Role == role)
            {
                return true;
            }
            return false;
        }
    }
}
