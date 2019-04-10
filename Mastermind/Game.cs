using Mastermind.Extensions;
using Mastermind.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mastermind
{
    class Game
    {
        public int CurrentGuess { get; private set; }
        public int GuessNumber { get; }
        public string TrueString { get; }
        public bool Success { get; private set; }

        private Game(string trueString, int guessNumber)
        {
            TrueString = trueString;
            GuessNumber = guessNumber;
            CurrentGuess = 0;
        }

        public Either<Error,IGuessResult> CheckGuess(Guess guess)
        {
            if (guess.GuessString == TrueString)
            {
                Success = true;
                return new SuccessGuessResult(TrueString, GuessNumber, CurrentGuess);
            }
            if (!IsValidLength(guess.GuessString))
                return new InvalidGuessLengthError(guess.GuessString);
            if (!IsValidCharacters(guess.GuessString))
                return new InvalidGuessCharactersError(guess.GuessString);

            List<int> exactIndecies = new List<int>();
            Dictionary<int, IEnumerable<int>> closeIndexMap = new Dictionary<int, IEnumerable<int>>();
            
            for (var i = 0; i < TrueString.Length;i++)
            {
                if (guess.GuessString[i] == TrueString[i])
                    exactIndecies.Add(i);
                else if (TrueString.Contains(guess.GuessString[i]))
                    closeIndexMap.Add(i, TrueString.FindAllIndecies(guess.GuessString[i]));
            }
            CurrentGuess++;

            List<int> closeIndecies = new List<int>();
            foreach (var v in closeIndexMap.Values)
                closeIndecies.AddRange(
                    v.Where(i => !exactIndecies.Contains(i) && !closeIndecies.Contains(i))
                    );

            return new NormalGuessResult(exactIndecies.Count(), closeIndecies.Count());
        }
        
        private bool IsValidCharacters(string guessString) =>
            GameSettings.GetSettings().AllowedCharacters.ContainsAll(guessString);

        private bool IsValidLength(string guessString) =>
            guessString.Length == GameSettings.GetSettings().CharacterNumber;

        public static Game NewGame()
        {
            var settings = GameSettings.GetSettings();

            var rand = new Random((int)DateTime.Now.TimeOfDay.TotalMilliseconds);
            var trueString = "";
            for (var i = 0; i < settings.CharacterNumber; i++)
                trueString += settings.AllowedCharacters[rand.Next(0, settings.AllowedCharacterNumber)];

            instance = new Game(trueString, settings.GuessNumber);
            return instance;
        }

        public static Game GetGame()
        {
            if (instance is null)
                return NewGame();
            return instance;
        }

        private static Game instance;
    }
}
