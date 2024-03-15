using Microsoft.EntityFrameworkCore;

namespace TelegramWebAppRoman.Contexts
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection serviceCollection, string connectionString)
        {
            return serviceCollection.AddDbContext<DealerContext>(c => c.UseNpgsql(connectionString));
        }
    }
}
