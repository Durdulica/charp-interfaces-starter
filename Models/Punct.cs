namespace Interfaces.Models
{
    public class Punct : IElement
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Punct(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Afisare()
        {
            Console.Write("(" + X + "," + Y + ")");
        }

        public void Translatare(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public IElement Duplicare()
        {
            return new Punct(X, Y);
        }
    }
}
