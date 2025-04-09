namespace Impex.Json;

public class Particle
{
    public Signature Signature { get; set; }
    public object Data { get; set; }
    public ParticleType Type { get; set; }
    public int Version { get; set; }
}