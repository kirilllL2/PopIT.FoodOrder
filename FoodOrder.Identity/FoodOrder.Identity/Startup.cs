using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FoodOrder.Identity.Data;
using FoodOrder.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace FoodOrder.Identity
{
	public class Startup
	{
		public Startup(IConfiguration appConfiguration)
		{
			AppConfiguration = appConfiguration;
		}

		public IConfiguration AppConfiguration { get; }
		
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AuthDbContext>(opt => opt.UseSqlServer(
				AppConfiguration.GetConnectionString("MSSQLConnection"),
				sqlOpt => sqlOpt.MigrationsAssembly(typeof(AuthDbContext).Assembly.FullName)));

			services.AddIdentity<AppUser, IdentityRole>(config =>
			{
				config.Password.RequiredLength = 4;
				config.Password.RequireDigit = false;
				config.Password.RequireNonAlphanumeric = false;
				config.Password.RequireUppercase = false;
			})
				.AddEntityFrameworkStores<AuthDbContext>()
				.AddDefaultTokenProviders();
			
			services.AddIdentityServer()
				.AddAspNetIdentity<AppUser>()
				.AddInMemoryApiResources(Configuration.ApiResources)
				.AddInMemoryIdentityResources(Configuration.IdentityResources)
				.AddInMemoryApiScopes(Configuration.ApiScopes)
				.AddInMemoryClients(Configuration.Clients)
				.AddDeveloperSigningCredential();

			services.ConfigureApplicationCookie(config =>
			{
				config.Cookie.Name = "FoodOrder.Identity.Cookie";
				config.LoginPath = "/Auth/Login";
				config.LogoutPath = "/Auth/Logout";
			});

			services.AddControllersWithViews();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Styles")),
				RequestPath = "/styles"
			});
			app.UseRouting();
			app.UseIdentityServer();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}
