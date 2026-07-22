namespace Interfaces.ex4.Models
{
    public interface INotificator
    {
        string Canal { get; }

        void Trimite(string destinatar, string mesaj);
    }
}
