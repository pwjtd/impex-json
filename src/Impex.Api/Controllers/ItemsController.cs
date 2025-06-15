using impex_api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace impex_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController: ControllerBase
{
    private readonly JsonStorage _storage;
    public ItemsController(JsonStorage storage)
    {
        _storage = storage;
    }
    
    [HttpGet("List")]
    public IActionResult JsonItemsList()
    {
        return Ok(_storage.JsonItems);
    }
}