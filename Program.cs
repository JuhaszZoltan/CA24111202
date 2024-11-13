using CA24111202;

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

//Console.WriteLine(fish);