namespace Interfaces.ex4.Models
{
    public class Echipament
    {
        public int NrInventar { get; }
        public int AnAchizitie { get; }

        public Echipament(int nrInventar, int anAchizitie)
        {
            NrInventar = nrInventar;
            AnAchizitie = anAchizitie;
        }
    }
}