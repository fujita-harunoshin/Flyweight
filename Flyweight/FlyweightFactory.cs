namespace Flyweight;

internal class FlyweightFactory
{
    private List<Tuple<Flyweight, string>> flyweights = [];

    public FlyweightFactory(params Car[] args)
    {
        foreach (var arg in args)
        {
            flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(arg), GetKey(arg)));
        }
    }

    public string GetKey(Car key)
    {
        List<string> elements = [];

        elements.Add(key.Model);
        elements.Add(key.Color);
        elements.Add(key.Company);

        if (key.Owner != null && key.Number != null)
        {
            elements.Add(key.Number);
            elements.Add(key.Owner);
        }

        elements.Sort();

        return string.Join("_", elements);
    }

    public Flyweight GetFlyweight(Car sharedState)
    {
        var key = GetKey(sharedState);

        if (!flyweights.Where(t => t.Item2 == key).Any())
        {
            Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
            flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
        }
        else
        {
            Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
        }
        return flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
    }

    public void ListFlyweights()
    {
        var count = flyweights.Count;
        Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
        foreach (var flyweight in flyweights)
        {
            Console.WriteLine(flyweight.Item2);
        }
    }
}
