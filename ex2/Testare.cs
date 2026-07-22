using Interfaces.ex2.Models;

namespace Interfaces.ex2
{
    public class Testare
    {
        public Testare() {
            CasaDeMarcat casa = new();
            double[] cos = [120.50, 80, 45.99];

            CardBancar card = new("ING", 200);
            Numerar numerar = new("Cash", 170);
            VoucherCadou voucher = new("Voucher", 110);

            casa.ProceseazaCos(cos, card);
            casa.ProceseazaCos(cos, numerar);
            casa.ProceseazaCos(cos, voucher);

            card.Ramburseaza(45.99);
            try
            {
                numerar.Ramburseaza(-45.99);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}