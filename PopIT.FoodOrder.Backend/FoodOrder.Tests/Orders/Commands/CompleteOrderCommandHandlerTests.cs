using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Orders.Commands.CompleteOrder;
using FoodOrder.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Orders.Commands
{
	public class CompleteOrderCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task CompleteOrderCommandHandler_Success()
		{
			// Arrange
			var handler = new CompleteOrderCommandHandler(Context);

			// Act
			await handler.Handle(
				new CompleteOrderCommand
				{
					Id = FoodOrderContextFactory.EntityIdForUpdate
				}, CancellationToken.None);

			// Arrange
			Assert.NotNull(await Context.Orders.FirstOrDefaultAsync(o =>
				o.Id == FoodOrderContextFactory.EntityIdForUpdate
				&& o.IsCompleted == true));
		}

		[Fact]
		public async Task CompleteOrderCommandHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new CompleteOrderCommandHandler(Context);

			// Act
			// Assert
			await Assert.ThrowsAsync<EntityIdNotFoundException>(async () =>
				await handler.Handle(
					new CompleteOrderCommand
					{
						Id = Guid.NewGuid()
					}, CancellationToken.None));
		}
	}
}
