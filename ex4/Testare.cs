using Interfaces.ex4.Models;

namespace Interfaces.ex4
{
    public class Testare
    {
        public Testare() {
            INotificator[] canale =
           [
            new EmailNotificator(),
            new SmsNotificator(),
            new ImprimantaBonuri(11, 2022)
           ];

            var magazin = new MagazinOnline(canale);

            magazin.AnuntaExpediere(
                "Ion Popescu",
                ["ion.popescu@example.com", "0712345678", ""],
                "CMD-1001");

            magazin.AnuntaExpediere(
                "Maria Ionescu",
                ["marias", "07123t5678", ""],
                "CMD-1002");
        }
    }
}
