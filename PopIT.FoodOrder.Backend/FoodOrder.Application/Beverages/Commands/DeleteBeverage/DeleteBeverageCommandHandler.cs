using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrder.Application.Beverages.Commands.DeleteBeverage
{
	public class DeleteBeverageCommandHandler
		: IRequestHandler<DeleteBeverageCommand>
	{
		private readonly IFoodOrderDbContext _dbContext;

		public DeleteBeverageCommandHandler(IFoodOrderDbContext dbContext) =>
			_dbContext = dbContext;

		public async Task<Unit> Handle(DeleteBeverageCommand request, CancellationToken cancellationToken)
		{
			var entity = await _dbContext.Beverages
				.FindAsync(new object[] { request.Id }, cancellationToken);

			if (entity is null)
			{
				throw new EntityIdNotFoundException(nameof(Beverage), request.Id);
			}

			_dbContext.Beverages.Remove(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
