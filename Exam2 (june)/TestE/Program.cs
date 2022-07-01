var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    var daysCount = int.Parse(Console.ReadLine());

    var report = Console.ReadLine().Split(" ");

    var reportsDone = new List<string>();

    var isValid = true;

    for (int i = 0; i < daysCount; i++)
    {
        var task = report[i];

        if (!reportsDone.Contains(task))
        {
            reportsDone.Add(task);
        }
        else
        {
            isValid = false;
            break;
        }

        var flag = true;
        while (flag)
        {
            if (i + 1 >= daysCount)
            {
                break;
            }
            if (report[i + 1] != report[i])
                flag = false;
            else
                i++;
        }
    }

    Console.WriteLine(isValid ? "YES": "NO");

    testsCount--;
}