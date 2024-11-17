using System;
using System.IO;


namespace ConsoleApp;

public sealed class FileWriter : IWriter, IDisposable
{
    private readonly StreamWriter _streamWriter;

    public FileWriter(string path)
    {
        _streamWriter = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
    }

    public void Write(char value) => _streamWriter.Write(value);

    public void Dispose() => _streamWriter.Dispose();
}
