var testsCount = int.Parse(Console.ReadLine());

while (testsCount != 0)
{
    Console.ReadLine();

    var modulesCount = int.Parse(Console.ReadLine());

    var modules = new List<Module>();

    for (int i = 0; i < modulesCount; i++)
    {
        var input = Console.ReadLine().Split(" ");
        var dependences = new List<string>(input.Length - 1);

        for (int j = 1; j < input.Length; j++)
        {
            dependences.Add(input[j]);
        }

        modules.Add(new Module(input[0].TrimEnd(':'), dependences));
    }

    var requestsCount = int.Parse(Console.ReadLine());

    for (int i = 0; i < requestsCount; i++)
    {
        var request = Console.ReadLine();
        var result = Compilate(request, modules);

        Console.Write(result.Count);

        foreach (var item in result)
        {
            Console.Write(" " + item);
        }
        Console.WriteLine();
    }

    testsCount--;
}

List<string> Compilate(string request, List<Module> modules)
{
    var compilatedModules = new List<string>();

    var module = modules.SingleOrDefault(x => x.Name == request);
    if (!module.isCompilated)
    {
        foreach (var dependence in module.Dependences)
        {
            var add = Compilate(dependence, modules);
            compilatedModules.AddRange(add);
        }

        compilatedModules.Add(request);
        module.isCompilated = true;
    }
    return compilatedModules;
}

class Module
{
    public string Name { get; set; }
    public bool isCompilated { get; set; }
    public List<string> Dependences { get; set; }


    public Module(string name, List<string> dependences)
    {
        Name = name;
        Dependences = dependences;
    }
}