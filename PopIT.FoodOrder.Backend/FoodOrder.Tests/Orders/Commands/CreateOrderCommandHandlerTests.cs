using FoodOrder.Application.Orders.Commands.CreateOrder;
using FoodOrder.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Orders.Commands
{
	public class CreateOrderCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task CreateOrderCommandHandler_Success()
		{
			// Arrange
			var handler = new CreateOrderCommandHandler(Context, Mapper);

			// Act
			var orderId = await handler.Handle(
				new CreateOrderCommand
				{
					UserId = FoodOrderContextFactory.UserIdForUpdate,
					BeverageId = FoodOrderContextFactory.EntityIdForUpdate,
					MeatId = FoodOrderContextFactory.EntityIdForDelete,
					GarnishId = FoodOrderContextFactory.EntityIdForUpdate,
					SoupId = FoodOrderContextFactory.EntityIdForDelete
				}, CancellationToken.None);

			// Assert
			Assert.NotNull(await Context.Orders.SingleOrDefaultAsync(o =>
				o.Id == orderId
				&& o.UserId == FoodOrderContextFactory.UserIdForUpdate
				&& o.BeverageId == FoodOrderContextFactory.EntityIdForUpdate
				&& o.MeatId == FoodOrderContextFactory.EntityIdForDelete
				&& o.GarnishId == FoodOrderContextFactory.EntityIdForUpdate
				&& o.SoupId == FoodOrderContextFactory.EntityIdForDelete));
		}
	}
}
