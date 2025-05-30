using MiscMenu.Abstractions;
using MiscMenu.Helpers;

namespace MiscMenu.TicketService
{
    public class CinemaTickets
    {
        private readonly IConsolUI _ui;

        public CinemaTickets(IConsolUI ui)
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
                UIHelpers.UIMenuWrapper(ShowYouthOrRetiredMenu, _ui);

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
                        UIHelpers.CloseProgram(_ui);
                        return;
                    default:
                        UIHelpers.InvalidMenuInput(_ui);
                        break;
                }

            }
            while (true);
        }

        private void ShowYouthOrRetiredMenu()
        {
            _ui.WriteLine($"{MenuHelpers.SingleTicket}. Beräkna pris för enkelbiljett");
            _ui.WriteLine($"{MenuHelpers.GroupTicket}. Beräkna pris för gruppbiljett");
            _ui.WriteLine($"{MenuHelpers.ReturnToMainMenu}. Återgå till huvudmenyn");
        }


        private int GetPriceForAge(int age)
        {
            if (age < _childAgeLimit) return _childPrice;
            if (age >= _seniorAgeLimit) return _seniorPrice;
            return _adultPrice;
        }

        // Alternative solution for CalcSingleTicketPrice
        //private static (string category, int price) GetPricingInfo(int age)
        //{
        //    if (age < _childAgeLimit) return ("Ungdomspris", _childPrice);
        //    if (age >= _seniorAgeLimit) return ("Pensionärspris", _seniorPrice);
        //    return ("Standardpris", _adultPrice);
        //}

        private void CalcSingleTicketPrice()
        {
            _ui.Clear();
            _ui.WriteLine("Biorymden --- Enkelbiljett prisberäkning\n\n");
            _ui.WriteLine("För att beräkna priset på en enkelbiljett, ange ålder på besökaren.\n");

            do
            {
                _ui.WriteLine("Ange ålder i heltal: ");
                string ageInput = _ui.GetInput();


                if (int.TryParse(ageInput, out int age))
                {
                    if (age < _childAgeLimit)
                        _ui.WriteLine($"\nUngdomspris: {_childPrice} kr");

                    else if (age >= _seniorAgeLimit)
                        _ui.WriteLine($"\nPensionärspris: {_seniorPrice} kr");

                    else
                        _ui.WriteLine($"\nStandardpris: {_adultPrice} kr");

                    break;
                }
                else
                    _ui.WriteLine($"Ogiltig inmatning. Du behöver skriva ett positivt heltal. Försök igen.");

            } while (true);


            // Alternative solution for CalcSingleTicketPrice
            //int ageInput = Utils.AskForInt("Ange ålder i heltal: ", _ui);
            //var (category, price) = GetPricingInfo(ageInput);
            //_ui.WriteLine($"\n{category}: {price} kr");

            UIHelpers.ReturnToMenu(_ui);
        }


        private void CalcGroupTicketPrice()
        {
            _ui.Clear();
            _ui.WriteLine("Biorymden --- Gruppbiljett prisberäkning\n\n");
            _ui.WriteLine("För att beräkna priset på en gruppbiljett, ange antalet personer i gruppen.\n");
            int groupSize = Utils.AskForInt("Antal personer", _ui);
            int totalPrice = 0;

            for (int i = 0; i < groupSize; i++)
            {
                _ui.WriteLine($"\nPerson {i + 1}");
                int ageInput = Utils.AskForInt("Ange ålder i heltal", _ui);

                totalPrice += GetPriceForAge(ageInput);
            }

            _ui.WriteLine($"\n\nAntal personer i gruppen: {groupSize}");
            _ui.WriteLine($"Totalpris för gruppbiljetten: {totalPrice} kr");
            UIHelpers.ReturnToMenu(_ui);
        }
    }
}
