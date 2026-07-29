using Interfaces.ex6.Models;

namespace Interfaces.ex6
{
    public class Testare6
    {
        public Testare6()
        {
            //metoda este vizibila doar prin tipul ei de interfata. Prin tipul IPlayerAudio sau IPlayerVideo se vede metoda
            SmartTv tv = new();
            BoxaPortabila boxa = new("boxa");
            VideoProiector proiector = new("proiector");

            Mediateca media = new();

            IPlayerAudio[] playerAudio =
            [
                tv,
                boxa,
            ];

            IPlayerVideo[] playerVideo = 
            [
                tv,
                proiector,
            ];

            media.RedaMuzica(playerAudio, "Nirvana.mp3"); 
            media.RedaFilm(playerVideo, "Star_Wars.mp4");
            try
            {
                media.RedaMuzica(playerAudio, "Test.mp4");
            }
            catch (ArgumentException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void Testeaza(IPlayerComplet player)
        {
            ((IPlayerVideo)player).Reda("test.mp4");
        }
    }
}