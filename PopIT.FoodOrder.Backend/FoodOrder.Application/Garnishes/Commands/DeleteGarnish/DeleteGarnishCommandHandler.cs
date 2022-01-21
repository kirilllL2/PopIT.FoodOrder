using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrder.Application.Garnishes.Commands.DeleteGarnish
{
	public class DeleteGarnishCommandHandler
		: IRequestHandler<DeleteGarnishCommand>
	{
		private readonly IFoodOrderDbContext _dbContext;

		public DeleteGarnishCommandHandler(IFoodOrderDbContext dbContext) =>
			_dbContext = dbContext;

		public async Task<Unit> Handle(DeleteGarnishCommand request, CancellationToken cancellationToken)
		{
			var entity = await _dbContext.Garnishes
				.FindAsync(new object[] { request.Id }, cancellationToken);

			if (entity is null)
			{
				throw new EntityIdNotFoundException(nameof(Garnish), request.Id);
			}

			_dbContext.Garnishes.Remove(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
