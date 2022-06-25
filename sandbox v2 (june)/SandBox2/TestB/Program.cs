var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    var productsCount = int.Parse(Console.ReadLine());
    var prices = Console.ReadLine().Split(" ").GroupBy(x => x);
    var sum = 0;

    foreach (var price in prices)
    {
        var count = price.Count();
        sum += (count - count / 3) * int.Parse(price.Key);
    }

    Console.WriteLine(sum);

    testsCount--;
}
