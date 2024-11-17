using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

public static class Program
{
    public static void Main()
    {
        // Composition Root
        using var serviceProvider = new ServiceCollection()
            .AddTransient<IReader, ConsoleReader>()
            .AddTransient<IWriter, ConsoleWriter>()
            // .AddTransient<IWriter, FileWriter>()
            .AddTransient<CopyProcess>()
            .BuildServiceProvider();
        
        var copyProcess = serviceProvider.GetRequiredService<CopyProcess>();
        copyProcess.Execute();
    }
}
