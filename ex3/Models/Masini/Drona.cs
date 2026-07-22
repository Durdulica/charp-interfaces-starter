namespace Interfaces.ex3.Models.Masini
{
    public class Drona : Vehicul, ILivrator
    {
        public double Capacitate { get; }

        public Drona(string marca, int autonomie) : base(marca, autonomie)
        {
            Capacitate = 3;
        }

        public string Identificare()
        {
            return "Drona " + Marca;
        }

        public bool PoateLivra(double greutateKg)
        {
            if (greutateKg < Capacitate && Autonomie >= 5)
            {
                return true;
            }

            return false;
        }

        public void Livreaza(string adresa, double greutateKg)
        {
            if (!PoateLivra(greutateKg))
            {
                throw new InvalidOperationException("This courier cannot deliver the package");
            }

            Console.WriteLine(Identificare() + " livreaza la adresa " + adresa + " un colet de " + greutateKg + " kg");
            Autonomie -= 5;
        }
    }
}