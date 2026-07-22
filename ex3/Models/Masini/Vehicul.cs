namespace Interfaces.ex3.Models.Masini
{
    public class Vehicul
    {
        public string Marca { get; }
        public int Autonomie { get; set; } //km

        public Vehicul(string marca, int autonomie)
        {
            Marca = marca;
            Autonomie = autonomie;
        }
    }
}