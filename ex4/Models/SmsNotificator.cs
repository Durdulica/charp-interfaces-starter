namespace Interfaces.ex4.Models
{
    public class SmsNotificator : INotificator
    {
        public string Canal => "SMS";

        public void Trimite(string destinatar, string mesaj)
        {
            ValideazaDestinatar(destinatar);
            Console.WriteLine($"[SMS catre {destinatar}] {mesaj}");
        }

        private static void ValideazaDestinatar(string destinatar) 
        {
            if (string.IsNullOrEmpty(destinatar) || destinatar.Length != 10 || !destinatar.StartsWith("07"))
            {
                throw new ArgumentException("Invalid phone number");
            }

            for (int i = 0; i < destinatar.Length; i++)
            {
                if (!Char.IsDigit(destinatar[i]))
                {
                    throw new ArgumentException("Invalid phone number");
                }
            }
        }
    }
}