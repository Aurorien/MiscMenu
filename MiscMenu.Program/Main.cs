using MiscMenu.Abstractions;
using MiscMenu.Helpers;
using MiscMenu.TextService;
using MiscMenu.TicketService;

namespace MiscMenu.Program
{
    internal class Main
    {
        private readonly IConsolUI _ui;
        private readonly CinemaTickets _ticketService;
        private readonly TextMethods _textService;

        public Main(IConsolUI ui, CinemaTickets ticketService, TextMethods textService)
        {
            this._ui = ui;
            this._ticketService = ticketService;
            this._textService = textService;
        }

        public void Run()
        {
            do
            {
                _ui.Clear();

                _ui.WriteLine("-------------------- Blandad Meny --------------------\n\n");
                _ui.WriteLine("Huvudmeny\n");
                UIHelpers.UIMenuWrapper(ShowMainMenu, _ui);

                string input = _ui.GetInput();

                switch (input)
                {
                    case MenuHelpers.YouthOrRetired:
                        _ticketService.TicketPrice();
                        break;
                    case MenuHelpers.Repeat:
                        _textService.Repeat();
                        break;
                    case MenuHelpers.ThirdWord:
                        _textService.ThirdWord();
                        break;
                    case MenuHelpers.Close:
                        UIHelpers.CloseProgram(_ui);
                        return;
                    default:
                        UIHelpers.InvalidMenuInput(_ui);
                        break;
                }

            }
            while (true);
        }

        private void ShowMainMenu()
        {
            _ui.WriteLine($"{MenuHelpers.YouthOrRetired}. Biobiljetter - Ungdom eller pensionär");
            _ui.WriteLine($"{MenuHelpers.Repeat}. Få din input upprepad 10 gånger");
            _ui.WriteLine($"{MenuHelpers.ThirdWord}. Vi visar det tredje ordet i en mening");

        }
    }
}
