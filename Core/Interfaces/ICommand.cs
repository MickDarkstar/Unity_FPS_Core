public interface ICommand
{
    string Message { get; }

    bool CanProcess(string args = null);

    void Process(string args = null);
}