using System.Globalization;

using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
Console.SetOut(sw);

var sc = new Scanner(Console.OpenStandardInput());

int t = sc.NextInt();

while (t-- > 0)
{
    long n = sc.NextLong();
    long p = sc.NextLong();

    var a = new List<long>();
    var pq = new PriorityQueue<(long, long), long>();

    for (int i = 0; i < n; i++)
    {
        a.Add(sc.NextLong());
    }

    for (int i = 0; i < n; i++)
    {
        long b = sc.NextLong();
        pq.Enqueue((a[i], b), b);
    }

    long ans = p;
    long visited = 1;

    while (visited < n)
    {
        var resident = pq.Dequeue();
        long canShare = resident.Item1;
        long cost = resident.Item2;

        long share = (cost < p) ? Math.Min(canShare, n - visited) : n - visited;
        cost = (cost < p) ? cost : p;

        ans += (share * cost);
        visited += share;
    }

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