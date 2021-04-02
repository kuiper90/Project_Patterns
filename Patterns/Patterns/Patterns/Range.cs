namespace Patterns
{
    public class Range : IPattern
    {
        private char start;
        private char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            bool withinRange = this.start <= text[0] && this.end >= text[0];
            if (!withinRange)
            {
                return new Match(false, text);
            }

            return new Match(withinRange, text.Remove(0, 1));
        }
    }
}