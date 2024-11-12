namespace CA24111202;

internal class Fish
{
    private int top;
    private int depth;

    public string Species { get; set; }

    public bool Predator { get; }

    public float Weight { get; set; }
    public int Top
    {
        get => top;
        set
        {
            if (value < 0 || value > 400) throw new Exception(
                $"az érték, amit szeretnél beállítani a top-ra: {value} " +
                $"viszont a top értéke csak [0, 400] között valid!");

            top = value;
        }
    }
    public int Depth
    {
        get => depth;
        set
        {
            if (value < 10 || value > 400) throw new Exception(
                $"az érték, amit szeretnél beállítani a depth-re: {value}, " +
                $"viszont a depth értéke csak [10, 400] között valid!");

            depth = value;
        }
    }

    public override string ToString() =>
        $"{Species} " +
        $"({(Predator ? "carnivore" : "herbivore")}) " +
        $"[{Top} - {Top + Depth} cm] " +
        $"{Weight:00.0} Kg";

    public Fish(string species, bool predator, float weight, int top, int depth)
    {
        Species = species;
        Predator = predator;
        Weight = weight;
        Top = top;
        Depth = depth;
    }
}
