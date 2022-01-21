using FoodOrder.Application.Meats.Commands.CreateMeat;
using FoodOrder.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Meats.Commands
{
	public class CreateMeatCommandHandlerTests : TestCommandBase
	{
		[Fact]
		public async Task CreateMeatCommandHandler_Success()
		{
			// Arrange
			var handler = new CreateMeatCommandHandler(Context, Mapper);
			var meatName = "meat name";
			var meatPrice = 13.1m;

			// Act
			var meatId = await handler.Handle(
				new CreateMeatCommand
				{
					Name = meatName,
					Price = meatPrice,
				}, CancellationToken.None);

			// Assert
			Assert.NotNull(
				await Context.Meats.SingleOrDefaultAsync(m =>
					m.Id == meatId
					&& m.Name == meatName
					&& m.Price == meatPrice));
		}
	}
}
