namespace Patterns
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            Choice value = new Choice(
                new String(),
                new Number(),
                new Text("true"),
                new Text("false"),
                new Text("null")
            );
            var element = Element(value);
            value.Add(Array(value));
            value.Add(Object(element));
            this.pattern = element;
        }

        private IPattern Array(IPattern value)
            => new Sequence(Separator('['), Elements(value), Separator(']'));

        private IPattern Object(IPattern element)
            => new Sequence(Separator('{'), Members(element), Separator('}'));

        private IPattern Separator(char ch)
            => new Sequence(Whitespace(), new Character(ch), Whitespace());

        private IPattern Whitespace()
            => new Many(new Any(" \r\n\t"));

        private IPattern Members(IPattern element)
            => new List(Member(element), Separator(','));

        private IPattern Member(IPattern element)
            => new Sequence(Whitespace(), new String(), Separator(':'), element);

        private IPattern Elements(IPattern value)
            => new List(Element(value), Separator(','));

        private IPattern Element(IPattern value)
            => new Sequence(Whitespace(), value, Whitespace());

        public IMatch Match(string text)
            => this.pattern.Match(text);
    }
}