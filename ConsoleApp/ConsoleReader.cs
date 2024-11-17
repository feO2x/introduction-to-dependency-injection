using System;


namespace ConsoleApp;

public sealed class ConsoleReader : IReader
{
    public ReadResult Read()
    {
        var readKey = Console.ReadKey(intercept: true);
        return new ReadResult(readKey.KeyChar, readKey.Key == ConsoleKey.Escape);
    }
}
