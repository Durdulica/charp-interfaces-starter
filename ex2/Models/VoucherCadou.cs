namespace Interfaces.ex2.Models
{
    public class VoucherCadou : IMetodaPlata
    {
        public string Nume { get; }
        private double Valoare { get; set; }

        public VoucherCadou(string nume, double valoare) {
            Nume = nume;
            Valoare = valoare;
        }

        public bool Plateste(double pret)
        {
            if(pret < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            if (Valoare > pret) {
                Valoare -= pret;
                return true;
            }

            return false;
        }
    }
}
