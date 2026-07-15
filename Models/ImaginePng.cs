namespace Interfaces.Models
{
    public class ImaginePng : Resursa, IElement
    {
        public Punct Pozitie { get; set; }

        public ImaginePng(string numeFisier, int dimensiuneKb, Punct pozitie)
            : base(numeFisier, dimensiuneKb)
        {
            Pozitie = pozitie;
        }

        public void Afisare()
        {
            Console.Write("Imagine \"" + NumeFisier + "\" (" + DimensiuneKb + " KB) la ");
            Pozitie.Afisare();
        }

        public void Translatare(int dx, int dy)
        {
            Pozitie.Translatare(dx, dy);
        }

        public IElement Duplicare()
        {
            return new ImaginePng(NumeFisier, DimensiuneKb, (Punct)Pozitie.Duplicare());
        }
    }
}
