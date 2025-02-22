﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMinder.Domain.Common;

namespace CashMinder.Domain.Entities
{
    public class User : EntityBase
    {
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        public User(string username, string firstName, string lastName, string email, string passwordHash)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
        }
        public User()
        {

        }
    }
}
