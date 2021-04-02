namespace Patterns
{
    public class Text : IPattern
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(this.prefix))
            {
                return new Match(text != null, text);
            }

            if (!string.IsNullOrEmpty(text) && text.StartsWith(this.prefix))
            {
                return new Match(true, text.Substring(this.prefix.Length));
            }

            return new Match(false, text);
        }
    }
}