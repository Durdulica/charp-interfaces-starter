namespace Interfaces.ex4.Models
{
    public class ImprimantaBonuri : Echipament, INotificator
    {
        public string Canal => "PRINTER";
        public ImprimantaBonuri(int nrInventar, int anAchizitie) : base(nrInventar, anAchizitie) { }

        public void Trimite(string destinatar, string mesaj)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine(mesaj);
            Console.WriteLine("-------------------");
        }
    }
}