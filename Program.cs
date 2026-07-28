using Interfaces.ex1;
using Interfaces.ex2;
using Interfaces.ex3;
using Interfaces.ex4;
using Interfaces.ex5;
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
        Testare1 testare1 = new Testare1();
        Console.WriteLine();
        Testare2 testare2 = new Testare2();
        Console.WriteLine();
        Testare3 testare3 = new Testare3();
        Console.WriteLine();
        Testare4 testare4 = new Testare4();
        Console.WriteLine();
        Testare5 testare5 = new Testare5(); 
        Console.WriteLine();
    }
}
