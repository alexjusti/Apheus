namespace Apheus.Identity.Models
{
    public class PasswordHashingOptions
    {
        public int SaltSize { get; set; }

        public int Iterations { get; set; }

        public int KeySize { get; set; }
    }
}