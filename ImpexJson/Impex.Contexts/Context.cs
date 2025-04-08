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
    public CollectedJson CollectedJson { get; set; }

    public static Context Create(string name, CollectedJson collectedJson)
    {
        var context = new Context();
        context.Id = Guid.NewGuid();
        context.Name = name;
        context.CollectedJson = collectedJson;
        return context;
    }
}