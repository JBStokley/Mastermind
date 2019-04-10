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
    class GameSettings
    {
        public string AllowedCharacters { get; } = "123456";
        public int CharacterNumber { get; } = 4;
        public int GuessNumber { get; } = 10;
        public int AllowedCharacterNumber { get => AllowedCharacters.Count(); }

        public GameSettings()
        {
        }

        private GameSettings(string allowedCharacters, int characterNumber, int guessNumber)
        {
            AllowedCharacters = allowedCharacters;
            CharacterNumber = characterNumber;
            GuessNumber = guessNumber;
        }

        public GameSettings ChangeAllowedCharacter(string allowedCharacters) =>
            new GameSettings(allowedCharacters, CharacterNumber, GuessNumber);

        public GameSettings ChangeCharacterNumber(int characterNumber) =>
            new GameSettings(AllowedCharacters, characterNumber, GuessNumber);

        public GameSettings ChangeGuessNumber(int guessNumber) =>
            new GameSettings(AllowedCharacters, CharacterNumber, guessNumber);

        public void Save()
        {
            var settingsFile = ConfigurationManager.AppSettings["SettingsFile"];

            if (File.Exists(settingsFile))
                File.Delete(settingsFile);

            var doc = new XmlDocument();
            var root = doc.CreateElement("Statistics");
            doc.AppendChild(root);

            var allowedCharactersElement = doc.CreateElement("Setting");
            var allowedCharactersAttribute = doc.CreateAttribute("Name");
            allowedCharactersAttribute.Value = "AllowedCharacters";
            allowedCharactersElement.Attributes.Append(allowedCharactersAttribute);
            allowedCharactersElement.InnerText = AllowedCharacters;

            var characterNumberElement = doc.CreateElement("Setting");
            var characterNumberAttribute = doc.CreateAttribute("Name");
            characterNumberAttribute.Value = "CharacterNumber";
            characterNumberElement.Attributes.Append(characterNumberAttribute);
            characterNumberElement.InnerText = CharacterNumber.ToString();

            var guessNumberElement = doc.CreateElement("Setting");
            var guessNumberAttribute = doc.CreateAttribute("Name");
            guessNumberAttribute.Value = "GuessNumber";
            guessNumberElement.Attributes.Append(guessNumberAttribute);
            guessNumberElement.InnerText = GuessNumber.ToString();

            root.AppendChild(allowedCharactersElement);
            root.AppendChild(characterNumberElement);
            root.AppendChild(guessNumberElement);

            doc.Save(settingsFile);
        }

        public static GameSettings GetSettings()
        {
            if (instance is null)
                LoadSettings();
            return instance;
        }

        public static void LoadSettings()
        {
            var settingsFile = ConfigurationManager.AppSettings["SettingsFile"];

            if (!File.Exists(settingsFile))
            {
                instance = new GameSettings();
                return;
            }

            string allowedCharacters = "123456";
            int characterNumber = 4,
                guessNumber = 6;

            var values = XElement
                .Load(settingsFile)
                .Descendants("Setting")
                .Select(e => new Tuple<string, string>(e.Attribute("Name").Value, e.Value));

            foreach (var v in values)
            {
                switch (v.Item1)
                {
                    case ("AllowedCharacters"):
                        allowedCharacters = v.Item2;
                        break;
                    case ("CharacterNumber"):
                        characterNumber = int.Parse(v.Item2);
                        break;
                    case ("GuessNumber"):
                        guessNumber = int.Parse(v.Item2);
                        break;
                }
            }

            instance = new GameSettings(allowedCharacters, characterNumber, guessNumber);
        }

        private static GameSettings instance;
    }
}
