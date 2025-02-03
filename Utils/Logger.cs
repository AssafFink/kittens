namespace AssafFinkelshtein;

public class Logger
{
    private readonly string _fileName = Path.Combine("Logs", "Logger.txt");

    public Logger()
    {
        if (!Directory.Exists("Logs")) Directory.CreateDirectory("Logs");
    }

    public async Task Log(string message)
    {
        using StreamWriter _writer = new StreamWriter(_fileName, true);
        await _writer.WriteLineAsync(DateTime.Now + "\t" + message);
    }
}
