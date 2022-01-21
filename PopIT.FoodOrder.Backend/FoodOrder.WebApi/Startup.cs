using FoodOrder.Application;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Interfaces;
using FoodOrder.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using FoodOrder.WebApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FoodOrder.WebApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration) =>
			Configuration = configuration;
		

		public IConfiguration Configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(config =>
			{
				config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
				config.AddProfile(new AssemblyMappingProfile(typeof(IFoodOrderDbContext).Assembly));
			});

			services.AddApplication();
			services.AddPersistence(Configuration);
			services.AddControllers();

			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", policy =>
				{
					policy.AllowAnyHeader();
					policy.AllowAnyMethod();
					policy.AllowAnyOrigin();
				});
			});

			services.AddAuthentication(config =>
			{
				config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer("Bearer", options =>
				{
					options.Authority = "http://localhost:44397/";
					options.Audience = "FoodOrderWebAPI";
					options.RequireHttpsMetadata = false;
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCustomExceptionHandler();
			app.UseRouting();
			app.UseHttpsRedirection();
			app.UseCors("AllowAll");
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
