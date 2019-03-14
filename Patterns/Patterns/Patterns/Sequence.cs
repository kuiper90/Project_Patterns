﻿using Patterns;
using System;

namespace Patterns
{
    public class Sequence : IPattern
    {
        IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }
        
        public IMatch Match(string text)
        {
            string remainingText = text;

            foreach (var pattern in this.patterns)
            {
                IMatch match = pattern.Match(remainingText);

                if (!match.Success())
                    return new Match(false, text);
                remainingText = match.RemainingText();
            }
            return (new Match(true, remainingText));
        }
    }
}
