namespace Interfaces.ex1.Models
{
    public class Boxa : IPornibil, IReglabil, IRaportor
    {
        private int volum;
        public bool EstePornit { get; private set; }
        public int Minim { get; } = 10;

        private int Volum
        {
            get { return volum; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Volume must be between 0 and 100");
                }

                volum = value;
            }
        }

        public void Porneste()
        {
            EstePornit = true;
            volum = 100;
        }

        public void Opreste()
        {
            EstePornit = false;
            volum = 0;
        }

        public void SeteazaIntensitate(int volum)
        {
            Volum = volum;
        }

        public void SeteazaIntensitateMinima()
        {
            Volum = 10;
        }

        public string Stare()
        {
            return "e pornita: " + EstePornit + ", volum: " + Volum;
        }
    }
}