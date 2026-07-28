namespace Interfaces.ex1.Models
{
    public class Priza : IPornibil, IRaportor
    {
        public bool EstePornit {  get; set; }

        public void Porneste()
        {
            EstePornit = true;
        }

        public void Opreste()
        {
            EstePornit = false;
        }

        public string Stare()
        {
            return EstePornit.ToString();
        }
    }
}