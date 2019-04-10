using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Mastermind.GameStates
{
    class StartState :IGameState
    {
        private string Welcome { get; }

        public StartState() =>
            Welcome = ConfigurationManager.AppSettings["Welcome"];

        public IGameState Run()
        {
            Console.WriteLine(Welcome);
            return GameStateFactory.CreateMainMenuState();
        }
    }
}
