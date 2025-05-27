using MiscMenu.Helpers;

namespace MiscMenu
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool isValid = false;
            do
            {
                Console.WriteLine("-------------------- Misc Menu --------------------\n");
                Console.WriteLine("Please select an option from the menu below:\n");
                Console.WriteLine($"{MenuHelpers.Close}) Close program");

                string input = Console.ReadLine() ?? string.Empty;
                switch (input)
                {
                    case MenuHelpers.Close:
                        Console.WriteLine("Closing program...");
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

            }
            while (!isValid);
            Environment.Exit(0);

        }
    }
}
