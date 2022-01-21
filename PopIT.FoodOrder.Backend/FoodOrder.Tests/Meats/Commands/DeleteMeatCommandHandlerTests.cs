using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Meats.Commands.DeleteMeat;
using FoodOrder.Tests.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Meats.Commands
{
	public class DeleteMeatCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task DeleteMeatCommandHandler_Success()
		{
			// Arrange
			var handler = new DeleteMeatCommandHandler(Context);

			// Act
			await handler.Handle(
				new DeleteMeatCommand
				{
					Id = FoodOrderContextFactory.EntityIdForDelete
				}, CancellationToken.None);

			// Assert
			Assert.Null(Context.Meats.SingleOrDefault(m =>
				m.Id == FoodOrderContextFactory.EntityIdForDelete));
		}

		[Fact]
		public async Task DeleteMeatCommandHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new DeleteMeatCommandHandler(Context);

			// Act
			// Assert
			await Assert.ThrowsAsync<EntityIdNotFoundException>(async () =>
				await handler.Handle(
					new DeleteMeatCommand
					{
						Id = Guid.NewGuid(),
					}, CancellationToken.None));
		}
	}
}
