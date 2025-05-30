using MiscMenu.Abstractions;
using MiscMenu.Helpers;

namespace MiscMenu.TicketService
{
    public class CinemaTickets
    {
        private readonly IConsoleUI _ui;

        public CinemaTickets(IConsoleUI ui)
        {
            this._ui = ui;
        }

        private const int _childAgeLimit = 18;
        private const int _seniorAgeLimit = 65;
        private const int _childPrice = 80;
        private const int _seniorPrice = 90;
        private const int _adultPrice = 120;

        public void TicketPrice()
        {
            do
            {
                _ui.Clear();

                _ui.WriteLine("Biorymden --- Prisberäkning för biobiljetter\n");
                UIHelper.UIMenuWrapper(ShowYouthOrRetiredMenu, _ui);

                string input = _ui.GetInput();

                switch (input)
                {
                    case MenuHelper.SingleTicket:
                        CalcSingleTicketPrice();
                        break;
                    case MenuHelper.GroupTicket:
                        CalcGroupTicketPrice();
                        break;
                    case MenuHelper.ReturnToMainMenu:
                        return;
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

        private void ShowYouthOrRetiredMenu()
        {
            _ui.WriteLine($"{MenuHelper.SingleTicket}. Beräkna pris för enkelbiljett");
            _ui.WriteLine($"{MenuHelper.GroupTicket}. Beräkna pris för gruppbiljett");
            _ui.WriteLine($"{MenuHelper.ReturnToMainMenu}. Återgå till huvudmenyn");
        }

        private static (string category, int price) GetPricingInfo(int age)
        {
            if (age < _childAgeLimit) return ("Ungdomspris", _childPrice);
            if (age >= _seniorAgeLimit) return ("Pensionärspris", _seniorPrice);
            return ("Standardpris", _adultPrice);
        }

        private void CalcSingleTicketPrice()
        {
            _ui.Clear();
            _ui.WriteLine("Biorymden --- Enkelbiljett prisberäkning\n\n");
            _ui.WriteLine("För att beräkna priset på en enkelbiljett, ange ålder på besökaren.\n");

            int ageInput = Util.AskForInt("Ange ålder i heltal: ", _ui);
            var (category, price) = GetPricingInfo(ageInput);
            _ui.WriteLine($"\n{category}: {price} kr");

            UIHelper.ReturnToMenu(_ui);
        }

        private void CalcGroupTicketPrice()
        {
            _ui.Clear();
            _ui.WriteLine("Biorymden --- Gruppbiljett prisberäkning\n\n");
            _ui.WriteLine("För att beräkna priset på en gruppbiljett, ange antalet personer i gruppen.\n");
            int groupSize = Util.AskForInt("Antal personer", _ui);
            int totalPrice = 0;

            for (int i = 0; i < groupSize; i++)
            {
                _ui.WriteLine($"\nPerson {i + 1}");
                int ageInput = Util.AskForInt("Ange ålder i heltal", _ui);
                var (_, price) = GetPricingInfo(ageInput);

                totalPrice += price;
            }

            _ui.WriteLine($"\n\nAntal personer i gruppen: {groupSize}");
            _ui.WriteLine($"Totalpris för gruppbiljetten: {totalPrice} kr");
            UIHelper.ReturnToMenu(_ui);
        }
    }
}
