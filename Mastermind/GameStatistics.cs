using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Mastermind
{
    class GameStatistics
    {
        public int Games { get; }
        public int Wins { get; }
        public int Losses { get; }
        public float WinRate { get => Games > 0 ? (float)Wins / Games : 0; }

        public GameStatistics()
        {
        }

        private GameStatistics(int games, int wins, int losses)
        {
            Games = games;
            Wins = wins;
            Losses = losses;
        }

        public GameStatistics AddGames(int games) =>
            new GameStatistics(Games + games, Wins, Losses);

        public GameStatistics AddWins(int wins) =>
            new GameStatistics(Games, Wins + wins, Losses);

        public GameStatistics AddLosses(int losses) =>
            new GameStatistics(Games, Wins, Losses + losses);

        public void Save()
        {
            var statsFile = ConfigurationManager.AppSettings["StatsFile"];

            if (File.Exists(statsFile))
                File.Delete(statsFile);
            
            var doc = new XmlDocument();
            var root = doc.CreateElement("Statistics");
            doc.AppendChild(root);
            
            var gamesElement = doc.CreateElement("Stats");
            var gamesAttribute = doc.CreateAttribute("Name");
            gamesAttribute.Value = "Games";
            gamesElement.Attributes.Append(gamesAttribute);
            gamesElement.InnerText = Games.ToString();

            var winsElement = doc.CreateElement("Stats");
            var winsAttribute = doc.CreateAttribute("Name");
            winsAttribute.Value = "Wins";
            winsElement.Attributes.Append(winsAttribute);
            winsElement.InnerText = Wins.ToString();

            var lossesElement = doc.CreateElement("Stats");
            var lossesAttribute = doc.CreateAttribute("Name");
            lossesAttribute.Value = "Losses";
            lossesElement.Attributes.Append(lossesAttribute);
            lossesElement.InnerText = Losses.ToString();

            root.AppendChild(gamesElement);
            root.AppendChild(winsElement);
            root.AppendChild(lossesElement);

            doc.Save(statsFile);
        }

        public static GameStatistics GetStatistics() 
        {
            if (instance is null)
                LoadStatistics();
            return instance;
        }

        public static void LoadStatistics()
        {
            var statsFile = ConfigurationManager.AppSettings["StatsFile"];

            if (!File.Exists(statsFile))
            {
                instance = new GameStatistics();
                return;
            }

            int games = 0, 
                wins = 0, 
                losses = 0;

            var values = XElement
                .Load(statsFile)
                .Descendants("Stats")
                .Select(e => new Tuple<string, string>(e.Attribute("Name").Value, e.Value));

            foreach (var v in values)
            {
                switch (v.Item1)
                {
                    case ("Games"):
                        games = int.Parse(v.Item2);
                        break;
                    case ("Wins"):
                        wins = int.Parse(v.Item2);
                        break;
                    case ("Losses"):
                        losses = int.Parse(v.Item2);
                        break;
                }
            }

            instance = new GameStatistics(games, wins, losses);
        }

        private static GameStatistics instance;
    }
}
