using MiscMenu.Abstractions;

namespace MiscMenu.Helpers
{
    public static class Util

    {
        public static string AskForString(string prompt, IConsoleUI ui)
        {
            bool success = false;
            string answer;

            do
            {
                ui.Write($"{prompt}: ");
                answer = ui.GetInput();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    ui.WriteLine($"Ogiltig inmatning. Inmatningen godtas inte tom eller med endast blanksteg. Försök igen.");
                }
                else
                {
                    success = true;
                }


            } while (!success);

            return answer;
        }

        public static int AskForInt(string prompt, IConsoleUI ui)
        {
            do
            {
                string input = AskForString(prompt, ui);

                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    ui.WriteLine($"Ogiltig inmatning. Du behöver skriva ett positivt heltal. Försök igen.");
                }

            } while (true);
        }
    }
}
