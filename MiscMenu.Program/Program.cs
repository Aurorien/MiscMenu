using MiscMenu.Abstractions;
using MiscMenu.TextService;
using MiscMenu.TicketService;

namespace MiscMenu.Program
{
    internal class Program
    {
        private static readonly IConsolUI _ui = new ConsolUI();
        private static readonly CinemaTickets _ticketService = new(_ui);
        private static readonly TextMethods _textService = new(_ui);

        static void Main(string[] args)
        {
            Main main = new(_ui, _ticketService, _textService);
            main.Run();
        }
    }
}
