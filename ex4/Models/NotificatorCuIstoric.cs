namespace Interfaces.ex4.Models
{
    public class NotificatorCuIstoric : INotificator
    {
        private string istoric;
        INotificator[] Notificari { get; }
        public string Canal { get; }

        public NotificatorCuIstoric(INotificator[] notificari)
        {
            Notificari = notificari;
        }

        public void AfiseazaIstoric()
        {
            for(int i = 0; i < Notificari.Length; i++)
            {
                Console.WriteLine(Notificari[i]);
            }
        }

        public void Trimite(string destinatar, string mesaj)
        {

        }
    }
}