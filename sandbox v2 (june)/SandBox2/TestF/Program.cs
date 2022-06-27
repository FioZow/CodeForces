var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    Console.ReadLine();

    var inp = Console.ReadLine().Split(" ");

    var coupeCount = int.Parse(inp[0]);
    var requestCount = int.Parse(inp[1]);

    var vagon = new Vagon();
    vagon.Coupes = new List<Coupe>();

    for (int i = 1; i <= coupeCount; i += 2)
    {
        vagon.Coupes.Add(new Coupe(new List<Place> { new Place(i), new Place(i + 1) }, i));
    }

    for (int i = 0; i < requestCount; i++)
    {
        var input = Console.ReadLine().Split(" ");

        var requestType = int.Parse(input[0]);

        var requestPlaceNumber = input.Length > 1 ? int.Parse(input[1]) : 0;

        switch (requestType)
        {

            case 1:
                var id = requestPlaceNumber % 2 == 0 ? requestPlaceNumber - 1 : requestPlaceNumber;

                var placeToBuy = vagon.Coupes.FirstOrDefault(x => x.Id == id).Places.FirstOrDefault(x => x.Number == requestPlaceNumber);

                if (placeToBuy.IsFree)
                {
                    placeToBuy.IsFree = false;
                    Console.WriteLine("SUCCESS");
                }
                else
                {
                    Console.WriteLine("FAIL");
                }

                break;
            case 2:
                var id2 = requestPlaceNumber % 2 == 0 ? requestPlaceNumber - 1 : requestPlaceNumber;

                var placeToFree = vagon.Coupes.FirstOrDefault(x => x.Id == id2).Places.FirstOrDefault(x => x.Number == requestPlaceNumber);

                if (!placeToFree.IsFree)
                {
                    placeToFree.IsFree = true;
                    Console.WriteLine("SUCCESS");
                }
                else
                {
                    Console.WriteLine("FAIL");
                }

                break;
            case 3:
                var coupe = vagon.Coupes.FirstOrDefault(x => x.Places.Where(x => x.IsFree == true).Count() == 2);

                if (coupe != null)
                {
                    foreach (var item in coupe.Places)
                    {
                        item.IsFree = false;
                    }
                    Console.WriteLine($"SUCCESS {coupe.Places[0].Number}-{coupe.Places[1].Number}");
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

public class Vagon
{
    public List<Coupe> Coupes { get; set; }
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

public class Place
{
    public bool IsFree { get; set; } = true;
    public int Number { get; set; }

    public Place(int number)
    {
        Number = number;
    }
}