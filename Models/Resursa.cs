namespace Interfaces.Models
{
    public class Resursa
    {
        public string NumeFisier { get; set; }
        public int DimensiuneKb { get; set; }

        public Resursa(string numeFisier, int dimensiuneKb)
        {
            NumeFisier = numeFisier;
            DimensiuneKb = dimensiuneKb;
        }
    }
}
