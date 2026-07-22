namespace Interfaces.ex5.Models
{
    public class Produs : IComparabil<Produs>
    {
        public string Denumire {  get; set; }
        public int Pret {  get; set; }

        public Produs(string denumire, int pret)
        {
            Denumire = denumire;
            Pret = pret;
        }

        public int ComparaCu(Produs altul)
        {
            if (Pret > altul.Pret)
            {
                return 1;
            }

            if (Pret < altul.Pret)
            {
                return -1;
            }

            return 0;
        }
    }
}