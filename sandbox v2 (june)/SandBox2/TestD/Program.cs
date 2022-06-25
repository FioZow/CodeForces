var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    var loginsCount = int.Parse(Console.ReadLine());
    var inputList = new List<string>(loginsCount);

    while (loginsCount != 0)
    {
        inputList.Add(Console.ReadLine());
        loginsCount--;
    }

    var loginsSet = new HashSet<string>(loginsCount);

    foreach (var item in inputList)
    {
        if (Validate(item) && loginsSet.Add(item.ToLower()))
            Console.WriteLine("YES");
        else
            Console.WriteLine("NO");
    }
    Console.WriteLine();
    testsCount--;
}


static bool Validate(string login)
{
    if (login == null)
        return false;
    if (login.Length < 2 || login.Length > 24)
        return false;
    if (login.StartsWith("-") || login.Contains(" "))
        return false;

    var chars = login.ToCharArray();

    foreach (var item in chars)
    {
        if (item < 45 || item > 122)
            return false;
        if (item > 45 && item < 48)
            return false;
        if (item > 57 && item < 65)
            return false;
        if (item > 90 && item < 95)
            return false;
        if (item > 95 && item < 97)
            return false;
    }

    return true;
}
