using MiscMenu.Abstractions;
using MiscMenu.Helpers;
using System.Text;

namespace MiscMenu.TextService
{
    public class TextMethods
    {
        private readonly IConsoleUI _ui;

        public TextMethods(IConsoleUI ui)
        {
            this._ui = ui;
        }

        public void ThirdWord()
        {
            _ui.Clear();

            _ui.WriteLine("Vi visar tredje ordet i en mening åt dig.");

            do
            {
                string sentence = Util.AskForString("\nSkriv in meingen på minst tre ord", _ui);
                var words = sentence.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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

            UIHelper.ReturnToMenu(_ui);
        }

        public void Repeat()
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
            UIHelper.ReturnToMenu(_ui);
        }
    }
}
