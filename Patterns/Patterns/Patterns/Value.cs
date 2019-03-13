using System;
using Patterns;

namespace Patterns
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            Choice value = new Choice(new Strings(),
                                        new Number(),
                                        new Text("true"),
                                        new Text("false"),
                                        new Text("null"));

            IPattern whitespace = new Many(new Any(" \r\n\t"));

            IPattern separatorObj = new Sequence(whitespace, new Character(':'), whitespace);

            IPattern separator = new Sequence(whitespace, new Character(','), whitespace);

            IPattern leftBrace = new Sequence(whitespace, new Character('{'), whitespace);

            IPattern rightBrace = new Sequence(whitespace, new Character('}'), whitespace);

            IPattern leftBracket = new Sequence(whitespace, new Character('['), whitespace);

            IPattern rightBracket = new Sequence(whitespace, new Character(']'), whitespace);

            IPattern objBody = new List(new Sequence(new Strings(), separatorObj, value), separator);

            IPattern obj = new Sequence(leftBrace, objBody, rightBrace);

            IPattern arrayBody = new List(value, separator);

            IPattern array = new Sequence(leftBracket, arrayBody, rightBracket);          
            value.Add(array);
            value.Add(obj);

            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
