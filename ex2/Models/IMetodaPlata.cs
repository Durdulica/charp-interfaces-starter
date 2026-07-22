namespace Interfaces.ex2.Models
{
    public interface IMetodaPlata
    {
        string Nume { get; }

        bool Plateste(double suma);
    }
}