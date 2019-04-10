using System;
using System.Configuration;

namespace Mastermind.GameStates
{
    class QuitState : IGameState
    {
        private string Prompt { get; }

        public QuitState() =>
            Prompt = ConfigurationManager.AppSettings["QuitPrompt"];

        public IGameState Run()
        {
            Console.WriteLine(Prompt);
            if (Console.ReadLine().Trim().ToLower() == "y")
                Environment.Exit(0);
            return GameStateFactory.CreateMainMenuState();
        }
    }
}