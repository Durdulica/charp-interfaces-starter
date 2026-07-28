using Interfaces.ex5.Models;

namespace Interfaces.ex5
{
    public class Testare5
    {
        public Testare5()
        {
            Elev[] elevi = new Elev[5]
            {
                new Elev("Stefan",9.5),
                new Elev("Alex", 7.34),
                new Elev("Sebi",8.96),
                new Elev("George",10),
                new Elev("Costi",9.65)
            };

            Produs[] produs = new Produs[5]
            {
                new Produs("mere",5),
                new Produs("pere",8),
                new Produs("prune", 3),
                new Produs("capsuni",20),
                new Produs("cirese",18)
            };

            Cuvant[] cuvinte = new Cuvant[5]
            {
                new Cuvant("mere"),
                new Cuvant("pere"),
                new Cuvant("prune"),
                new Cuvant("capsuni"),
                new Cuvant("cirese")
            };

            for(int i = 0; i < 5; i++)
            {
                elevi[i].Afisare();
            } 

            Sortator<Elev> sortator1 = new Sortator<Elev>();
            sortator1.Sorteaza(elevi);
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                elevi[i].Afisare();
            }

            Console.WriteLine();

            for(int i = 0; i < 5; i++)
            {
                produs[i].Afisare();
            }

            Sortator<Produs> sortator2 = new();
            sortator2.Sorteaza(produs);
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                produs[i].Afisare();
            }

            Console.WriteLine();

            for(int i = 0; i < 5; i++)
            {
                cuvinte[i].Afisare();
            }

            Sortator<Cuvant> sortator3 = new();
            sortator3.Sorteaza(cuvinte);
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                cuvinte[i].Afisare();
            }
        }
    }
}