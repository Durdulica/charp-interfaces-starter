namespace Interfaces.ex4.Models
{
    public class EmailNotificator : INotificator
    {
        public string Canal => "EMAIL";
        private string destinatar = "";

        public string Destinatar
        {
            get { return destinatar; }
            set
            {
                if (string.IsNullOrEmpty(value) || !value.Contains('@'))
                {
                    throw new ArgumentException("Invalid email address");
                }

                destinatar = value;
            }
        }

        public void Trimite(string destinatar, string mesaj)
        {
            Destinatar = destinatar;
            Console.WriteLine($"[EMAIL catre {Destinatar}] {mesaj}");
        }
    }
}