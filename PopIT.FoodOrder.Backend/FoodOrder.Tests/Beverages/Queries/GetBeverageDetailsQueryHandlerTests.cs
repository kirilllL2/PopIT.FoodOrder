using AutoMapper;
using FoodOrder.Application.Beverages.Queries.GetBeverageDetails;
using FoodOrder.Persistence;
using FoodOrder.Tests.Common;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Beverages.Queries
{
	[Collection("QueryCollection")]
	public class GetBeverageDetailsQueryHandlerTests
	{
		private readonly FoodOrderDbContext Context;
		private readonly IMapper Mapper;

		public GetBeverageDetailsQueryHandlerTests(QueryTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetBeverageDetailsQueryHandler_Success()
		{
			// Arrange
			var handler = new GetBeverageDetailsQueryHandler(Context, Mapper);

			// Act
			var result = await handler.Handle(
				new GetBeverageDetailsQuery
				{
					Id = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071")
				}, CancellationToken.None);

			// Assert
			result.ShouldBeOfType<BeverageDetailsVm>();
			result.Name.ShouldBe("Name2");
			result.Price.ShouldBe(200m);
		}
	}
}
