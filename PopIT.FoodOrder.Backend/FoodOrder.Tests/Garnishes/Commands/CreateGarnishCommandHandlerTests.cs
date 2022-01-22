using FoodOrder.Application.Garnishes.Commands.CreateGarnish;
using FoodOrder.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Garnishes.Commands
{
	public class CreateGarnishCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task CreateGarnishCommandHandler_Success()
		{
			// Arrange
			var handler = new CreateGarnishCommandHandler(Context, Mapper);
			var garnishName = "garnish name";
			var garnishPrice = 13.1m;

			// Act
			var garnishId = await handler.Handle(
				new CreateGarnishCommand
				{
					Name = garnishName,
					Price = garnishPrice,
				}, CancellationToken.None);

			// Assert
			Assert.NotNull(
				await Context.Garnishes.SingleOrDefaultAsync(g =>
					g.Id == garnishId
					&& g.Name == garnishName
					&& g.Price == garnishPrice));
		}
	}
}
