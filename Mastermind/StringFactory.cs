using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    static class StringFactory
    {
        public static string CreateSingleCharacterString(char character, int number)
        {
            var s = "";
            for (var i = 0; i < number; i++)
                s += character;
            return s;
        }
    }
}
