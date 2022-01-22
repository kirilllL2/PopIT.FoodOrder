using AutoMapper;
using FoodOrder.Application.Soups.Queries.GetSoupDetails;
using FoodOrder.Persistence;
using FoodOrder.Tests.Common;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Soups.Queries
{
	[Collection("QueryCollection")]
	public class GetSoupDetailsQueryHandlerTests
	{
		private readonly FoodOrderDbContext Context;
		private readonly IMapper Mapper;

		public GetSoupDetailsQueryHandlerTests(QueryTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetSoupDetailsQueryHandler_Success()
		{
			// Arrange
			var handler = new GetSoupDetailsQueryHandler(Context, Mapper);

			// Act
			var result = await handler.Handle(
				new GetSoupDetailsQuery
				{
					Id = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071")
				}, CancellationToken.None);

			// Assert
			result.ShouldBeOfType<SoupDetailsVm>();
			result.Name.ShouldBe("Name2");
			result.Price.ShouldBe(200m);
		}
	}
}
