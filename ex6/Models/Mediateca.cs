namespace Interfaces.ex6.Models
{
    public class Mediateca
    {
        public void RedaMuzica(IPlayerAudio[] playere, string fisier)
        {
            for (int i = 0; i < playere.Length; i++)
            {
                playere[i].Reda(fisier);
            }
        }

        public void RedaFilm(IPlayerVideo[] playere, string fisier)
        {
            for (int i = 0; i < playere.Length; i++)
            {
                playere[i].Reda(fisier);
            }
        }
    }
}