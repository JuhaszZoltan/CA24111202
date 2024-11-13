using System.ComponentModel.DataAnnotations;

namespace CA24111202;

internal class Fish
{
    private int top;
    private int depth;
    private string species;
    private float weight;
    private bool weightIsSet = false;

    public string Species
    {
        get => species;
        set
        {
            if (value is null) throw new Exception(
                "a species értéke nem lehet null");

            if (value.Length < 3 || value.Length > 30) throw new Exception(
                $"az érték, amit szeretnél beállítani a species-re: {value}, " +
                $"hossza: {value.Length}. a species hossza csak [3, 30] között valid!");

            species = value;
        }
    }

    public bool Predator { get; }

    public float Weight
    {
        get => weight;
        set
        {
            if (value < .5 || value > 40) throw new Exception(
                $"az érték, amit szeretnél beállítani a weight-re: {value:0.00} " +
                $"viszont a weight értéke csak [0.5, 40] között valid!");

            if (weightIsSet && (value < weight * .9 || value > weight * 1.1)) 
                throw new Exception(
                $"az érték amit szeretnél beállítani weight-re: {value:0.00}. " +
                $"jelenlegi értéke: {weight}. " +
                $"ez {Math.Abs((weight-value) / weight * 100):0.00}%-os eltérés! " +
                $"viszont a weight értéke maximum +/-10%-al módosítható!");

            weight = value;
            weightIsSet = true;
        }
    }

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

    public int Bottom => Top + Depth;

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
