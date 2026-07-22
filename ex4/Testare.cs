using Interfaces.ex4.Models;

namespace Interfaces.ex4
{
    public class Testare
    {
        public Testare() {
            INotificator[] canale = new INotificator[]
           {
            new EmailNotificator(),
            new SmsNotificator(),
            new ImprimantaBonuri(11, 2022)
           };

            var magazin = new MagazinOnline(canale, null);

            magazin.AnuntaExpediere(
                "Ion Popescu",
                new[] { "ion.popescu@example.com", "0712345678", "" },
                "CMD-1001");

            magazin.AnuntaExpediere(
                "Maria Ionescu",
                new[] { "maria", "", "" },
                "CMD-1002");
        }
    }
}
