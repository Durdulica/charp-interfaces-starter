namespace Interfaces.ex3.Models
{
    public class Robot : ILivrator
    {
        public string Marca { get; }
        public int Capacitate { get; }

        private int livrare = 0;

        public Robot(string marca)
        {
            Marca = marca;
            Capacitate = 50;
        }

        public string Identificare()
        {
            return "Robot " + Marca;
        }

        public bool PoateLivra(double greutateKg)
        {
            if (greutateKg <= Capacitate && livrare != 3)
            {
                return true;
            }

            return false;
        }

        public void Livreaza(string adresa, double greutateKg) {
            if (livrare == 3)
            {
                livrare = 0;
                throw new InvalidOperationException("This courier is recharging");
            }

            if (!PoateLivra(greutateKg))
            {
                throw new InvalidOperationException("This courier cannot deliver the package");
            }

            livrare++;
            Console.WriteLine(Identificare() + " livreaza la adresa " + adresa + " un colet de " + greutateKg + " kg");
        }
    }
}