namespace Interfaces.ex4.Models
{
    public class NotificatorCuIstoric : INotificator
    {
        private readonly string[] istoric = new string[10];
        private int nrMesaje;
        private readonly INotificator interior;

        public string Canal => interior.Canal;

        public NotificatorCuIstoric(INotificator interior)
        {
            this.interior = interior;
        }

        public void AfiseazaIstoric()
        {
            for(int i = 0; i < istoric.Length; i++)
            {
                if (istoric[i] != null)
                {
                    Console.WriteLine(istoric[i]);
                }
            }
        }

        public void Trimite(string destinatar, string mesaj)
        {
            interior.Trimite(destinatar, mesaj);

            istoric[nrMesaje % istoric.Length] = mesaj;
            nrMesaje++;
        }
    }
}