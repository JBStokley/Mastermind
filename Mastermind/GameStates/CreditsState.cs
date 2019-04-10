using System;
using System.Configuration;

namespace Mastermind.GameStates
{
    class CreditsState : IGameState
    {
        private string Credits { get; }
        private string Prompt { get; }

        public CreditsState()
        {
            Prompt = ConfigurationManager.AppSettings["BackToMainMenu"];
            
            var name = ConfigurationManager.AppSettings["CreatorName"];
            var github = ConfigurationManager.AppSettings["GithubLink"];
            var linkedin = ConfigurationManager.AppSettings["LinkedinLink"];
            Credits = $"Created By: {name} | {github} | {linkedin}";
        }

        public IGameState Run()
        {
            Console.WriteLine(Credits);
            Console.WriteLine(Prompt);
            Console.ReadLine();
            return GameStateFactory.CreateMainMenuState();
        }
    }
}