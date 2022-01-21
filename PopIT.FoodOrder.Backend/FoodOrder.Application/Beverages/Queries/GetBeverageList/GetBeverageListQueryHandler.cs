using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodOrder.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrder.Application.Beverages.Queries.GetBeverageList
{
	public class GetBeverageListQueryHandler
		: IRequestHandler<GetBeverageListQuery, BeverageListVm>
	{
		private readonly IFoodOrderDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetBeverageListQueryHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
			(_dbContext, _mapper) = (dbContext, mapper);

		public async Task<BeverageListVm> Handle(GetBeverageListQuery request, CancellationToken cancellationToken)
		{
			var beverages =
				await _dbContext.Beverages
					.ProjectTo<BeverageLookupDto>(_mapper.ConfigurationProvider)
					.ToListAsync(cancellationToken);

			return new BeverageListVm { Beverages = beverages };
		}
	}
}
