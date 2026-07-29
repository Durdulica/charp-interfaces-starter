namespace Interfaces.ex6.Models
{
    public interface IPlayerComplet : IPlayerAudio, IPlayerVideo
    {
        void Testeaza(IPlayerComplet player);
    }
}