using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind.Functional
{
    abstract class Either<TLeft,TRight>
    {
        public static implicit operator Either<TLeft, TRight>(TLeft obj) =>
            new Left<TLeft, TRight>(obj);

        public static implicit operator Either<TLeft, TRight>(TRight obj) =>
            new Right<TLeft, TRight>(obj);
    }
}
