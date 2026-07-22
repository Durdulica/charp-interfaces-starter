namespace Interfaces.ex2.Models
{
    public class CasaDeMarcat
    {
        public void ProceseazaCos(double[] preturi, IMetodaPlata metoda)
        {
            double platit = 0;
            Console.Write("\n");
            for (int i = 0; i < preturi.Length; i++)
            {
                if (metoda.Plateste(preturi[i])) {
                    Console.WriteLine("plata cu succes: " + preturi[i]);
                    platit += preturi[i];   
                }
                else
                {
                    Console.WriteLine("plata esuata: " + preturi[i]);
                }
            }

            Console.WriteLine("Total cheltuit: " + platit);
        }
    }
}
