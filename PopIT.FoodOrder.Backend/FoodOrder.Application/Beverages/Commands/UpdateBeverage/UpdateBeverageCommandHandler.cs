using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrder.Application.Beverages.Commands.UpdateBeverage
{
	public class UpdateBeverageCommandHandler
		: IRequestHandler<UpdateBeverageCommand>
	{
		private readonly IFoodOrderDbContext _dbContext;
		private readonly IMapper _mapper;

		public UpdateBeverageCommandHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
			(_dbContext, _mapper) = (dbContext, mapper);

		public async Task<Unit> Handle(UpdateBeverageCommand request, CancellationToken cancellationToken)
		{
			var entity =
				await _dbContext.Beverages.FirstOrDefaultAsync(b =>
					b.Id == request.Id, cancellationToken);

			if (entity is null)
			{
				throw new EntityIdNotFoundException(nameof(Beverage), request.Id);
			}

			_mapper.Map(request, entity);

			await _dbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
