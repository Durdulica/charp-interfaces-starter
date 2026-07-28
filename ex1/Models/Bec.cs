namespace Interfaces.ex1.Models
{
    public class Bec : IPornibil, IReglabil, IRaportor
    {
        private int intensitate;
        public bool EstePornit { get; set; }
        public int Minim { get; } = 10;

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
            EstePornit = true;
        }

        public void Opreste()
        {
            EstePornit = false;
            Intensitate = 0;
        }

        public void SeteazaIntensitate(int procent)
        {
            EstePornit = true;
            Intensitate = procent;
        }

        public string Stare()
        {
            return "este pornit:" + EstePornit + ",intensitate: " + Intensitate;
        }
    }
}