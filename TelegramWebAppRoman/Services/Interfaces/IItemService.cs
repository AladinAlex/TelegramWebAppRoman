using TelegramWebAppRoman.Domain;

namespace TelegramWebAppRoman.Services.Interfaces
{
    public interface IItemService
    {
        Task<IReadOnlyCollection<Item>> GetAll(int catalogId);
        Task<int> Add(Item item);
    }
}
