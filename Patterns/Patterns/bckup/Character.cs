using Patterns;

namespace Patterns
{
    class Character : IPattern
    {
        char chr;

        public Character(char chr)
        {
            this.chr = chr;
        }

        public bool Match(string text)
        {
            return (text[0] == this.chr);
        }
    }
}
