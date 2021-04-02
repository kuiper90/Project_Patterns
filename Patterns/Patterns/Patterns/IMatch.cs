namespace Patterns
{
    public interface IMatch
    {
        bool Success();

        string RemainingText();
    }
}