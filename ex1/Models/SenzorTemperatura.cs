namespace Interfaces.ex1.Models
{
    public class SenzorTemperatura : IRaportor
    {
        private int Temp { get; }

        public SenzorTemperatura(int temp)
        {
            Temp = temp;
        }

        public string Stare()
        {
            return "temperatura: " + Temp;
        }
    }
}
