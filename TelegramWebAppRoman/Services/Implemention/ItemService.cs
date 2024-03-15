using Microsoft.EntityFrameworkCore;
using TelegramWebAppRoman.Contexts;
using TelegramWebAppRoman.Domain;
using TelegramWebAppRoman.Services.Interfaces;

namespace TelegramWebAppRoman.Services.Implemention
{
    public class ItemService : IItemService
    {
        readonly DealerContext _context;
        public ItemService(DealerContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Item>> GetAll(int catalogId)
        {
            return await _context.Items.AsNoTracking().Where(x => x.isActive && x.CatalogId == catalogId).ToListAsync();
        }

        public async Task<int> Add(Item item)
        {
            await _context.Items.AddAsync(item);
            return await _context.SaveChangesAsync();
        }

    }
}
