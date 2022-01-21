using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrder.Application.Garnishes.Queries.GetGarnishDetails
{
	public class GetGarnishDetailsQueryHandler
		: IRequestHandler<GetGarnishDetailsQuery, GarnishDetailsVm>
	{
		private readonly IFoodOrderDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetGarnishDetailsQueryHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
			(_dbContext, _mapper) = (dbContext, mapper);

		public async Task<GarnishDetailsVm> Handle(GetGarnishDetailsQuery request, CancellationToken cancellationToken)
		{
			var entity =
				await _dbContext.Garnishes.FirstOrDefaultAsync(g =>
						g.Id == request.Id, cancellationToken);

			if (entity is null)
			{
				throw new EntityIdNotFoundException(nameof(Garnish), request.Id);
			}

			return _mapper.Map<GarnishDetailsVm>(entity);
		}
	}
}
