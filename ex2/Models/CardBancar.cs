namespace Interfaces.ex2.Models
{
    public class CardBancar : IMetodaPlata, IRambursabil
    {
        private double Sold { get; set; }
        public string Nume { get; }

        public CardBancar(string nume, double sold)
        {
            Nume = nume;
            Sold = sold;
        }
        
        public bool Plateste(double pret)
        {
            if (pret < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            if (Sold > pret + Sold/100)
            {
                Sold -= pret + Sold/100;
                return true;
            }

            return false;
        }

        public void Ramburseaza(double pret)
        {
            if (pret < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            Sold += pret;
        }
    }
}
