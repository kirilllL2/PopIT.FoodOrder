using AutoMapper;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrder.Application.Beverages.Commands.CreateBeverage
{
	public class CreateBeverageCommandHandler
		: IRequestHandler<CreateBeverageCommand, Guid>
	{
		private readonly IFoodOrderDbContext _dbContext;
		private readonly IMapper _mapper;

		public CreateBeverageCommandHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
			(_dbContext, _mapper) = (dbContext, mapper);

		public async Task<Guid> Handle(CreateBeverageCommand request,
			CancellationToken cancellationToken)
		{
			var beverage = _mapper.Map<Beverage>(request);

			await _dbContext.Beverages.AddAsync(beverage);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return beverage.Id;
		}
	}
}
