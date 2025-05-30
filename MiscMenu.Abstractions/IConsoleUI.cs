namespace MiscMenu.Abstractions
{
    public interface IConsoleUI
    {
        void Clear();
        string GetInput();
        void WriteLine(string message);
        void Write(string message);

    }
}