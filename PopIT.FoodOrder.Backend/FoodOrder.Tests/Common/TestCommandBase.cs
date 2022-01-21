using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Interfaces;
using FoodOrder.Persistence;
using System;

namespace FoodOrder.Tests.Common
{
	public class TestCommandBase : IDisposable
	{
		protected readonly FoodOrderDbContext Context;
		protected readonly IMapper Mapper;

		public TestCommandBase()
		{
			Context = FoodOrderContextFactory.Create();
			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AssemblyMappingProfile(
					typeof(IFoodOrderDbContext).Assembly));
			});
			Mapper = configurationProvider.CreateMapper();
		}

		public void Dispose() => FoodOrderContextFactory.Destroy(Context);
	}
}
