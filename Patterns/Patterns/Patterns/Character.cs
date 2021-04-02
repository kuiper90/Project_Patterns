namespace Patterns
{
public class Character : IPattern
    {
        readonly char pattern;

        public Character(char newPattern)
        {
            this.pattern = newPattern;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            if (text[0] != this.pattern)
            {
                return new Match(false, text);
            }
            else
            {
                return new Match(true, text.Substring(1));
            }
        }
    }
}