using System;

namespace Apheus.Identity.Models
{
    public class ApheusUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }
    }
}