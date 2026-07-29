using Interfaces.Models;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("PASUL 1: desenul din cerinta (eticheta + dreptunghi + linie + cerc)");
        Console.WriteLine();

        Eticheta eticheta = new Eticheta(new Punct(2, 10), new Punct(6, 8), "Text");
        Dreptunghi dreptunghi = new Dreptunghi(new Punct(1, 6), new Punct(7, 2));
        Linie linie = new Linie(new Punct(7, 4), new Punct(11, 4));
        Cerc cerc = new Cerc(new Punct(13, 4), 2);

        Desen desen = new Desen(new IElement[] { eticheta, dreptunghi, linie, cerc });
        desen.Afisare();

        Console.WriteLine();
        Console.WriteLine("PASUL 2: translatare cu (10, 5) — un singur apel, tot desenul se muta");
        Console.WriteLine();

        desen.Translatare(10, 5);
        desen.Afisare();

        Console.WriteLine();
        Console.WriteLine("PASUL 3: duplicare — copia nu se misca atunci cand mut originalul");
        Console.WriteLine();

        IElement copie = desen.Duplicare();
        desen.Translatare(-10, -5);

        Console.WriteLine("Originalul (mutat inapoi):");
        desen.Afisare();
        Console.WriteLine("Copia (a ramas pe loc):");
        copie.Afisare();

        Console.WriteLine();
        Console.WriteLine("PASUL 4: un element din ALTA ierarhie intra in desen");
        Console.WriteLine();

        ImaginePng logo = new ImaginePng("logo.png", 128, new Punct(0, 12));

        Desen desenCuLogo = new Desen(new IElement[] { logo, desen });
        desenCuLogo.Translatare(1, 1);
        desenCuLogo.Afisare();
        
        Console.WriteLine();
        Interfaces.ex1.Testare1 testare1 = new();
        Console.WriteLine();
        Interfaces.ex2.Testare2 testare2 = new();
        Console.WriteLine();
        Interfaces.ex3.Testare3 testare3 = new();
        Console.WriteLine();
        Interfaces.ex4.Testare4 testare4 = new();
        Console.WriteLine();
        Interfaces.ex5.Testare5 testare5 = new(); 

        //Criteriul de sortare nu se afla in sortator deoarece este diferit pentru fiecare clasa in parte

        Console.WriteLine();
        Interfaces.ex6.Testare6 testare6 = new();
    }
}