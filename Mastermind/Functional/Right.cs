using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind.Functional
{
    class Right<TLeft,TRight> : Either<TLeft,TRight>
    {
        private TRight Value { get; }

        public Right(TRight value) =>
            Value = value;

        public static implicit operator TRight(Right<TLeft, TRight> obj) =>
            obj.Value;
    }
}
