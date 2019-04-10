using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mastermind.Extensions
{
    static class EnumerableExtensions
    {
        public static IEnumerable<int> FindAllIndecies<T>(this IEnumerable<T> sequence, T value)
        {
            for (var i = 0; i < sequence.Count(); i++)
            {
                if(sequence.ToList()[i].Equals(value))
                    yield return i;
            }
        }
    }
}
