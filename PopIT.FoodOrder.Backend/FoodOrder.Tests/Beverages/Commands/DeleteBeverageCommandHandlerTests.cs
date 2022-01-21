using FoodOrder.Application.Beverages.Commands.DeleteBeverage;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Tests.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Beverages.Commands
{
	public class DeleteBeverageCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task DeleteBeverageCommandHandler_Success()
		{
			// Arrange
			var handler = new DeleteBeverageCommandHandler(Context);

			// Act
			await handler.Handle(
				new DeleteBeverageCommand
				{
					Id = FoodOrderContextFactory.EntityIdForDelete
				}, CancellationToken.None);

			// Assert
			Assert.Null(Context.Beverages.SingleOrDefault(b =>
				b.Id == FoodOrderContextFactory.EntityIdForDelete));
		}

		[Fact]
		public async Task DeleteBeverageCommandHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new DeleteBeverageCommandHandler(Context);

			// Act
			// Assert
			await Assert.ThrowsAsync<EntityIdNotFoundException>(async () =>
				await handler.Handle(
					new DeleteBeverageCommand
					{
						Id = Guid.NewGuid(),
					}, CancellationToken.None));
		}
	}
}
