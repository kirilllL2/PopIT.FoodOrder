using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Interfaces;
using FoodOrder.Persistence;
using System;
using Xunit;

namespace FoodOrder.Tests.Common
{
	public class QueryTestFixture : IDisposable
	{
		public FoodOrderDbContext Context;
		public IMapper Mapper;

		public QueryTestFixture()
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

	[CollectionDefinition("QueryCollection")]
	public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
