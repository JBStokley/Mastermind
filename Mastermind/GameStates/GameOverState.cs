using System;
using System.Configuration;

namespace Mastermind.GameStates
{
    class GameOverState : IGameState
    {
        private string GameOver { get; }
        private string Prompt { get; }

        public GameOverState()
        {
            GameOver = ConfigurationManager.AppSettings["GameOver"];
            Prompt = ConfigurationManager.AppSettings["BackToMainMenu"];

            GameStatistics
                .GetStatistics()
                .AddGames(1)
                .AddLosses(1)
                .Save();
            GameStatistics.LoadStatistics();
        }

        public IGameState Run()
        {
            Console.WriteLine(string.Format(GameOver, Game.GetGame().TrueString));
            Console.WriteLine(Prompt);
            Console.ReadLine();
            return GameStateFactory.CreateMainMenuState();
        }
    }
}