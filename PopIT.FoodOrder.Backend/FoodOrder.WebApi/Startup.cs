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
using System;
using System.IO;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

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

			services.AddVersionedApiExplorer(options =>
				options.GroupNameFormat = "'v'VVV");
			services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
				ConfigureSwaggerOptions>();
			services.AddSwaggerGen();
			services.AddApiVersioning();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
				IApiVersionDescriptionProvider provider)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(config =>
			{
				foreach (var description in provider.ApiVersionDescriptions)
				{
					config.SwaggerEndpoint(
						$"/swagger/{description.GroupName}/swagger.json",
						description.GroupName.ToUpperInvariant());
					config.RoutePrefix = string.Empty;
				}
			});
			app.UseCustomExceptionHandler();
			app.UseRouting();
			app.UseHttpsRedirection();
			app.UseCors("AllowAll");
			app.UseApiVersioning();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
