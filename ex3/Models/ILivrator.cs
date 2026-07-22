namespace Interfaces.ex3.Models
{
    public interface ILivrator
    {
        public string Identificare();

        bool PoateLivra(double greutateKg);

        void Livreaza(string adresa, double greutateKg);
    }
}
