using CA24111202;
using System.Net.Http.Headers;

List<Fish> fishlist = [];
string[] pfs = ["catfish", "shark", "tuna", "salamon", "cod", "eel", "herring", "mackerel", "bass", "squid", ];
string[] hfs = ["bream",  "clowfish",  "crap", "parrotfish", "tench", ];

for (int i = 0; i < 100; i++)
{
    bool predator = Random.Shared.Next(100) < 10;
    string[] sfs = predator ? pfs : hfs;

    fishlist.Add(new(
        species: sfs[Random.Shared.Next(sfs.Length)],
        predator: predator,
        weight: Random.Shared.Next(5, 401) / 10f,
        top: Random.Shared.Next(401),
        depth: Random.Shared.Next(10, 401)));

    //Console.ForegroundColor = fishlist.Last().Predator
    //    ? ConsoleColor.Red
    //    : ConsoleColor.Green;

    //Console.WriteLine(fishlist.Last());
}

Console.WriteLine($"carnivore fish count: {fishlist.Count(f => f.Predator)}");
Console.WriteLine($"herbivore fish count: {fishlist.Count(f => !f.Predator)}");
Console.WriteLine($"largest fish weight: {fishlist.Max(f => f.Weight)}");
Console.WriteLine($"fish count on 1.1m: {fishlist.Count(f => f.Top <= 110 && 110 <= f.Bottom)}");

for (int i = 0; i < 100; i++)
{
    Console.WriteLine($"--- round {i+1:000} ---");

    int aIndex = Random.Shared.Next(fishlist.Count);

    int bIndex = aIndex;
    while (aIndex == bIndex)
        bIndex = Random.Shared.Next(fishlist.Count);

    Fish a = fishlist[aIndex];
    Fish b = fishlist[bIndex];

    if (a.Top > b.Top) (a, b) = (b, a);

    Console.WriteLine("thie two selecred fish:");
    Console.WriteLine($"'A': {a}");
    Console.WriteLine($"'B': {b}");

    int eatchance = Random.Shared.Next(100);

    if (a.Predator == b.Predator)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"both are {(a.Predator ? "carnivore" : "herbivore")}");
    }
    else if (a.Bottom <= b.Top)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("can't reach each other");
    }
    else if (eatchance >= 30)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("predator has no appetite");
    }

    if (a.Predator != b.Predator
    && a.Bottom >= b.Top
    && eatchance < 30)
    {
    Console.ForegroundColor = ConsoleColor.Red;
        if (a.Predator)
        {
            //TODO:::
            if (a.Weight <= 39.9) a.Weight += .1F;
            fishlist.Remove(b);
            Console.WriteLine("fish 'B' was eaten'");
        }
        else
        {
            //TODO:::
            if (b.Weight <= 39.9) b.Weight += .1F;
            fishlist.Remove(a);
            Console.WriteLine("fish 'A' was eaten'");
        }
    }
    Console.ResetColor();

    Console.WriteLine("--------------");

    Console.WriteLine($"fish lake pupularity after emulation: {fishlist.Count}");
}

