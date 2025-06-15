using impex_api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace impex_api.Controllers;


[ApiController]
[Route("[controller]")]
public class ExportController : ControllerBase
{
    private readonly JsonStorage _storage;
    public ExportController(JsonStorage storage)
    {
        _storage = storage;
    }
    
    [HttpGet("File")]
    public async Task<IActionResult> ExportJsonFileAsync([FromQuery] string fileName)
    {
        var fileBytes = await _storage.GetJsonContentBytesAsync(fileName);
        return File(fileBytes, "application/json", fileName);
    }
    
    [HttpGet("String")]
    public async Task<IActionResult> ExportJsonStringAsync([FromQuery] string fileName)
    {
        var jsonContent = await _storage.GetJsonContentAsync(fileName);
        return Content(jsonContent, "application/json");
    }
}