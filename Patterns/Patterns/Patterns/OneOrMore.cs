namespace Patterns
{
    public class OneOrMore : IPattern
    {
        IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = new Sequence(pattern, new Many(pattern));
        }

        public IMatch Match(string text)
            => pattern.Match(text);
    }
}