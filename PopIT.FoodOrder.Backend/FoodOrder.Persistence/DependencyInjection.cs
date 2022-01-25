using FoodOrder.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodOrder.Persistence
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<FoodOrderDbContext>(opt => 
				opt.UseSqlServer(configuration.GetConnectionString("MSSQLConnection"),
				sqlOpt => sqlOpt.MigrationsAssembly(typeof(FoodOrderDbContext).Assembly.FullName)));

			services.AddScoped<IFoodOrderDbContext>(provider => 
				provider.GetService<FoodOrderDbContext>());
			
			return services;
		}
	}
}
