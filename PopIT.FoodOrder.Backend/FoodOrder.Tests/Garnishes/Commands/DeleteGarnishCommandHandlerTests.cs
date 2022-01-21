using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Garnishes.Commands.DeleteGarnish;
using FoodOrder.Tests.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Garnishes.Commands
{
	public class DeleteGarnishCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task DeleteGarnishCommandHandler_Success()
		{
			// Arrange
			var handler = new DeleteGarnishCommandHandler(Context);

			// Act
			await handler.Handle(
				new DeleteGarnishCommand
				{
					Id = FoodOrderContextFactory.EntityIdForDelete
				}, CancellationToken.None);

			// Assert
			Assert.Null(Context.Garnishes.SingleOrDefault(g =>
				g.Id == FoodOrderContextFactory.EntityIdForDelete));
		}

		[Fact]
		public async Task DeleteGarnishCommandHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new DeleteGarnishCommandHandler(Context);

			// Act
			// Assert
			await Assert.ThrowsAsync<EntityIdNotFoundException>(async () =>
				await handler.Handle(
					new DeleteGarnishCommand
					{
						Id = Guid.NewGuid(),
					}, CancellationToken.None));
		}
	}
}
