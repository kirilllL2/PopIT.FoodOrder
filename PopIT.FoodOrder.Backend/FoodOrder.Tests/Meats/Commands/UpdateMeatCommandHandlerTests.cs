using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Meats.Commands.UpdateMeat;
using FoodOrder.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Meats.Commands
{
	public class UpdateMeatCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task UpdateMeatCommandHandler_Success()
		{
			// Arrange
			var handler = new UpdateMeatCommandHandler(Context, Mapper);
			var updateName = "update name";

			// Act
			await handler.Handle(
				new UpdateMeatCommand
				{
					Id = FoodOrderContextFactory.EntityIdForUpdate,
					Name = updateName,
				}, CancellationToken.None);

			// Assert
			Assert.NotNull(await Context.Meats.SingleOrDefaultAsync(m =>
				m.Id == FoodOrderContextFactory.EntityIdForUpdate
				&& m.Name == updateName));
		}

		[Fact]
		public async Task UpdateMeatCommandHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new UpdateMeatCommandHandler(Context, Mapper);

			// Act
			// Assert
			await Assert.ThrowsAsync<EntityIdNotFoundException>(async () =>
				await handler.Handle(
					new UpdateMeatCommand
					{
						Id = Guid.NewGuid()
					}, CancellationToken.None));
		}
	}
}
