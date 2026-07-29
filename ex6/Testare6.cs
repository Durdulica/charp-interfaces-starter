using Interfaces.ex6.Models;

namespace Interfaces.ex6
{
    public class Testare6
    {


        public Testare6()
        {
            //metoda nu este vizibila deoarece tipul ei nu este public. Indiferent de tipul tvului din testare metoda nu este vizibila
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
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}