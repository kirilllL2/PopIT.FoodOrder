using FoodOrder.Application.Soups.Commands.CreateSoup;
using FoodOrder.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Soups.Commands
{
	public class CreateSoupCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task CreateSoupCommandHandler_Success()
		{
			// Arrange
			var handler = new CreateSoupCommandHandler(Context, Mapper);
			var soupName = "soup name";
			var soupPrice = 13.1m;

			// Act
			var soupId = await handler.Handle(
				new CreateSoupCommand
				{
					Name = soupName,
					Price = soupPrice,
				}, CancellationToken.None);

			// Assert
			Assert.NotNull(
				await Context.Soups.SingleOrDefaultAsync(s =>
					s.Id == soupId
					&& s.Name == soupName
					&& s.Price == soupPrice));
		}
	}
}
