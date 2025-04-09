using Impex.Json;

namespace Impex.Contexts;

public class Context
{
    private Context()
    {
        
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Version { get; set; }

    // Collection of IDS versioned JSONS
    // Shared Data for JSONS, inner JSON only have differ

    public static Context Create(string name)
    {
        var context = new Context();
        context.Id = Guid.NewGuid();
        context.Name = name;
        return context;
    }
}