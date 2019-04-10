using Mastermind.Functional;
using System.Configuration;

namespace Mastermind
{
    internal class SuccessGuessResult : IGuessResult
    {
        private string Prompt { get; }
        private string TrueString { get; }
        private int GuessNumber { get; }
        private int CurrentGuess { get; }

        public SuccessGuessResult(string trueString, int guessNumber, int currentGuess)
        {
            Prompt = ConfigurationManager.AppSettings["SuccessPrompt"];
            TrueString = trueString;
            GuessNumber = guessNumber;
            CurrentGuess = currentGuess;
        }

        public override string ToString() =>
            string.Format(Prompt, TrueString, CurrentGuess, GuessNumber);
    }
}