using System;
using System.IO;


namespace ConsoleApp;

public static class File
{
    private static StreamWriter? streamWriter;

    public static void Initialize(string path)
    {
        streamWriter = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
    }

    public static void Write(char value)
    {
        if (streamWriter is null)
        {
            throw new InvalidOperationException("File stream is not initialized.");
        }

        streamWriter.Write(value);
    }
    
    public static void Dispose()
    {
        streamWriter?.Close();
        streamWriter = null;
    }
}

public enum Target
{
    Console,
    File
}

public static class Program
{
    public static void Main()
    {
        Copy();
    }

    private static void Copy()
    {
        while (true)
        {
            var readKey = Console.ReadKey(intercept: true);
            if (readKey.Key == ConsoleKey.Escape)
            {
                break;
            }

            Console.Write(readKey.KeyChar);
        }
    }
}
