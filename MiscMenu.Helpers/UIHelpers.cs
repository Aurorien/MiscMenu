using MiscMenu.Abstractions;
using System;

namespace MiscMenu.Helpers
{
    public static class UIHelpers
    {
        public static void UIMenuWrapper(Action showMenu, IConsolUI ui)
        {
            ui.WriteLine("\nVälj i menyn genom att skriva in en siffra och tryck Enter.\n");
            showMenu();
            ui.WriteLine($"{MenuHelpers.Close}. Avsluta programmet");
            ui.Write("\nMenyval: ");
        }

        public static void InvalidMenuInput(IConsolUI ui)
        {
            ui.WriteLine("Ogiltig inmatning. Tryck Enter och försök igen.");
            ui.GetInput();
        }

        public static void ReturnToMenu(IConsolUI ui)
        {
            ui.WriteLine("\n\n\nTryck Enter för att återgå till menyn...");
            ui.GetInput();
        }

        public static void CloseProgram(IConsolUI ui)
        {
            ui.WriteLine("\n\nAvslutar programmet...\n\n");
            Environment.Exit(0);
        }
    }
}
