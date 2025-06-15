using impex_api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace impex_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ImportController : ControllerBase
{
    private readonly JsonStorage _storage;
    public ImportController(JsonStorage storage)
    {
        _storage = storage;
    }
    
    
    [HttpPost("File")]
    public async Task<IActionResult> ImportJsonFileAsync(IFormFile file)
    {
        await _storage.AddItemAsync(file);
        return Ok();
    }
    
    
    [HttpPost("String")]
    public async Task<IActionResult> ImportJsonStringAsync([FromBody] string jsonContent, string name)
    {
        await _storage.AddItemAsync(jsonContent, name);
        return Ok();
    }
}