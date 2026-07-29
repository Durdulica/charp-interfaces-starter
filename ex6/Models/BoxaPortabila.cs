namespace Interfaces.ex6.Models
{
    public class BoxaPortabila : IPlayerAudio
    {
        private readonly string name;

        public BoxaPortabila(string name)
        {
            this.name = name;
        }

        public void Reda(string fisier) 
        {
            if (!fisier.EndsWith(".mp3"))
            {
                throw new ArgumentException("Invalid audio file");
            }

            Console.WriteLine(name + " reda " + fisier);
        }
    }
}