using System;

namespace Mastermind
{
    class Guess
    {
        public string GuessString { get; }

        private Guess(string guess) =>
            GuessString = guess;

        public static Guess GetGuess() =>
            new Guess(Console.ReadLine());
    }
}