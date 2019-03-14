using System;
using Patterns;

namespace Patterns
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            Choice value = new Choice(
                new Strings(),
                new Number(),
                new Text("true"),
                new Text("false"),
                new Text("null")
            );

            IPattern separator = Wrap(',');

            IPattern objBody = new List(new Sequence(new Strings(), Wrap(':'), value), separator);
            IPattern obj = new Sequence(Wrap('{'), objBody, Wrap('}'));

            IPattern arrayBody = new List(value, separator);
            IPattern array = new Sequence(Wrap('['), arrayBody, Wrap(']'));

            value.Add(array);
            value.Add(obj);

            pattern = value;
        }

        private static IPattern Wrap(char c)
            => WrapPattern(new Character(c));
    
        private static IPattern WrapPattern(IPattern pattern)
        {
            var whitespace = new Many(new Any(" \r\n\t"));
            return new Sequence(whitespace, pattern, whitespace);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
