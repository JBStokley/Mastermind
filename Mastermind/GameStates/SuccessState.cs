using System;
using System.Configuration;

namespace Mastermind.GameStates
{
    class SuccessState : IGameState
    {
        private string Success { get; }
        private string Prompt { get; }

        public SuccessState()
        {
            Success = ConfigurationManager.AppSettings["Success"];
            Prompt = ConfigurationManager.AppSettings["BackToMainMenu"];

            GameStatistics
                .GetStatistics()
                .AddGames(1)
                .AddWins(1)
                .Save();
            GameStatistics.LoadStatistics();
        }

        public IGameState Run()
        {
            Console.WriteLine(Success);
            Console.WriteLine(Prompt);
            Console.ReadLine();
            return GameStateFactory.CreateMainMenuState();
        }
    }
}