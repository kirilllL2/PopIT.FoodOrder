using AutoMapper;
using FoodOrder.Application.Meats.Queries.GetMeatDetails;
using FoodOrder.Persistence;
using FoodOrder.Tests.Common;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Meats.Queries
{
	[Collection("QueryCollection")]
	public class GetMeatDetailsQueryHandlerTests
	{
		private readonly FoodOrderDbContext Context;
		private readonly IMapper Mapper;

		public GetMeatDetailsQueryHandlerTests(QueryTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetMeatDetailsQueryHandler_Success()
		{
			// Arrange
			var handler = new GetMeatDetailsQueryHandler(Context, Mapper);

			// Act
			var result = await handler.Handle(
				new GetMeatDetailsQuery
				{
					Id = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071")
				}, CancellationToken.None);

			// Assert
			result.ShouldBeOfType<MeatDetailsVm>();
			result.Name.ShouldBe("Name2");
			result.Price.ShouldBe(200m);
		}
	}
}
