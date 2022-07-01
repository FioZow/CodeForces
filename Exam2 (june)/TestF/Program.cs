var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    var count = int.Parse(Console.ReadLine());
    var isValid = true;

    var timesDT = new List<double>(count * 2);

    for (int i = 0; i < count; i++)
    {
        if (!isValid)
        {
            Console.ReadLine();
            continue;
        }

        var timesStr = Console.ReadLine().Split("-");

        for (int j = 0; j < 2; j++)
        {
            if (!DateTime.TryParse(timesStr[j], out var t))
            {
                isValid = false;
                break;
            }

            var temp = t.TimeOfDay.TotalSeconds;

            if ( j == 1 && temp < timesDT.Last())
            {
                isValid = false;
                break;
            }
            timesDT.Add(temp);
        }
    }

    timesDT.Sort();

    for (int i = 1; i < count * 2; i++)
    {
        if (timesDT[i] - timesDT[i - 1] < 0)
        {
            isValid = false;
            break;
        }
    }

    if (isValid)
    {
        for (int i = 1; i <= count * 2; i += 2)
        {
            var first = timesDT[i - 1];
            var second = timesDT[i];

            for (int j = i + 1; j < count * 2; j++)
            {
                var current = timesDT[j];

                if (current >= first && current <= second)
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
                break;
        }
        
    }

    if (isValid)
        Console.WriteLine("YES");
    else
        Console.WriteLine("NO");

    testsCount--;
}