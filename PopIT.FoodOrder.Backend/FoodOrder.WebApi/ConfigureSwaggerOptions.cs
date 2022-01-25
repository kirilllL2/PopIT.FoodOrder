﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.WebApi
{
	public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider _provider;

		public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
			_provider = provider;

		public void Configure(SwaggerGenOptions options)
		{
			foreach (var description in _provider.ApiVersionDescriptions)
			{
				var apiVersion = description.ApiVersion.ToString();
				options.SwaggerDoc(description.GroupName,
					new OpenApiInfo
					{
						Version = apiVersion,
						Title = $"FoodOrder API {apiVersion}",
						Description = "A simple ASP NET Core Web API."
					});
				
				options.AddSecurityDefinition($"AuthToken {apiVersion}",
					new OpenApiSecurityScheme
					{
						In = ParameterLocation.Header,
						Type = SecuritySchemeType.Http,
						BearerFormat = "JWT",
						Scheme = "bearer",
						Name = "Authorization",
						Description = "Authorization token"
					});

				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{ 
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = $"AuthToken {apiVersion}"
							}
						},
						new string[] { }
					}
				});

				options.CustomOperationIds(apiDescription =>
					apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)
						? methodInfo.Name
						: null);
			}
		}
	}
}
