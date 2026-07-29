using Interfaces.ex2.Models;

namespace Interfaces.ex2
{
    public class Testare2
    {
        public Testare2() {
            CasaDeMarcat casa = new();
            double[] cos = [120.50, 80, 45.99];

            CardBancar card = new("ING", 200);
            Numerar numerar = new("Cash", 300);
            VoucherCadou voucher = new("Voucher", 110);

            casa.ProceseazaCos(cos, card);
            casa.ProceseazaCos(cos, numerar);
            casa.ProceseazaCos(cos, voucher);

            card.Ramburseaza(45.99);
            numerar.Ramburseaza(20);

            try
            {
                numerar.Ramburseaza(245.99);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}