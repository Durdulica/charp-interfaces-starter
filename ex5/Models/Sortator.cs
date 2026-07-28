namespace Interfaces.ex5.Models
{
    public class Sortator<T> where T:IComparabil<T>
    {
        public void Sorteaza(T[] elemente)
        {
            for (int i = 0; i < elemente.Length - 1; i++)
            {
                for (int j = 0; j < elemente.Length - 1 - i; j++)
                {
                    if (elemente[j].ComparaCu(elemente[j + 1]) > 0)
                    {
                        (elemente[j], elemente[j + 1]) = (elemente[j + 1], elemente[j]);
                    }
                }
            }
        }
    }
}