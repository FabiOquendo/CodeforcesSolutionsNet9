using System.Globalization;

using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
Console.SetOut(sw);

var sc = new Scanner(Console.OpenStandardInput());

int t = sc.NextInt();

while (t-- > 0)
{
    int n = sc.NextInt();
    int k = sc.NextInt();

    int answer = 5;
    int product = 1;

    int [] array = new int[n];

    for(int i = 0; i < n; i++)
    {
        int a = sc.NextInt();
        array[i] = a; 
        product *= a;
        answer = Math.Min(answer, (a % k == 0) ? 0 : k - (a % k));
    }

    int pairs = 0;
    if (k == 4)
    {
        for (int i = 0; i < n; i++)
        {
            pairs += (array[i] % 2 == 0) ? 1 : 0;
        }

        answer = Math.Min(answer, (pairs == 0) ? 2 : (pairs == 1) ? 1 : 0);
    }

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