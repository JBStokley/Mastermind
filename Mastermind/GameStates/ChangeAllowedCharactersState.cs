using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Mastermind.GameStates
{
    class ChangeAllowedCharactersState : IGameState
    {
        private string Error { get; }
        private string Prompt { get; }

        public ChangeAllowedCharactersState()
        {
            Error = ConfigurationManager.AppSettings["ChangeAllowedCharactersError"];
            Prompt = ConfigurationManager.AppSettings["ChangeAllowedCharacters"];
        }

        public IGameState Run()
        {
            Console.WriteLine(Prompt);

            var input = Console.ReadLine().Trim();
            if (input == string.Empty)
            {
                Console.WriteLine(Error);
                return GameStateFactory.CreateViewSettingsState();
            }

            input = new string(new HashSet<char>(input).ToArray()); // Remove Dups
            GameSettings
                .GetSettings()
                .ChangeAllowedCharacter(input)
                .Save();
            GameSettings.LoadSettings();

            return GameStateFactory.CreateViewSettingsState();
        }
    }
}