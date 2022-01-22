using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Soups.Commands.UpdateSoup;
using FoodOrder.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Soups.Commands
{
	public class UpdateSoupCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task UpdateSoupCommandHandler_Success()
		{
			// Arrange
			var handler = new UpdateSoupCommandHandler(Context, Mapper);
			var updateName = "update name";

			// Act
			await handler.Handle(
				new UpdateSoupCommand
				{
					Id = FoodOrderContextFactory.EntityIdForUpdate,
					Name = updateName,
				}, CancellationToken.None);

			// Assert
			Assert.NotNull(await Context.Soups.SingleOrDefaultAsync(b =>
				b.Id == FoodOrderContextFactory.EntityIdForUpdate
				&& b.Name == updateName));
		}

		[Fact]
		public async Task UpdateSoupCommandHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new UpdateSoupCommandHandler(Context, Mapper);

			// Act
			// Assert
			await Assert.ThrowsAsync<EntityIdNotFoundException>(async () =>
				await handler.Handle(
					new UpdateSoupCommand
					{
						Id = Guid.NewGuid()
					}, CancellationToken.None));
		}
	}
}
