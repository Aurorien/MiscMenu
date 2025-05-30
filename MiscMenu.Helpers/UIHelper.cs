using MiscMenu.Abstractions;

namespace MiscMenu.Helpers
{
    public static class UIHelper
    {
        public static void UIMenuWrapper(Action showMenu, IConsoleUI ui)
        {
            ui.WriteLine("\nVälj i menyn genom att skriva in en siffra och tryck Enter.\n");
            showMenu();
            ui.WriteLine($"{MenuHelper.Close}. Avsluta programmet");
            ui.Write("\nMenyval: ");
        }

        public static void InvalidMenuInput(IConsoleUI ui)
        {
            ui.WriteLine("Ogiltig inmatning. Tryck Enter och försök igen.");
            ui.GetInput();
        }

        public static void ReturnToMenu(IConsoleUI ui)
        {
            ui.WriteLine("\n\n\nTryck Enter för att återgå till menyn...");
            ui.GetInput();
        }

        public static void CloseProgram(IConsoleUI ui)
        {
            ui.WriteLine("\n\nAvslutar programmet...\n\n");
            Environment.Exit(0);
        }
    }
}
