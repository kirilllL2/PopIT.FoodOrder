using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrder.Application.Garnishes.Commands.UpdateGarnish
{
	public class UpdateGarnishCommandHandler
		: IRequestHandler<UpdateGarnishCommand>
	{
		private readonly IFoodOrderDbContext _dbContext;
		private readonly IMapper _mapper;

		public UpdateGarnishCommandHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
			(_dbContext, _mapper) = (dbContext, mapper);

		public async Task<Unit> Handle(UpdateGarnishCommand request, CancellationToken cancellationToken)
		{
			var entity =
				await _dbContext.Garnishes.FirstOrDefaultAsync(g =>
					g.Id == request.Id, cancellationToken);

			if (entity is null)
			{
				throw new EntityIdNotFoundException(nameof(Garnish), request.Id);
			}

			_mapper.Map(request, entity);

			await _dbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
