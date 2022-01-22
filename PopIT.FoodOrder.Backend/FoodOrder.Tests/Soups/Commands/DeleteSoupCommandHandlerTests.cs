using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Soups.Commands.DeleteSoup;
using FoodOrder.Tests.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Soups.Commands
{
	public class DeleteSoupCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task DeleteSoupCommandHandler_Success()
		{
			// Arrange
			var handler = new DeleteSoupCommandHandler(Context);

			// Act
			await handler.Handle(
				new DeleteSoupCommand
				{
					Id = FoodOrderContextFactory.EntityIdForDelete
				}, CancellationToken.None);

			// Assert
			Assert.Null(Context.Soups.SingleOrDefault(s =>
				s.Id == FoodOrderContextFactory.EntityIdForDelete));
		}

		[Fact]
		public async Task DeleteSoupCommandHandler_FailOnWrongId()
		{
			// Arrange
			var handler = new DeleteSoupCommandHandler(Context);

			// Act
			// Assert
			await Assert.ThrowsAsync<EntityIdNotFoundException>(async () =>
				await handler.Handle(
					new DeleteSoupCommand
					{
						Id = Guid.NewGuid(),
					}, CancellationToken.None));
		}
	}
}
