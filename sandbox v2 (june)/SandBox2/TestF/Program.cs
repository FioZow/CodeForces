var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    Console.ReadLine();

    var inp = Console.ReadLine().Split(" ");

    var coupeCount = int.Parse(inp[0]);
    var requestCount = int.Parse(inp[1]);

    var coupes = new List<Coupe>();

    for (int i = 1; i <= coupeCount * 2; i += 2)
    {
        coupes.Add(new Coupe(new List<Place> { new Place(i), new Place(i + 1) }, i));
    }

    for (int i = 0; i < requestCount; i++)
    {
        var input = Console.ReadLine().Split(" ");

        var requestType = int.Parse(input[0]);

        var requestPlaceNumber = input.Length > 1 ? int.Parse(input[1]) : 0;

        var id = requestPlaceNumber % 2 == 0 ? requestPlaceNumber - 1 : requestPlaceNumber;
        var coupe = coupes.FirstOrDefault(x => x.Id == id);
        var index = requestPlaceNumber % 2 != 0 ? 0 : 1;

        switch (requestType)
        {
            case 1:
                if (coupe.Places[index].IsFree)
                {
                    var place = coupe.Places[index];
                    place.IsFree = false;
                    coupe.Places[index] = place;
                    Console.WriteLine("SUCCESS");
                }
                else
                {
                    Console.WriteLine("FAIL");
                }
                break;

            case 2:
                if (!coupe.Places[index].IsFree)
                {
                    var place = coupe.Places[index];
                    place.IsFree = true;
                    coupe.Places[index] = place;
                    Console.WriteLine("SUCCESS");
                }
                else
                {
                    Console.WriteLine("FAIL");
                }
                break;

            case 3:
                var coupe3 = coupes.FirstOrDefault(x => x.Places.Where(x => x.IsFree == true).Count() == 2);

                if (coupe3 != null)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        var place = coupe3.Places[j];
                        place.IsFree = false;
                        coupe3.Places[j] = place;
                    }
                    Console.WriteLine($"SUCCESS {coupe3.Places[0].Number}-{coupe3.Places[1].Number}");
                }
                else
                {
                    Console.WriteLine("FAIL");
                }
                break;
        }
    }

    testsCount--;
}

public class Coupe
{
    public int Id { get; set; }
    public List<Place> Places { get; set; }

    public Coupe(List<Place> places, int id)
    {
        Places = places;
        Id = id;
    }
}

public struct Place
{
    public bool IsFree { get; set; } = true;
    public int Number { get; set; }

    public Place(int number)
    {
        Number = number;
    }
}