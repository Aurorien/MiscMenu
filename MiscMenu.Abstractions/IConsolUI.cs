namespace MiscMenu.Abstractions
{
    public interface IConsolUI
    {
        void Clear();
        string GetInput();
        void WriteLine(string message);
        void Write(string message);

    }
}