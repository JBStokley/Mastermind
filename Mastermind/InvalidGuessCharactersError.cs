using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    class InvalidGuessCharactersError : Error
    {
        public InvalidGuessCharactersError(string errorString) =>
            ErrorString = errorString;
    }
}
