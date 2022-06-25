var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    Console.ReadLine();
    var tableSize = Console.ReadLine().Split(" ");
    var rowCount = int.Parse(tableSize[0]);
    var columnCount = int.Parse(tableSize[1]);

    var table = new int[rowCount, columnCount];

    for (int i = 0; i < rowCount; i++)
    {
        var row = Console.ReadLine().Split(" ");

        for (int j = 0; j < columnCount; j++)
        {
            table[i, j] = int.Parse(row[j]);
        }
    }

    var clickCount = int.Parse(Console.ReadLine());
    var clickOrder = Console.ReadLine().Split(" ");
    var previousColumn = 0;

    while (clickCount != 0)
    {
        var currentColumn = int.Parse(clickOrder[clickOrder.Length - clickCount]);

        if (currentColumn != previousColumn)
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < rowCount - 1 - i; j++)
                {
                    if (table[j, currentColumn - 1] > table[j + 1, currentColumn - 1])
                    {
                        for (int k = 0; k < columnCount; k++)
                        {
                            var temp = table[j, k];
                            table[j, k] = table[j + 1, k];
                            table[j + 1, k] = temp;
                        }
                    }
                }
            }

            previousColumn = currentColumn;
        }

        clickCount--;
    }


    for (int i = 0; i < rowCount; i++)
    {
        for (int j = 0; j < columnCount; j++)
        {
            Console.Write(table[i, j] + " ");
        }
        Console.WriteLine();
    }

    testsCount--;
}
