using TelegramWebAppRoman.Domain;
using TelegramWebAppRoman.Services.Dto;

namespace TelegramWebAppRoman.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<IReadOnlyCollection<CatalogDto>> GetAll();
        Task<int> Add(Catalog catalog);
    }
}
