using System.Text.Json;
using Impex.Contexts;
using Impex.Json;
using Impex.Storage.InMemory;
using Playground.Environments;

namespace Playground;

class Program
{
    static void Main(string[] args)
    {
        var crmEnvironment = new CRM();
        var crmEnvironmentToImport = JsonSerializer.Serialize(crmEnvironment);
        var collector = new JsonCollector();
        var collectedJson = collector.Collect(crmEnvironmentToImport);

        var inMemoryStorageProvider = new InMemoryStorageProvider();
        var impexManager = new ContextManager(inMemoryStorageProvider);
        impexManager.RegisterContext("CRM context 1", collectedJson);
        
        var contexts = impexManager.GetContexts();
        foreach (var context in contexts)
        {
            Console.WriteLine($"ID: {context.Id}");
            Console.WriteLine($"Name: {context.Name}");
        }
    }
}