using MiscMenu.Abstractions;
using MiscMenu.Helpers;
using MiscMenu.TextService;
using MiscMenu.TicketService;

namespace MiscMenu.Program
{
    internal class Main
    {
        private readonly IConsoleUI _ui;
        private readonly CinemaTickets _ticketService;
        private readonly TextMethods _textService;

        public Main(IConsoleUI ui, CinemaTickets ticketService, TextMethods textService)
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
                UIHelper.UIMenuWrapper(ShowMainMenu, _ui);

                string input = _ui.GetInput();

                switch (input)
                {
                    case MenuHelper.YouthOrRetired:
                        _ticketService.TicketPrice();
                        break;
                    case MenuHelper.Repeat:
                        _textService.Repeat();
                        break;
                    case MenuHelper.ThirdWord:
                        _textService.ThirdWord();
                        break;
                    case MenuHelper.Close:
                        UIHelper.CloseProgram(_ui);
                        return;
                    default:
                        UIHelper.InvalidMenuInput(_ui);
                        break;
                }

            }
            while (true);
        }

        private void ShowMainMenu()
        {
            _ui.WriteLine($"{MenuHelper.YouthOrRetired}. Biobiljetter - Ungdom eller pensionär");
            _ui.WriteLine($"{MenuHelper.Repeat}. Få din input upprepad 10 gånger");
            _ui.WriteLine($"{MenuHelper.ThirdWord}. Vi visar det tredje ordet i en mening");

        }
    }
}
