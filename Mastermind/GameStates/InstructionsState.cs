using System;
using System.Configuration;

namespace Mastermind.GameStates
{
    class InstructionsState : IGameState
    {
        private string Instructions { get; }
        private string Prompt { get; }

        public InstructionsState()
        {
            Instructions = ConfigurationManager.AppSettings["Instructions"];
            Prompt = ConfigurationManager.AppSettings["BackToMainMenu"];
        }

        public IGameState Run()
        {
            Console.WriteLine(Instructions);
            Console.WriteLine(Prompt);
            Console.ReadLine();
            return GameStateFactory.CreateMainMenuState();
        }
    }
}