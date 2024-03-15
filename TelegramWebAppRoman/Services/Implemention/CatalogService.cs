using Microsoft.EntityFrameworkCore;
using TelegramWebAppRoman.Contexts;
using TelegramWebAppRoman.Domain;
using TelegramWebAppRoman.Services.Dto;
using TelegramWebAppRoman.Services.Interfaces;

namespace TelegramWebAppRoman.Services.Implemention
{
    public class CatalogService : ICatalogService
    {
        readonly DealerContext _context;
        public CatalogService(DealerContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<CatalogDto>> GetAll()
        {
            return await _context.Catalogs.AsNoTracking().Where(x => x.isActive)
                .Select(x => new CatalogDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ItemCount = x.Items.Count(),
                })
                .ToListAsync(); 
        }

        public async Task<int> Add(Catalog catalog)
        {
            await _context.Catalogs.AddAsync(catalog);
            return await _context.SaveChangesAsync();
        }
    }
}
