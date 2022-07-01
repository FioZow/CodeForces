var wordsCount = int.Parse(Console.ReadLine());
var vocabulery = new List<string>(wordsCount);

for (int i = 0; i < wordsCount; i++)
{
    vocabulery.Add(Console.ReadLine());
}

var requestsCount = int.Parse(Console.ReadLine());

while (requestsCount != 0)
{
    var word = Console.ReadLine();

    Find(word, vocabulery.Where(x => x != word).ToList(), 1);

    requestsCount--;
}

void Find(string word, List<string> list, int index)
{
    var result = list.Where(x => x[x.Length - index] == word[word.Length - index]).ToList();

    if (result.Count == 1)
    {
        Console.WriteLine(result[0]);
    }
    else if (result.Count == 0)
    {
        Console.WriteLine(list[0]);
    }
    else if (result.Count > 1)
    {
        Find(word, result, index + 1);
    }
}