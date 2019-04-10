using Mastermind.Extensions;
using System;

namespace Mastermind.GameStates
{
    class CheckGuessState : IGameState
    {
        private Guess Guess { get; }

        public CheckGuessState(Guess guess)
        {
            Guess = guess;
        }

        public IGameState Run()
        {
            var eitherErrorOrResult = Game.GetGame().CheckGuess(Guess);
            var stringResult = eitherErrorOrResult
                .Map(g => g.ToString())
                .Reduce(e => e.ToString());
            Console.WriteLine(stringResult);
            if (Game.GetGame().Success)
                return new SuccessState();
            if (Game.GetGame().CurrentGuess >= Game.GetGame().GuessNumber)
                return new GameOverState();
            return new GetGuessState();
        }
    }
}