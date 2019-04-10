using System;
using System.Collections.Generic;
using System.Configuration;

namespace Mastermind.GameStates
{
    class ViewSettingsState : IGameState
    {
        private string Error { get; }
        private string Prompt { get; }
        private IDictionary<MenuOption, Func<IGameState>> OptionStateMap { get; }

        public ViewSettingsState(IDictionary<MenuOption, Func<IGameState>> optionStateMap)
        {
            Error = ConfigurationManager.AppSettings["BadOption"];
            Prompt = ConfigurationManager.AppSettings["SettingsPrompt"];
            OptionStateMap = new Dictionary<MenuOption, Func<IGameState>>(optionStateMap);
        }

        public IGameState Run()
        {
            var settings = GameSettings.GetSettings();
            Console.WriteLine(string.Format(Prompt, settings.AllowedCharacters, settings.CharacterNumber, settings.GuessNumber));
            foreach (var o in OptionStateMap.Keys)
                Console.WriteLine(o.ToString());

            var input = Console.ReadLine().Trim();
            foreach (var o in OptionStateMap.Keys)
                if (o.Matches(input))
                    return OptionStateMap[o]();

            Console.WriteLine(Error);
            return this;
        }
    }
}