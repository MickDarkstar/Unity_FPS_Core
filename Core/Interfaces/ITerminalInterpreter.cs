using System.Collections.Generic;

public interface ITerminalInterpreter
{
    List<ITerminalInterpreterResponse> Interpret(string userInput);
}