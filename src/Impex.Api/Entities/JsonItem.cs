namespace impex_api.Entities;

public class JsonItem
{
    public JsonItem(string filename)
    {
        FileName = filename;
        Version = 1;
        Created = DateTime.UtcNow;
        LastModified = DateTime.UtcNow;
    }
    
    public string FileName { get; set; }
    public int Version { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    
    public static JsonItem Create(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            throw new ArgumentNullException(nameof(filename));
        }

        if (!filename.EndsWith(".json"))
        {
            filename += ".json";
        }
        JsonItem jsonItem = new(filename);
        return jsonItem;
    }
    
    public void UpVersion()
    {
        Version++;
    }
}
