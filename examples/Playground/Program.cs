using System.Text.Json;
using Impex.Contexts;
using Impex.Json;
using Impex.Storage.InMemory;

namespace Playground;

class Program
{
    static void Main(string[] args)
    {
        var envManager = new EnvironmentManager();
        
        
        
        
        
        var crmApp = new CRM();
        var crmAppToImport = JsonSerializer.Serialize(crmApp);
        var collector = new JsonCollector();
        var collectedJson = collector.Collect(crmAppToImport);

        var inMemoryStorageProvider = new InMemoryStorageProvider();
        var impexManager = new ContextManager(inMemoryStorageProvider);
    }
}