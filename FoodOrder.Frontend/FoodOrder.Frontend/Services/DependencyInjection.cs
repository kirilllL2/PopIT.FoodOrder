using Microsoft.Extensions.DependencyInjection;

namespace FoodOrder.Frontend.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            return services;
        }
    }
}