using Impex.Json;
using Impex.Storage.Common;

namespace Impex.Contexts;

public class ContextManager
{
    public ContextManager(IStorageProvider storageProvider)
    {
        StorageProvider = storageProvider;
        Contexts = new List<Context>();
    }
    private List<Context> Contexts { get; set; }
    private IStorageProvider StorageProvider { get; set; }

    public void RegisterContext(string contextName, CollectedJson collectedJson)
    {
        var contextToAdd = Context.Create(contextName, collectedJson);
        Contexts.Add(contextToAdd);
    }

    public IEnumerable<Context> GetContexts()
    {
        return Contexts;
    }
}