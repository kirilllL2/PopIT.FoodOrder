using FoodOrder.Application.Beverages.Commands.CreateBeverage;
using FoodOrder.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Beverages.Commands
{
	public class CreateBeverageCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task CreateBeverageCommandHandler_Success()
		{
			// Arrange
			var handler = new CreateBeverageCommandHandler(Context, Mapper);
			var beverageName = "beverage name";
			var beveragePrice = 13.1m;

			// Act
			var beverageId = await handler.Handle(
				new CreateBeverageCommand
				{
					Name = beverageName,
					Price = beveragePrice,
				}, CancellationToken.None);

			// Assert
			Assert.NotNull(
				await Context.Beverages.SingleOrDefaultAsync(b =>
					b.Id == beverageId
					&& b.Name == beverageName
					&& b.Price == beveragePrice));
		}
	}
}
