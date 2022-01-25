using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Orders.Queries.GetOrderDetails;
using FoodOrder.Persistence;
using FoodOrder.Tests.Common;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Orders.Queries
{
	[Collection("QueryCollection")]
	public class GetOrderDetailsQueryHandlerTests
	{
		private readonly FoodOrderDbContext Context;
		private readonly IMapper Mapper;

		public GetOrderDetailsQueryHandlerTests(QueryTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetOrderDetailsQueryHandler_Success()
		{
			// Arrange
			var handler = new GetOrderDetailsQueryHandler(Context, Mapper);

			// Act
			var result = await handler.Handle(
				new GetOrderDetailsQuery
				{
					Id = Guid.Parse("6E263BC8-D4CB-418E-ABBF-54420CBCE5C8"),
					UserId = FoodOrderContextFactory.UserIdForUpdate
				}, CancellationToken.None);

			// Assert
			result.ShouldBeOfType<OrderDetailsVm>();
			result.IsCompleted.ShouldBe(false);
			result.Id.ShouldBe(Guid.Parse("6E263BC8-D4CB-418E-ABBF-54420CBCE5C8"));
			result.OrderTime.ShouldBe(DateTime.Today);
		}

		[Fact]
		public async Task GetOrderDetailsQueryHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new GetOrderDetailsQueryHandler(Context, Mapper);

			// Act
			// Assert
			await Assert.ThrowsAsync<EntityIdNotFoundException>(async () =>
				await handler.Handle(
					new GetOrderDetailsQuery
					{
						Id = Guid.NewGuid(),
						UserId = FoodOrderContextFactory.UserIdForUpdate
					}, CancellationToken.None));
		}

		[Fact]
		public async Task GetOrderDetailsQueryHandler_FailOnWrongUserId()
		{
			// Arrange
			var handler = new GetOrderDetailsQueryHandler(Context, Mapper);

			// Act
			// Assert
			await Assert.ThrowsAsync<EntityIdNotFoundException>(async () =>
				await handler.Handle(
					new GetOrderDetailsQuery
					{
						Id = FoodOrderContextFactory.EntityIdForUpdate,
						UserId = Guid.NewGuid()
					}, CancellationToken.None));
		}
	}
}
