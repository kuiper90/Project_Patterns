namespace Patterns
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
}