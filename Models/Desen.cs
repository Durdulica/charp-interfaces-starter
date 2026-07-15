namespace Interfaces.Models
{
    public class Desen : IElement
    {
        public IElement[] Elemente { get; set; }

        public Desen(IElement[] elemente)
        {
            Elemente = elemente;
        }

        public void Afisare()
        {
            Console.WriteLine("=== Desen ===");
            for (int i = 0; i < Elemente.Length; i++)
            {
                Elemente[i].Afisare();
                Console.WriteLine();
            }
            Console.WriteLine("=============");
        }

        public void Translatare(int dx, int dy)
        {
            for (int i = 0; i < Elemente.Length; i++)
            {
                Elemente[i].Translatare(dx, dy);
            }
        }

        public IElement Duplicare()
        {
            IElement[] copie = new IElement[Elemente.Length];
            for (int i = 0; i < Elemente.Length; i++)
            {
                copie[i] = Elemente[i].Duplicare();
            }
            return new Desen(copie);
        }
    }
}
