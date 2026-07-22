namespace Interfaces.ex3.Models.Oameni
{
    public class Curier : Angajat, ILivrator
    {
        public double Capacitate { get; }

        public Curier(string nume, int salariu) : base(nume, salariu)
        {
            Capacitate = 20;
        }

        public string Identificare() {
            return "Curier " + Nume;
        }

        public bool PoateLivra(double greutateKg)
        {
            return greutateKg < Capacitate ? true : false;
        }

        public void Livreaza(string adresa, double greutateKg)
        {
            if (!PoateLivra(greutateKg))
            {
                throw new InvalidOperationException("This courier cannot deliver the package");
            }

            Console.WriteLine(Identificare() + " livreaza la adresa " + adresa + " un colet de " + greutateKg + " kg");
        }
    }
}