using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Mastermind.GameStates
{
    class MainMenuState : IGameState
    {
        private string Error { get; }
        private string Prompt { get; }
        private IDictionary<MenuOption, Func<IGameState>> OptionStateMap { get; set; }

        public MainMenuState(IDictionary<MenuOption, Func<IGameState>> optionStateMap)
        {
            Error = ConfigurationManager.AppSettings["BadOption"];
            Prompt = ConfigurationManager.AppSettings["MainMenuPrompt"];
            OptionStateMap = new Dictionary<MenuOption, Func<IGameState>>(optionStateMap);
        }

        public IGameState Run()
        {
            Console.WriteLine(Prompt);
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