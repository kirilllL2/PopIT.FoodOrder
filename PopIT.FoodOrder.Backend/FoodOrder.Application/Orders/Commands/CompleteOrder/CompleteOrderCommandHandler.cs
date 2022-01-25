using System.Threading;
using System.Threading.Tasks;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Application.Orders.Commands.CompleteOrder
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand>
    {
        private readonly IFoodOrderDbContext _dbContext;

        public CompleteOrderCommandHandler(IFoodOrderDbContext dbContext) =>
            _dbContext = dbContext;
        
        public async Task<Unit> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);
            
            if (order is null)
            {
                throw new EntityIdNotFoundException(nameof(Order), request.Id);
            }

            order.IsCompleted = true;
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}