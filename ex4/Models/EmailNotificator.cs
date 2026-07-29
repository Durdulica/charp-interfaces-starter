namespace Interfaces.ex4.Models
{
    public class EmailNotificator : INotificator
    {
        public string Canal => "EMAIL";

        public void Trimite(string destinatar, string mesaj)
        {
            ValideazaDestinatar(destinatar);
            Console.WriteLine($"[EMAIL catre {destinatar}] {mesaj}");
        }

        private static void ValideazaDestinatar(string destinatar)
        {
            if (string.IsNullOrEmpty(destinatar) || !destinatar.Contains('@'){
                throw new ArgumentException("Invalid email address");
            }
        }

    }
}