using FoodOrder.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FoodOrder.WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var serviceProvider = scope.ServiceProvider;
				try
				{
					var context = serviceProvider.GetRequiredService<FoodOrderDbContext>();
					DbInitializer.Initialize(context);
				}
				catch (Exception exception)
				{
					// Log.Fatal(exception, "An error occurred while app initialization");
				}
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
