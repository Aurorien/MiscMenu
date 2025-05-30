namespace MiscMenu.Abstractions
{
    public class ConsoleUI : IConsoleUI
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public string GetInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }

        public void Clear()
        {
            Console.Clear();
        }
    }

}
