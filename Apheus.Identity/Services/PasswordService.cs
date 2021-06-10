using System;
using System.Linq;
using System.Security.Cryptography;
using Apheus.Identity.Models;

namespace Apheus.Identity.Services
{
    public class PasswordService
    {
        private readonly PasswordHashingOptions _options;

        public PasswordService(PasswordHashingOptions options)
        {
            _options = options;
        }

        public string HashPassword(string password)
        {
            //Generate a random SALT
            var salt = new byte[_options.SaltSize];
            new Random().NextBytes(salt);

            //Derive the key using the PBKDF2 algorithm
            var key = new Rfc2898DeriveBytes(password, salt, _options.Iterations, HashAlgorithmName.SHA512)
                .GetBytes(_options.KeySize);

            return $"{Convert.ToBase64String(salt)}.{_options.Iterations}.{Convert.ToBase64String(key)}";
        }

        public bool CheckPassword(string passwordAttempt, string storedHash)
        {
            //Split the stored hash and parse the contained information
            var parts = storedHash.Split(".");

            if (parts.Length != 3)
                return false;

            var salt = Convert.FromBase64String(parts[0]);
            var iterations = int.Parse(parts[1]);
            var storedKey = Convert.FromBase64String(parts[2]);

            var attemptKey = new Rfc2898DeriveBytes(passwordAttempt, salt, iterations, HashAlgorithmName.SHA512)
                .GetBytes(storedKey.Length);

            return attemptKey.SequenceEqual(storedKey);
        }
    }
}