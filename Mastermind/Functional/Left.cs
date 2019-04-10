using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind.Functional
{
    class Left<TLeft,TRight> : Either<TLeft, TRight>
    {
        private TLeft Value { get; }

        public Left(TLeft value) =>
            Value = value;

        public static implicit operator TLeft(Left<TLeft, TRight> obj) =>
            obj.Value;
    }
}
