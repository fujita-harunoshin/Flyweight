using Newtonsoft.Json;

namespace Flyweight;

internal class Flyweight(Car car)
{
    private Car _sharedState = car;

    public void Operation(Car uniqueState)
    {
        var s = JsonConvert.SerializeObject(_sharedState);
        var u = JsonConvert.SerializeObject(uniqueState);
        Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
    }
}
