using System;
using System.Configuration;

namespace Mastermind.GameStates
{
    class StatisticsState : IGameState
    {
        private string Prompt { get; }
        private GameStatistics Statistics { get; }

        public StatisticsState()
        {
            Prompt = ConfigurationManager.AppSettings["BackToMainMenu"];
            Statistics = GameStatistics.GetStatistics();
        }

        public IGameState Run()
        {
            Console.WriteLine($"Games Played : {Statistics.Games}");
            Console.WriteLine($"Wins : {Statistics.Wins}");
            Console.WriteLine($"Losses : {Statistics.Losses}");
            Console.WriteLine($"Win Rate : {Statistics.WinRate * 100}%");
            Console.WriteLine(Prompt);
            Console.ReadLine();
            return GameStateFactory.CreateMainMenuState();
        }
    }
}