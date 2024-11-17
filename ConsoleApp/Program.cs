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
        Copy(Target.File);
    }

    private static void Copy(Target target)
    {
        if (target == Target.File)
        {
            File.Initialize("output.txt");
        }

        while (true)
        {
            var readKey = Console.ReadKey(intercept: true);
            if (readKey.Key == ConsoleKey.Escape)
            {
                break;
            }

            switch (target)
            {
                case Target.File:
                    File.Write(readKey.KeyChar);
                    break;
                case Target.Console:
                    Console.Write(readKey.KeyChar);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(target));
            }
        }

        if (target == Target.File)
        {
            File.Dispose();
        }
    }
}
