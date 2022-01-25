using Blazored.Toast;
using Microsoft.Extensions.DependencyInjection;

namespace FoodOrder.Frontend.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddBlazoredToast();

            return services;
        }
    }
}