namespace Interfaces.ex4.Models
{
    public class MagazinOnline
    {
        private readonly INotificator[] NotificatorCuIstoric;
        private readonly INotificator[] Canale;

        public MagazinOnline(INotificator[] canale, INotificator[] istoric)
        {
            if (canale == null)
            {
                throw new ArgumentNullException(nameof(canale));
            }
            Canale = canale;
            NotificatorCuIstoric = istoric;
        }

        public void AnuntaExpediere(string client, string[] destinatari, string numarComanda)
        {
            if (destinatari == null)
            {
                throw new ArgumentException(nameof(destinatari));
            }

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

        public void AfiseazaIstoric()
        {
            string mesaje = "";

            for (int i = 0; i < NotificatorCuIstoric.Length; i++)
            {
                mesaje += NotificatorCuIstoric[i] + "\n";
            }

            Console.WriteLine("Istoric mesaje: \n" + mesaje);
        }
    }
}