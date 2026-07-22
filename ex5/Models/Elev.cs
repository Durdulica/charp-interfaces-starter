namespace Interfaces.ex5.Models
{
    public class Elev : IComparabil<Elev>
    {
        public string Nume { get; }
        public double Media {  get; }

        public Elev(string nume, double media)
        {
            Nume = nume;
            Media = media;
        }
        public int ComparaCu(Elev altul)
        {
            if (Media < altul.Media)
            {
                return 1;
            }
            if (Media > altul.Media)
            {
                return -1;
            }

            return 0;
        }
    }
}