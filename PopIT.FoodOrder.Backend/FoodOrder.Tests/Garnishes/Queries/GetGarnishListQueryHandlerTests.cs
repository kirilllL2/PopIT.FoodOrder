using AutoMapper;
using FoodOrder.Application.Garnishes.Queries.GetGarnishList;
using FoodOrder.Persistence;
using FoodOrder.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Garnishes.Queries
{
	[Collection("QueryCollection")]
	public class GetGarnishListQueryHandlerTests
	{
		private readonly FoodOrderDbContext Context;
		private readonly IMapper Mapper;

		public GetGarnishListQueryHandlerTests(QueryTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetBeverageListQueryHandler_Success()
		{
			// Arrange
			var handler = new GetGarnishListQueryHandler(Context, Mapper);

			// Act
			var result = await handler.Handle(
				new GetGarnishListQuery
				{

				}, CancellationToken.None);

			// Assert
			result.ShouldBeOfType<GarnishListVm>();
			result.Garnishes.Count.ShouldBe(4);
		}
	}
}
