using AutoMapper;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrder.Application.Garnishes.Commands.CreateGarnish
{
	public class CreateGarnishCommandHandler
		: IRequestHandler<CreateGarnishCommand, Guid>
	{
		private readonly IFoodOrderDbContext _dbContext;
		private readonly IMapper _mapper;

		public CreateGarnishCommandHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
			(_dbContext, _mapper) = (dbContext, mapper);

		public async Task<Guid> Handle(CreateGarnishCommand request, CancellationToken cancellationToken)
		{
			var garnish = _mapper.Map<Garnish>(request);

			await _dbContext.Garnishes.AddAsync(garnish, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return garnish.Id;
		}
	}
}
