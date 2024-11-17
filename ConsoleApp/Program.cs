using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp;

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
