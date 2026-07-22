using Interfaces.ex3.Models;
using Interfaces.ex3.Models.Masini;
using Interfaces.ex3.Models.Oameni;

namespace Interfaces.ex3
{
    public class Testare
    {
        public Testare()
        {
            Curier curier1 = new("Alex", 4000);
            Curier curier2 = new("Stefan", 5000);
            Drona drona1 = new("DJI-135", 14);
            Drona drona2 = new("ARCTX-250", 21);
            Robot robot = new("Roborok");

            ILivrator[] livratori = new ILivrator[5];
            livratori[0] = drona1;
            livratori[1] = drona2;
            livratori[2] = curier1;
            livratori[3] = curier2;
            livratori[4] = robot;

            CentruDeLivrari centru = new(livratori);

            centru.DistribuieColet("test1", 1);
            centru.DistribuieColet("test2", 2.5);
            centru.DistribuieColet("test3", 15);
            centru.DistribuieColet("test4", 25);
        }
    }
}
