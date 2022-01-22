using AutoMapper;
using FoodOrder.Application.Garnishes.Queries.GetGarnishDetails;
using FoodOrder.Persistence;
using FoodOrder.Tests.Common;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Garnishes.Queries
{
	[Collection("QueryCollection")]
	public class GetGarnishDetailsQueryHandlerTests
	{
		private readonly FoodOrderDbContext Context;
		private readonly IMapper Mapper;

		public GetGarnishDetailsQueryHandlerTests(QueryTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetGarnishDetailsQueryHandler_Success()
		{
			// Arrange
			var handler = new GetGarnishDetailsQueryHandler(Context, Mapper);

			// Act
			var result = await handler.Handle(
				new GetGarnishDetailsQuery
				{
					Id = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071")
				}, CancellationToken.None);

			// Assert
			result.ShouldBeOfType<GarnishDetailsVm>();
			result.Name.ShouldBe("Name2");
			result.Price.ShouldBe(200m);
		}
	}
}
