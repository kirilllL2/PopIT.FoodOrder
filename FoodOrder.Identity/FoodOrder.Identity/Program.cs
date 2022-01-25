using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using FoodOrder.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FoodOrder.Identity
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var serverProvider = scope.ServiceProvider;

				try
				{
					var context = serverProvider.GetRequiredService<AuthDbContext>();
					DbInitialize.Initialize(context);
				}
				catch (Exception e)
				{
					var logger = serverProvider.GetRequiredService<ILogger<Program>>();
					logger.LogError(e, "An error occurred while app initialization");
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
