using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    public class CustomerInfo
    {
        public Guid UserId { get; private set; }
        public string Username { get; private set; } 
        public string Email { get; private set; }

        public CustomerInfo(Guid userId, string username, string email)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty");
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty");

            UserId = userId;
            Username = username;
            Email = email;
        }

        // Construtor parameterless (MongoDB)
        public CustomerInfo() { }
    }
}
