namespace Interfaces.Models
{
    public class Dreptunghi : IElement
    {
        public Punct StSus { get; set; }
        public Punct DrJos { get; set; }

        public Dreptunghi(Punct stSus, Punct drJos)
        {
            StSus = stSus;
            DrJos = drJos;
        }

        public void Afisare()
        {
            Console.Write("Dreptunghi: ");
            StSus.Afisare();
            Console.Write(" - ");
            DrJos.Afisare();
        }

        public void Translatare(int dx, int dy)
        {
            StSus.Translatare(dx, dy);
            DrJos.Translatare(dx, dy);
        }

        public IElement Duplicare()
        {
            return new Dreptunghi((Punct)StSus.Duplicare(), (Punct)DrJos.Duplicare());
        }
    }
}
