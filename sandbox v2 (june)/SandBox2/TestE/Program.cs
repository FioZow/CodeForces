var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    var count = int.Parse(Console.ReadLine());

    var names = new List<string>(count);
    var numbers = new List<string>(count);

    for (int i = 0; i < count; i++)
    {
        var input = Console.ReadLine().Split(" ");

        names.Add(input[0]);
        numbers.Add(input[1]);
    }

    names.Reverse();
    numbers.Reverse();

    var dictLI = new Dictionary<string, List<string>>();

    for (int i = 0; i < count; i++)
    {
        if (dictLI.Keys.Contains(names[i]))
        {
            if (dictLI[names[i]].Count < 5 && !dictLI[names[i]].Contains(numbers[i]))
            {
                dictLI[names[i]].Add(numbers[i]);
            }
        }
        else
        {
            dictLI.Add(names[i], new List<string> { numbers[i] });
        }
    }

    var result = dictLI.OrderBy(x => x.Key);

    foreach (var item in result)
    {
        Console.Write($"{item.Key}: {item.Value.Count}");
        
        foreach (var number in item.Value)
        {
            Console.Write($" {number}");
        }
        Console.WriteLine();
    }

    testsCount--;
}