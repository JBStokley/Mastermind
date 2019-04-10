using Mastermind.GameStates;
using System;

namespace Mastermind
{
    class Program
    {
        public static IGameState State { get; set; }

        static void Main(string[] args)
        {
            TChk.CFT();
            State = new StartState();
            while (true)
                State = State.Run();
        }
    }
}
