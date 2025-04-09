namespace Impex.Json;

public class CollectedJson
{
    public CollectedJson()
    {
        Particles = new List<Particle>();
    }
    public List<Particle> Particles { get; set; }
}