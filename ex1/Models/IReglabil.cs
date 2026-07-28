namespace Interfaces.ex1.Models
{
    public interface IReglabil
    {
        void SeteazaIntensitate(int procent);

        int Minim { get; }
    }
}