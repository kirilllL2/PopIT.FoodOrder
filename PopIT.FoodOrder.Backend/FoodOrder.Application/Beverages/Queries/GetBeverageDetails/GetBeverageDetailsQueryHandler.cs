using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrder.Application.Beverages.Queries.GetBeverageDetails
{
	public class GetBeverageDetailsQueryHandler
		: IRequestHandler<GetBeverageDetailsQuery, BeverageDetailsVm>
	{
		private readonly IFoodOrderDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetBeverageDetailsQueryHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
			(_dbContext, _mapper) = (dbContext, mapper);
			 

		public async Task<BeverageDetailsVm> Handle(GetBeverageDetailsQuery request, CancellationToken cancellationToken)
		{
			var entity =
				await _dbContext.Beverages.FirstOrDefaultAsync(b =>
						b.Id == request.Id, cancellationToken);

			if (entity is null)
			{
				throw new EntityIdNotFoundException(nameof(Beverage), request.Id);
			}

			return _mapper.Map<BeverageDetailsVm>(entity);
		}
	}
}
