// Standar template

using System.Globalization;

// Optimized Fast I/O: AutoFlush = false prevents slow system calls on every write
using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
Console.SetOut(sw);

// Fast Scanner initialization for token-based reading
var sc = new Scanner(Console.OpenStandardInput());

int t = sc.NextInt();
while (t-- > 0)
{
    long n = sc.NextLong();

    // Logic here

    sw.WriteLine(n);
}

// Manually flush the buffer to ensure all data is written to standard output
Console.Out.Flush();

// Scanner class for quickly reading tokens
public class Scanner
{
    private readonly StreamReader _reader;
    private string[] _tokens = [];
    private int _index;

    public Scanner(Stream stream) => _reader = new StreamReader(stream);

    public string Next()
    {
        // Refill the token array if it's empty or fully consumed
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

    // InvariantCulture ensures consistent double parsing regardless of regional settings
    public double NextDouble() => double.Parse(Next(), CultureInfo.InvariantCulture);
}