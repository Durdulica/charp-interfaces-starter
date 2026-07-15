namespace Interfaces.Models
{
    public interface IElement : IAfisabil, ITranslatabil
    {
        IElement Duplicare();
    }
}
