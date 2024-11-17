using System;


namespace ConsoleApp;

public sealed class ConsoleWriter : IWriter
{
    public void Write(char value) => Console.Write(value);
}
