using System;
using System.Configuration;

namespace Mastermind.GameStates
{
    class ResetSettingsState : IGameState
    {
        private string Prompt { get; }

        public ResetSettingsState() =>
            Prompt = ConfigurationManager.AppSettings["ResetSettings"];

        public IGameState Run()
        {
            new GameSettings().Save();
            GameSettings.LoadSettings();
            Console.WriteLine(Prompt);
            return GameStateFactory.CreateViewSettingsState();
        }
    }
}