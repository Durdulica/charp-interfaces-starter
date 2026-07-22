namespace Interfaces.ex1.Models
{
    public class Priza : IPornibil, IRaportor
    {
        private bool EPornit {  get; set; }

        public void Porneste()
        {
            EPornit = true;
        }

        public void Opreste()
        {
            EPornit = false;
        }

        public bool EstePornit()
        {
            return EPornit;
        }

        public string Stare()
        {
            return EPornit.ToString();
        }
    }
}