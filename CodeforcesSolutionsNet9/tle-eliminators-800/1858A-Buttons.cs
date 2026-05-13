using System.Globalization;

using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
Console.SetOut(sw);

var sc = new Scanner(Console.OpenStandardInput());

int t = sc.NextInt();

while (t-- > 0)
{
    long a = sc.NextLong();
    long b = sc.NextLong();
    long c = sc.NextLong();

    string answer = (b > a || a == b && c % 2 == 0) ? "Second" : "First";

    sw.WriteLine(answer);
}

Console.Out.Flush();

public class Scanner
{
    private readonly StreamReader _reader;
    private string[] _tokens = [];
    private int _index;

    public Scanner(Stream stream) => _reader = new StreamReader(stream);

    public string Next()
    {
        while (_index >= _tokens.Length)
        {
            var line = _reader.ReadLine();
            if (line == null) return null;
            _tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _index = 0;
        }
        return _tokens[_index++];
    }

    public int NextInt() => int.Parse(Next());
    public long NextLong() => long.Parse(Next());
    public double NextDouble() => double.Parse(Next(), CultureInfo.InvariantCulture);
}