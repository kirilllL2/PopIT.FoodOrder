using AutoMapper;
using FoodOrder.Application.Soups.Queries.GetSoupList;
using FoodOrder.Persistence;
using FoodOrder.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodOrder.Tests.Soups.Queries
{
	[Collection("QueryCollection")]
	public class GetSoupListQueryHandlerTests
	{
		private readonly FoodOrderDbContext Context;
		private readonly IMapper Mapper;

		public GetSoupListQueryHandlerTests(QueryTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetSoupListQueryHandler_Success()
		{
			// Arrange
			var handler = new GetSoupListQueryHandler(Context, Mapper);

			// Act
			var result = await handler.Handle(
				new GetSoupListQuery
				{

				}, CancellationToken.None);

			// Assert
			result.ShouldBeOfType<SoupListVm>();
			result.Soups.Count.ShouldBe(4);
		}
	}
}
