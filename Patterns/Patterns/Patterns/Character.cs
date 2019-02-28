using Patterns;

namespace Patterns
{
    public class Character : IPattern
    {
        char chr;

        public Character(char chr)
        {
            this.chr = chr;
        }

        public IMatch Match(string text)
        {
            if (text == "")
                return (new Match(false, text));            
            bool success = text[0] == this.chr;
            if (!success)
                return (new Match(false, text));
            return (new Match(success, text.Remove(0, 1)));
            
        }
    }
}
