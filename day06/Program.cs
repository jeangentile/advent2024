using SharedParts;

Console.WriteLine("Hello, World!");


var j = new Day6Part1();
var result = await j.SolveAsync(new StreamReader("c:\\dev\\advent2024\\advent2024\\day06\\input-test.txt"));
Console.WriteLine(result);

public class Day6Part1
{
    private int _width;
    private int _height;
    private char[,] _map;
    private Point _startingPoint;
    public async Task<string> SolveAsync(StreamReader inputReader)
    {
        List<string> lines = new();
        while (await inputReader.ReadLineAsync() is { } line)
        {
            _width = line.Length;
            _height++;

            lines.Add(line);
        }

        _map = new char[_width, _height];
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _map[x, y] = lines[y][x];
                if (_map[x, y] == '^')
                {
                    _startingPoint = new Point(x, y);
                }
            }
        }

        return CountSteps(_startingPoint).ToString();
    }

     private int CountSteps(Point start)
    {
        HashSet<Point> visited = new();

        var currentDirection = new Point(0, -1);
        var currentPoint = start;
        while (true)
        {
            visited.Add(currentPoint);
            var nextPosition = currentPoint + currentDirection;
            if (IsOutOfBounds(nextPosition))
            {
                break;
            }

            if (_map[nextPosition.X, nextPosition.Y] == '#')
            {
                // Turn right
                currentDirection = new Point(-currentDirection.Y, currentDirection.X);
                nextPosition = currentPoint + currentDirection;
            }

            if (IsOutOfBounds(nextPosition))
            {
                break;
            }

            currentPoint = nextPosition;
        }

        return visited.Count;
    }

    private bool IsOutOfBounds(Point position)
    {
        return position.X < 0 || position.Y < 0 || position.X >= _width || position.Y >= _height;
    }

}

public class Day6Part2
{
    private int _width;
    private int _height;
    private char[,] _map;
    private Point _startingPoint;
    public async Task<string> SolveAsync(StreamReader inputReader)
    {
        List<string> lines = new();
        while (await inputReader.ReadLineAsync() is { } line)
        {
            _width = line.Length;
            _height++;

            lines.Add(line);
        }

        _map = new char[_width, _height];
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _map[x, y] = lines[y][x];
                if (_map[x, y] == '^')
                {
                    _startingPoint = new Point(x, y);
                }
            }
        }

        return CountSteps(_startingPoint).ToString();
    }

     private int CountSteps(Point start)
    {
        HashSet<Point> visited = new();

        var currentDirection = new Point(0, -1);
        var currentPoint = start;
        while (true)
        {
            visited.Add(currentPoint);
            var nextPosition = currentPoint + currentDirection;
            if (IsOutOfBounds(nextPosition))
            {
                break;
            }

            if (_map[nextPosition.X, nextPosition.Y] == '#')
            {
                // Turn right
                currentDirection = new Point(-currentDirection.Y, currentDirection.X);
                nextPosition = currentPoint + currentDirection;
            }

            if (IsOutOfBounds(nextPosition))
            {
                break;
            }

            currentPoint = nextPosition;
        }

        return visited.Count;
    }

    private bool IsOutOfBounds(Point position)
    {
        return position.X < 0 || position.Y < 0 || position.X >= _width || position.Y >= _height;
    }

}

