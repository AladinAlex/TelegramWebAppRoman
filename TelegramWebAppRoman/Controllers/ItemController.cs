using Microsoft.AspNetCore.Mvc;
using TelegramWebAppRoman.Domain;
using TelegramWebAppRoman.Services.Interfaces;

namespace TelegramWebAppRoman.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        readonly IItemService _itemService; 
        public ItemController(IItemService catalogService)
        {
            _itemService = catalogService;
        }

        [HttpGet("GetAll/{CatalogId}")]
        public async Task<IActionResult> GetAll(int CatalogId)
        {
            return Ok(await _itemService.GetAll(CatalogId));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Item item)
        {
            var newRow = await _itemService.Add(item);
            if (newRow == 1)
                return Ok(newRow);
            else
                return BadRequest(newRow);
        }
    }
}
