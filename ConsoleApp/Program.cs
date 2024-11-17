using System;

namespace ConsoleApp;

public static class Program
{
    public static void Main()
    {
        // Composition Root
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        // var writer = new FileWriter("output.txt");
        var copyProcess = new CopyProcess(reader, writer);

        copyProcess.Execute();

        if (writer is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
