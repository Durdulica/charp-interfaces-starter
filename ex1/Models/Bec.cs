namespace Interfaces.ex1.Models
{
    public class Bec : IPornibil, IReglabil, IRaportor
    {
        private int intensitate;
        private bool EPornit {  get; set; }

        public int Intensitate
        {
            get { return intensitate; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Intensity must be between 0 and 100");
                } 
                intensitate = value;
            }
        }

        public void Porneste()
        {
            EPornit = true;
            Intensitate = 100;
        }

        public void Opreste()
        {
            EPornit = false;
            Intensitate = 0;
        }

        public bool EstePornit()
        {
            return EPornit;
        }

        public void SeteazaIntensitate(int procent)
        {
            Intensitate = procent;
        }

        public void SeteazaIntensitateMinima()
        {
            Intensitate = 10;
        }

        public string Stare()
        {
            return "este pornit:" + EstePornit().ToString() + ",intensitate: " + Intensitate;
        }
    }
}