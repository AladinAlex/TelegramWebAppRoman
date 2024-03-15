using Microsoft.AspNetCore.Mvc;
using TelegramWebAppRoman.Domain;
using TelegramWebAppRoman.Services.Interfaces;

namespace TelegramWebAppRoman.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        readonly ICatalogService _catalogService; 
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _catalogService.GetAll());
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Catalog catalog)
        {
            var newRow = await _catalogService.Add(catalog);
            if (newRow == 1)
                return Ok(newRow);
            else
                return BadRequest(newRow);
        }
    }
}
