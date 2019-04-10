using System;
using System.Configuration;

namespace Mastermind.GameStates
{
     class GetGuessState : IGameState
    {
        private string Prompt { get; }

        public GetGuessState() =>
            Prompt = ConfigurationManager.AppSettings["GuessPrompt"];

        public IGameState Run()
        {
            Console.WriteLine(
                string.Format(
                    Prompt,
                    Game.GetGame().CurrentGuess, Game.GetGame().GuessNumber
                    )
                );
            return new CheckGuessState(Guess.GetGuess());
        }
    }
}