var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    var numbers = Console.ReadLine().Split(" ");

    var a = int.Parse(numbers[0]);
    var b = int.Parse(numbers[1]);

    Console.WriteLine(a + b);

    testsCount--;
}

