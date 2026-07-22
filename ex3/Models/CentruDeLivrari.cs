namespace Interfaces.ex3.Models
{
    public class CentruDeLivrari
    {
        public ILivrator[] Livrari { get; }

        public CentruDeLivrari(ILivrator[] livrari)
        {
            Livrari = livrari;
        }

        public void DistribuieColet(string adresa, double greutateKg)
        {
            for (int i = 0; i < Livrari.Length; i++) {
                if (Livrari[i].PoateLivra(greutateKg))
                {
                    Livrari[i].Livreaza(adresa, greutateKg);
                    return;
                }
            }

            Console.WriteLine("No courier available for <" + adresa + ">");
        }
    }
}