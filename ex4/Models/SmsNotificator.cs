namespace Interfaces.ex4.Models
{
    public class SmsNotificator : INotificator
    {
        public string Canal => "SMS";
        private string destinatar = "";

        public string Destinatar
        {
            get { return destinatar; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 10 || !value.StartsWith("07") || !value.All(char.IsDigit))
                {
                    throw new ArgumentException("Invalid phone number");

                }

                destinatar = value;
            }
        }

        public void Trimite(string destinatar, string mesaj)
        {
            Destinatar = destinatar;
            Console.WriteLine($"[SMS catre {Destinatar}] {mesaj}");
        }
    }
}