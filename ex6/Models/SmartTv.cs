namespace Interfaces.ex6.Models
{
    public class SmartTv : IPlayerAudio, IPlayerVideo
    {
        void IPlayerAudio.Reda(string fisier)
        {
            if (!fisier.EndsWith(".mp3"))
            {
                throw new ArgumentException("Invalid audio file");
            }

            Console.WriteLine("SmartTv reda " + fisier);
        }

        void IPlayerVideo.Reda(string fisier)
        {
            if (!fisier.EndsWith(".mp4"))
            {
                throw new ArgumentException("Invalid video file");
            }

            Console.WriteLine("SmartTv reda " + fisier);
        }
    }
}