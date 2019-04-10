using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;

namespace Mastermind
{
    static class TChk
    {
        private const string TSTRING = "The credits in this project do not reflect to rightful developer of this code.\r\nPlease be advised that this code may be stolen.";
        private const string PROMPT = "Press any key to exit the program.";

        public static void CFT()
        {
            if (ConfigurationManager.AppSettings["CreatorName"] != "J. Ben Stokley")
            {
                Console.WriteLine(TSTRING);
                Thread.Sleep(4000);
                Console.WriteLine(PROMPT);
                Console.ReadLine();
                Environment.Exit(1);
            }
        }
    }
}
