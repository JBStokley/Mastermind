using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind.GameStates
{
    static class GameStateFactory
    {
        public static MainMenuState CreateMainMenuState() =>
            new MainMenuState(
                new Dictionary<MenuOption, Func<IGameState>>()
                {
                    { new MenuOption("n", "New Game") , () => new NewGameState() },
                    { new MenuOption("i", "Instructions") , () => new InstructionsState() },
                    { new MenuOption("s", "Settings") , () => CreateViewSettingsState() },
                    { new MenuOption("t", "Game Statistics") , () => new StatisticsState() },
                    { new MenuOption("c", "Credits") , () => new CreditsState() },
                    { new MenuOption("q", "Quit") , () => new QuitState() }
                }
            );

        public static ViewSettingsState CreateViewSettingsState() =>
            new ViewSettingsState(
                new Dictionary<MenuOption, Func<IGameState>>()
                {
                    { new MenuOption("a","Change Allowed Characters"), () => new ChangeAllowedCharactersState() },
                    { new MenuOption("n","Change Number of Characters"), () => new ChangeCharacterNumberState() },
                    { new MenuOption("g","Change Number of Guesses"), () => new ChangeGuessNumberState() },
                    { new MenuOption("r","Reset Settings to Default"), () => new ResetSettingsState()},
                    { new MenuOption("m","Return to Main Menu"), () => CreateMainMenuState() },
                }
            );
    }
}
