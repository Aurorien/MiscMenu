using MiscMenu.Abstractions;
using MiscMenu.Helpers;

namespace MiscMenu
{
    internal class Program
    {
        private static IConsolUI _ui = new ConsolUI();

        static void Main(string[] args)
        {

            bool isValid = false;
            do
            {
                _ui.Clear();

                UIHeader();
                _ui.WriteLine("Huvudmeny\n");
                UIMenuWrapper(ShowMainMenu);

                string input = _ui.GetInput();

                switch (input)
                {
                    case MenuHelpers.YouthOrRetired:
                        TicketPrice();
                        break;
                    case MenuHelpers.Close:
                        CloseProgram();
                        break;
                    default:
                        InvalidMenuInput();
                        break;
                }

            }
            while (!isValid);

        }

        private static void InvalidMenuInput()
        {
            _ui.WriteLine("Invalid option. Press Enter and try again.");
            _ui.GetInput();
        }


        private static void UIHeader()
        {
            _ui.WriteLine("-------------------- Blandad Meny --------------------\n\n");
        }

        private static void UIMenuWrapper(Action showMenu)
        {
            _ui.WriteLine("\nVälj i menyn genom att skriva in en siffra och tryck Enter.\n");
            showMenu();
            _ui.WriteLine($"{MenuHelpers.Close}. Avsluta programmet");

            _ui.Write("\nMenyval: ");
        }

        private static void ShowMainMenu()
        {
            _ui.WriteLine($"{MenuHelpers.YouthOrRetired}. Biobiljetter - Ungdom eller pensionär");
        }



        private static void TicketPrice()
        {
            do
            {
                _ui.Clear();

                UIHeader();
                _ui.WriteLine("Biorymden --- Prisberäkning för biobiljetter\n");
                UIMenuWrapper(ShowYouthOrRetiredMenu);

                string input = _ui.GetInput();

                switch (input)
                {
                    case MenuHelpers.SingleTicket:
                        CalcSingleTicketPrice();
                        break;
                    case MenuHelpers.GroupTicket:
                        CalcGroupTicketPrice();
                        break;
                    case MenuHelpers.ReturnToMainMenu:
                        return;
                    case MenuHelpers.Close:
                        CloseProgram();
                        break;
                    default:
                        InvalidMenuInput();
                        break;
                }

            }
            while (true);
        }

        private static void ShowYouthOrRetiredMenu()
        {
            _ui.WriteLine($"{MenuHelpers.SingleTicket}. Beräkna pris för enkelbiljett");
            _ui.WriteLine($"{MenuHelpers.GroupTicket}. Beräkna pris för gruppbiljett");
            _ui.WriteLine($"{MenuHelpers.ReturnToMainMenu}. Återgå till huvudmenyn");
        }

        private static void CloseProgram()
        {
            _ui.WriteLine("\n\nClosing program...\n\n");
            Environment.Exit(0);
        }

        private static void CalcGroupTicketPrice()
        {
            throw new NotImplementedException();
        }

        private static void CalcSingleTicketPrice()
        {
            throw new NotImplementedException();
        }
    }
}
