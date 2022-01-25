using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodOrder.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrder.Application.Garnishes.Queries.GetGarnishList
{
	public class GetGarnishListQueryHandler
		: IRequestHandler<GetGarnishListQuery, GarnishListVm>
	{
		private readonly IFoodOrderDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetGarnishListQueryHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
			(_dbContext, _mapper) = (dbContext, mapper);

		public async Task<GarnishListVm> Handle(GetGarnishListQuery request, CancellationToken cancellationToken)
		{
			var garnishes =
				await _dbContext.Garnishes
					.ProjectTo<GarnishLookupDto>(_mapper.ConfigurationProvider)
					.ToListAsync(cancellationToken);

			return new GarnishListVm { Garnishes = garnishes };
		}
	}
}
