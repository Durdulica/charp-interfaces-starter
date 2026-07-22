namespace Interfaces.ex5.Models
{
    public class Sortator
    {
        public void Sorteaza(IComparabil[] elemente)
        {
            for (int i = 0; i < elemente.Length - 1; i++)
            {
                for (int j = 1; j < elemente.Length; j++)
                {
                    int value = elemente[i].ComparaCu(elemente[j]);

                    if(i < j && value > 0)
                    {
                        (elemente[j], elemente[i]) = (elemente[i], elemente[j]);
                    }
                    else if (i > j && value < 0)
                    {
                        (elemente[j], elemente[i]) = (elemente[i], elemente[j]);
                    }
                }
            }
        }
    }
}