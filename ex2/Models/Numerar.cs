namespace Interfaces.ex2.Models
{
    public class Numerar : IMetodaPlata, IRambursabil
    {
        public string Nume { get; }
        private double SumaDisponibila { get; set; }

        public Numerar(string nume, double sumaDisponibila)
        {
            Nume = nume;
            SumaDisponibila = sumaDisponibila;
        }

        public bool Plateste(double pret)
        {
            if (pret < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            if (SumaDisponibila > pret)
            {
                SumaDisponibila -= pret;
                return true;
            }
            return false;
            throw new InvalidOperationException("Not enough cash in the drawer");
        }

        public void Ramburseaza(double pret)
        {
            if (pret < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            SumaDisponibila += pret;
        }
    }
}
