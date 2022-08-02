using Microsoft.Extensions.DependencyInjection;

namespace Stefanini.Challenge.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
