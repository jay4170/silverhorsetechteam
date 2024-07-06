using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CollectionController : ControllerBase
{
    private readonly CollectionService _collectionService;

    public CollectionController(CollectionService collectionService)
    {
        _collectionService = collectionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCollection()
    {
        var collection = await _collectionService.GetCollectionAsync();
        return Ok(collection);
    }
}
