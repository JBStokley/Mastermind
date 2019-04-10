using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    class NormalGuessResult :IGuessResult
    {
        private int Exact { get; }
        private int Close { get; }

        public NormalGuessResult(int exact, int close)
        {
            Exact = exact;
            Close = close;
        }

        public override string ToString() =>
            StringFactory.CreateSingleCharacterString('+', Exact) +
            StringFactory.CreateSingleCharacterString('-', Close);
    }
}
