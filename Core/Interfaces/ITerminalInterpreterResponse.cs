public interface ITerminalInterpreterResponse
{
    public TerminalInterpreterResponseLevel TerminalInterpreterResponseLevel { get; set; }
    public string Message { get; set; }
}
public enum TerminalInterpreterResponseLevel
{
    Info,
    Warning,
    Error
}