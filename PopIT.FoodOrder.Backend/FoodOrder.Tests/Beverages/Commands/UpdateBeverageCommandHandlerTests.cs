using FoodOrder.Application.Beverages.Commands.UpdateBeverage;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Beverages.Commands
{
	public class UpdateBeverageCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task UpdateBeverageCommandHandler_Success()
		{
			// Arrange
			var handler = new UpdateBeverageCommandHandler(Context, Mapper);
			var updateName = "update name";

			// Act
			await handler.Handle(
				new UpdateBeverageCommand
				{ 
					Id = FoodOrderContextFactory.EntityIdForUpdate,
					Name = updateName,
				}, CancellationToken.None);

			// Assert
			Assert.NotNull(await Context.Beverages.SingleOrDefaultAsync(b =>
				b.Id == FoodOrderContextFactory.EntityIdForUpdate
				&& b.Name == updateName));
		}

		[Fact]
		public async Task UpdateBeverageCommandHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new UpdateBeverageCommandHandler(Context, Mapper);

			// Act
			// Assert
			await Assert.ThrowsAsync<EntityIdNotFoundException>(async () =>
				await handler.Handle(
					new UpdateBeverageCommand
					{
						Id = System.Guid.NewGuid()
					}, CancellationToken.None));
		}
	}
}
