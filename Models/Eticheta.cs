namespace Interfaces.Models
{
    public class Eticheta : IElement
    {
        public Punct StSus { get; set; }
        public Punct DrJos { get; set; }
        public string Text { get; set; }

        public Eticheta(Punct stSus, Punct drJos, string text)
        {
            StSus = stSus;
            DrJos = drJos;
            Text = text;
        }

        public void Afisare()
        {
            Console.Write("Eticheta \"" + Text + "\": ");
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
            return new Eticheta((Punct)StSus.Duplicare(), (Punct)DrJos.Duplicare(), Text);
        }
    }
}
