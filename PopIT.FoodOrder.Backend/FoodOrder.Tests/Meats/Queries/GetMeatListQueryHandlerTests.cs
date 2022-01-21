using AutoMapper;
using FoodOrder.Application.Meats.Queries.GetMeatList;
using FoodOrder.Persistence;
using FoodOrder.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Meats.Queries
{
	[Collection("QueryCollection")]
	public class GetMeatListQueryHandlerTests
	{
		private readonly FoodOrderDbContext Context;
		private readonly IMapper Mapper;

		public GetMeatListQueryHandlerTests(QueryTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetMeatListQueryHandler_Success()
		{
			// Arrange
			var handler = new GetMeatListQueryHandler(Context, Mapper);

			// Act
			var result = await handler.Handle(
				new GetMeatListQuery
				{

				}, CancellationToken.None);

			// Assert
			result.ShouldBeOfType<MeatListVm>();
			result.Meats.Count.ShouldBe(4);
		}
	}
}
