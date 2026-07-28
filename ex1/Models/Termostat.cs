namespace Interfaces.ex1.Models
{
    public class Termostat : IReglabil, IRaportor
    {
        private int temp;
        public int Minim { get; } = 18;
        private int Temp
        {
            get {  return temp; }
            set
            {
                if(value < 5 || value > 30)
                {
                    throw new ArgumentException("Temperature must be between 5 and 30");
                }
                temp = value;
            }
        }
        public void SeteazaIntensitate(int temperatura)
        {
            Temp = temperatura;
        }

        public string Stare()
        {
            return "temperatura: " + Temp;
        }
    }
}