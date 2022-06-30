var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    var filedDimensions = Console.ReadLine().Split(" ");
    var rowsCount = int.Parse(filedDimensions[0]);
    var columnsCount = int.Parse(filedDimensions[1]);

    var field = new List<Point>();

    for (int i = 0; i < rowsCount; i++)
    {
        for (int j = 0; j < columnsCount; j++)
        {
            var ch = Console.ReadKey().KeyChar;
            var point = new Point(j, i, ch == '*');

            field.Add(point);
        }
        Console.ReadKey();
    }

    var pointsCount = field.Count;

    for (int i = 0; i < pointsCount; i++)
    {
        field[i].IsVisited = true;

    }

    foreach (var point in field)
    {
        if (point.IsShip && !point.IsVisited)
        {

        }

        point.IsVisited = true;
    }

    testsCount--;
}

void PrintArray(char[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j]);
        }
        Console.WriteLine();
    }
}

class Ship
{
    public int Size { get; set; }
    public List<Point> Points { get; set; }
}

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsVisited { get; set; }
    public bool IsShip { get; set; }
    public Point(int x, int y, bool isShip)
    {
        X = x;
        Y = y;
        IsVisited = false;
        IsShip = isShip;
    }
}