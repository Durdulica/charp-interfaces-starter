namespace Interfaces.ex1.Models
{
    public class Boxa : IPornibil, IReglabil, IRaportor
    {
        private int volum;
        private bool EPornita { get; set; }

        private int Volum
        {
            get { return volum; }
            set
            {
                if (value < 0 && value > 100)
                {

                }
                volum = value;
            }
        }

        public void Porneste()
        {
            EPornita = true;
            volum = 100;
        }

        public void Opreste()
        {
            EPornita = false;
            volum = 0;
        }

        public bool EstePornit()
        {
            return EPornita;
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
            return "e pornita: " + EstePornit().ToString() + ", volum: " + Volum;
        }
    }
}