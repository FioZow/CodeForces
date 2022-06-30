var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    var filedDimensions = Console.ReadLine().Split(" ");
    var rowsCount = int.Parse(filedDimensions[0]);
    var columnsCount = int.Parse(filedDimensions[1]);

    var field = new char[rowsCount, columnsCount];

    for (int i = 0; i < rowsCount; i++)
    {
        for (int j = 0; j < columnsCount; j++)
        {
            field[i, j] = Console.ReadKey().KeyChar;
        }
        Console.ReadKey();
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