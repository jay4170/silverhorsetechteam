using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
[Authorize]

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
