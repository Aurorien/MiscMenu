using System;

namespace MiscMenu.Abstractions
{
    public class ConsolUI : IConsolUI
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
