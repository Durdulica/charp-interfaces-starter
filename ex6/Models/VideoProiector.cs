namespace Interfaces.ex6.Models
{
    public class VideoProiector : IPlayerVideo
    {
        private readonly string name;

        public VideoProiector(string name)
        {
            this.name = name;
        }

        public void Reda(string fisier)
        {
            if (!fisier.EndsWith(".mp4"))
            {
                throw new ArgumentException("Invalid video file");
            }

            Console.WriteLine("[VIDEO] Redau " + fisier);
        }       
    }
}