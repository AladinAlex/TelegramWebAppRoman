using Microsoft.EntityFrameworkCore;
using TelegramWebAppRoman.Contexts;
using TelegramWebAppRoman.Services.Implemention;
using TelegramWebAppRoman.Services.Interfaces;

namespace TelegramWebAppRoman.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICatalogService, CatalogService>();
            serviceCollection.AddTransient<IItemService, ItemService>();
            return serviceCollection;
        }
    }
}
