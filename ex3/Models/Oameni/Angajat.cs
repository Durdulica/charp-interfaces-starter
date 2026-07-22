namespace Interfaces.ex3.Models.Oameni
{
    public class Angajat
    {
        public string Nume { get; }
        public int Salariu { get; }

        public Angajat(string nume, int salariu)
        {
            Nume = nume;
            Salariu = salariu;
        }

    }
}
