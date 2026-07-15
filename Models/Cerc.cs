namespace Interfaces.Models
{
    public class Cerc : IElement
    {
        public Punct Centru { get; set; }
        public int Raza { get; set; }

        public Cerc(Punct centru, int raza)
        {
            Centru = centru;
            Raza = raza;
        }

        public void Afisare()
        {
            Console.Write("Cerc: centru ");
            Centru.Afisare();
            Console.Write(", raza " + Raza);
        }

        public void Translatare(int dx, int dy)
        {
            Centru.Translatare(dx, dy);
        }

        public IElement Duplicare()
        {
            return new Cerc((Punct)Centru.Duplicare(), Raza);
        }
    }
}
