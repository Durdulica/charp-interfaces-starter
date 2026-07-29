namespace Interfaces.ex4.Models
{
    public class MagazinOnline
    {
        private readonly INotificator[] Canale;

        public MagazinOnline(INotificator[] canale)
        {
            ArgumentNullException.ThrowIfNull(canale);
            Canale = canale;
        }

        public void AnuntaExpediere(string client, string[] destinatari, string numarComanda)
        {
            ArgumentNullException.ThrowIfNull("destinatari");

            if (destinatari.Length != Canale.Length)
            {
                throw new ArgumentException("Number of addressees must fit the number of channels");
            }

            string mesaj = $"Comanda {numarComanda} a fost expediata";

            for (int i = 0; i < Canale.Length; i++)
            {
                var canal = Canale[i];

                try
                {
                    canal.Trimite(destinatari[i], mesaj);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Channel {canal.Canal} failed: {ex.Message}");
                }
            }
        }
    }
}