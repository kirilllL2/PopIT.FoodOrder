using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Garnishes.Commands.UpdateGarnish;
using FoodOrder.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Garnishes.Commands
{
	public class UpdateGarnishCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task UpdateGarnishCommandHandler_Success()
		{
			// Arrange
			var handler = new UpdateGarnishCommandHandler(Context, Mapper);
			var updateName = "update name";

			// Act
			await handler.Handle(
				new UpdateGarnishCommand
				{
					Id = FoodOrderContextFactory.EntityIdForUpdate,
					Name = updateName,
				}, CancellationToken.None);

			// Assert
			Assert.NotNull(await Context.Garnishes.SingleOrDefaultAsync(g =>
				g.Id == FoodOrderContextFactory.EntityIdForUpdate
				&& g.Name == updateName));
		}

		[Fact]
		public async Task UpdateGarnishCommandHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new UpdateGarnishCommandHandler(Context, Mapper);

			// Act
			// Assert
			await Assert.ThrowsAsync<EntityIdNotFoundException>(async () =>
				await handler.Handle(
					new UpdateGarnishCommand
					{
						Id = Guid.NewGuid()
					}, CancellationToken.None));
		}
	}
}
