namespace Interfaces.Models
{
    public class Linie : IElement
    {
        public Punct A { get; set; }
        public Punct B { get; set; }

        public Linie(Punct a, Punct b)
        {
            A = a;
            B = b;
        }

        public void Afisare()
        {
            Console.Write("Linie: ");
            A.Afisare();
            Console.Write(" - ");
            B.Afisare();
        }

        public void Translatare(int dx, int dy)
        {
            A.Translatare(dx, dy);
            B.Translatare(dx, dy);
        }

        public IElement Duplicare()
        {
            return new Linie((Punct)A.Duplicare(), (Punct)B.Duplicare());
        }
    }
}
