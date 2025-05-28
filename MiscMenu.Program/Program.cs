using MiscMenu.Abstractions;
using MiscMenu.Helpers;
using System.Text;

namespace MiscMenu
{
    internal class Program
    {
        private static IConsolUI _ui = new ConsolUI();

        private const int _childAgeLimit = 18;
        private const int _seniorAgeLimit = 65;
        private const int _childPrice = 80;
        private const int _seniorPrice = 90;
        private const int _adultPrice = 120;



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
                    case MenuHelpers.Repeat:
                        Repeat();
                        break;
                    case MenuHelpers.ThirdWord:
                        ThirdWord();
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

        private static void ThirdWord()
        {
            _ui.Clear();

            _ui.WriteLine("Vi visar tredje ordet i en mening åt dig.");


            do
            {
                string sentence = Utils.AskForString("\nSkriv in meingen på minst tre ord", _ui);
                var words = sentence.Split(' ');

                if (words.Length < 3)
                {
                    _ui.WriteLine("Du behöver skriva in minst tre ord. Försök igen.");
                }
                else
                {
                    _ui.WriteLine($"\n\nTredje ordet i meningen är: {words[2]}");
                    break;
                }
            } while (true);

            _ui.WriteLine("\n\nTryck Enter för att återgå till menyn.");
            _ui.GetInput();

        }

        private static void Repeat()
        {
            _ui.Clear();

            _ui.WriteLine("Få din input upprepad 10 gånger!\n");
            _ui.Write("Skriv in en text som du vill upprepa: ");
            string input = _ui.GetInput();
            var sb = new StringBuilder(); // Using Stringbuilder for optimal performance (reducing _ui.Write calls and consuming less memory by using mutable object)

            for (int i = 0; i < 10; i++)
            {
                sb.Append($"{i + 1}. {input}");
                if (i < 9) sb.Append(", ");
            }

            _ui.Write(sb.ToString());

            _ui.WriteLine("\n\nTryck Enter för att återgå till menyn.");
            _ui.GetInput();
        }

        private static int GetPriceForAge(int age)
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
            _ui.WriteLine($"{MenuHelpers.Repeat}. Få din input upprepad 10 gånger");
            _ui.WriteLine($"{MenuHelpers.ThirdWord}. Vi visar det tredje ordet i en mening");

        }



        private static void TicketPrice()
        {
            do
            {
                _ui.Clear();

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

            _ui.Clear();
            _ui.WriteLine("Biorymden --- Gruppbiljett prisberäkning\n\n");
            _ui.WriteLine("För att beräkna priset på en gruppbiljett, ange antalet personer i gruppen.\n");
            int groupSize = Utils.AskForInt("Antal personer: ", _ui);
            int totalPrice = 0;

            for (int i = 0; i < groupSize; i++)
            {
                _ui.WriteLine($"\nPerson {i + 1}");
                int ageInput = Utils.AskForInt("Ange ålder i heltal: ", _ui);

                totalPrice += GetPriceForAge(ageInput);

            }
            _ui.WriteLine($"\n\nAntal personer i gruppen: {groupSize}");
            _ui.WriteLine($"Totalpris för gruppbiljetten: {totalPrice} kr");
            _ui.WriteLine("\n\nTryck Enter för att återgå till menyn.");
            _ui.GetInput();

        }

        private static void CalcSingleTicketPrice()
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
                    {
                        _ui.WriteLine($"\nUngdomspris: {_childPrice} kr");
                    }

                    else if (age >= _seniorAgeLimit)
                    {
                        _ui.WriteLine($"\nPensionärspris: {_seniorPrice} kr");
                    }

                    else
                    {
                        _ui.WriteLine($"\nStandardpris: {_adultPrice} kr");
                    }
                    break;
                }
                else
                {
                    _ui.WriteLine($"Ogiltig inmatning. Du behöver skriva ett positivt heltal. Försök igen.");
                }

            } while (true);


            // Alternative solution for CalcSingleTicketPrice
            //int ageInput = Utils.AskForInt("Ange ålder i heltal: ", _ui);
            //var (category, price) = GetPricingInfo(ageInput);
            //_ui.WriteLine($"\n{category}: {price} kr");

            _ui.WriteLine("\n\nTryck Enter för att återgå till menyn.");
            _ui.GetInput();
        }
    }
}
