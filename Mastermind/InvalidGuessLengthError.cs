using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    class InvalidGuessLengthError : Error
    {
        public InvalidGuessLengthError(string errorString) =>
            ErrorString = errorString;
    }
}
