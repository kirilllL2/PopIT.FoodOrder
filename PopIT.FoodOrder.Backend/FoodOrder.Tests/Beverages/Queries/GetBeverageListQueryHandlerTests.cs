using AutoMapper;
using FoodOrder.Application.Beverages.Queries.GetBeverageList;
using FoodOrder.Persistence;
using FoodOrder.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Beverages.Queries
{
	[Collection("QueryCollection")]
	public class GetBeverageListQueryHandlerTests
	{
		private readonly FoodOrderDbContext Context;
		private readonly IMapper Mapper;

		public GetBeverageListQueryHandlerTests(QueryTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetBeverageListQueryHandler_Success()
		{
			// Arrange
			var handler = new GetBeverageListQueryHandler(Context, Mapper);

			// Act
			var result = await handler.Handle(
				new GetBeverageListQuery
				{
					
				}, CancellationToken.None);

			// Assert
			result.ShouldBeOfType<BeverageListVm>();
			result.Beverages.Count.ShouldBe(4);
		}
	}
}
