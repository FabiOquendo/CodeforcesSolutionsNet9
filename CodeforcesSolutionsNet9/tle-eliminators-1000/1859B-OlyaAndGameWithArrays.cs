using System.Globalization;

using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
Console.SetOut(sw);

var sc = new Scanner(Console.OpenStandardInput());

int t = sc.NextInt();

while (t-- > 0)
{
    int n = sc.NextInt();
    var array = new PriorityQueue<long, long>[n];

    for (int i = 0; i < n; i++)
    {
        int m = sc.NextInt();
        array[i] = new PriorityQueue<long, long>();

        for (int j = 0; j < m; j++)
        {
            long a = sc.NextLong();
            array[i].Enqueue(a, a);
        }
    }

    var first = new long[n];
    var seconds = new long[n];
    long minFirst = long.MaxValue;
    long minSeconds = long.MaxValue;

    for (int i = 0; i < n; i++)
    {
        first[i] = array[i].Dequeue();
        seconds[i] = array[i].Dequeue();
        minFirst = Math.Min(minFirst, first[i]);
        minSeconds = Math.Min(minSeconds, seconds[i]);
    }

    long ans = seconds.Sum() + minFirst - minSeconds;

    sw.WriteLine(ans);
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