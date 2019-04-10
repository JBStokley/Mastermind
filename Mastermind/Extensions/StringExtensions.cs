using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mastermind.Extensions
{
    static class StringExtensions
    {
        public static bool ContainsAll(this string master, IEnumerable<char> sub)
        {
            foreach (var c in sub)
                if (!master.Contains(c))
                    return false;
            return true;
        }
    }
}
