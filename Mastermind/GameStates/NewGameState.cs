using System;
using System.Configuration;

namespace Mastermind.GameStates
{
    class NewGameState : IGameState
    {
        private string Prompt { get; }
        private GameSettings Settings { get; set; }

        public NewGameState()
        {
            Prompt = ConfigurationManager.AppSettings["GameStart"];
            Settings = GameSettings.GetSettings();

            Game.NewGame();
        }

        public IGameState Run()
        {
            Console.WriteLine(string.Format(Prompt, Settings.AllowedCharacters, Settings.CharacterNumber, Settings.GuessNumber));
            return new GetGuessState();
        }
    }
}