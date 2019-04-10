using System;
using System.Configuration;
using System.Linq;

namespace Mastermind.GameStates
{
    class ChangeGuessNumberState : IGameState
    {
        private string Error { get; }
        private string Prompt { get; }

        public ChangeGuessNumberState()
        {
            Error = ConfigurationManager.AppSettings["ChangeGuessNumberError"];
            Prompt = ConfigurationManager.AppSettings["ChangeGuessNumber"];
        }

        public IGameState Run()
        {
            Console.WriteLine(Prompt);

            var input = Console.ReadLine().Trim();
            if (input == string.Empty ||
                input.Where(c => !char.IsDigit(c)).Any())
            {
                Console.WriteLine(Error);
                return GameStateFactory.CreateViewSettingsState();
            }

            GameSettings
                .GetSettings()
                .ChangeGuessNumber(int.Parse(input))
                .Save();
            GameSettings.LoadSettings();

            return GameStateFactory.CreateViewSettingsState();
        }
    }
}