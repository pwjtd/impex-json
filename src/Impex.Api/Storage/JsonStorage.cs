using impex_api.Entities;

namespace impex_api.Storage;

public class JsonStorage
{
    private readonly string _storagePath;

    public JsonStorage()
    {
        _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "Jsons");
        var filePaths = Directory.GetFiles(_storagePath);
        var fileNames = filePaths.Select(path => Path.GetFileName(path));
        JsonItems = fileNames.Select(x=> new JsonItem(x)).ToList();
    }
    
    public List<JsonItem> JsonItems { get; set; }

    public async Task AddItemAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return;
        }
        var filePath = Path.Combine(_storagePath, file.FileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
    }
    public async Task AddItemAsync(string jsonContent, string name)
    {
        if (string.IsNullOrEmpty(jsonContent))
        {
            return;
        }
        var fileName = $"{name}.json";
        var filePath = Path.Combine(_storagePath, fileName);
        await System.IO.File.WriteAllTextAsync(filePath, jsonContent);
    }

    public async Task<string> GetJsonContentAsync(string fileName)
    {
        if (!fileName.EndsWith(".json"))
        {
            fileName += ".json";
        }
        var filePath = Path.Combine(_storagePath, fileName);
        if (!System.IO.File.Exists(filePath))
        {
            return string.Empty;
        }
        return await System.IO.File.ReadAllTextAsync(filePath);
    }
    
    public async Task<byte[]> GetJsonContentBytesAsync(string fileName)
    {
        if (!fileName.EndsWith(".json"))
        {
            fileName += ".json";
        }
        var filePath = Path.Combine(_storagePath, fileName);
        if (!System.IO.File.Exists(filePath))
        {
            return [];
        }
        return await System.IO.File.ReadAllBytesAsync(filePath);
    }
}