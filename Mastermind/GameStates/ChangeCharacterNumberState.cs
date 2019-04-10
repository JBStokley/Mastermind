using System;
using System.Configuration;
using System.Linq;

namespace Mastermind.GameStates
{
    class ChangeCharacterNumberState : IGameState
    {
        private string Error { get; }
        private string Prompt { get; }

        public ChangeCharacterNumberState()
        {
            Error = ConfigurationManager.AppSettings["ChangeCharacterNumberError"];
            Prompt = ConfigurationManager.AppSettings["ChangeCharacterNumber"];
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
                .ChangeCharacterNumber(int.Parse(input))
                .Save();
            GameSettings.LoadSettings();

            return GameStateFactory.CreateViewSettingsState();
        }
    }
}