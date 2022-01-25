using AutoMapper;
using FoodOrder.Application.Orders.Queries.GetOrderList;
using FoodOrder.Persistence;
using FoodOrder.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Orders.Queries
{
	[Collection("QueryCollection")]
	public class GetOrderListQueryHandlerTests
	{
		private readonly FoodOrderDbContext Context;
		private readonly IMapper Mapper;

		public GetOrderListQueryHandlerTests(QueryTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetOrderListQueryHandler_Success()
		{
			// Arrange
			var handler = new GetOrderListQueryHandler(Context, Mapper);

			// Act
			var result = await handler.Handle(
				new GetOrderListQuery
				{
					
				}, CancellationToken.None);

			// Assert
			result.ShouldBeOfType<OrderListVm>();
			result.Orders.Count.ShouldBe(3);
		}
	}
}
