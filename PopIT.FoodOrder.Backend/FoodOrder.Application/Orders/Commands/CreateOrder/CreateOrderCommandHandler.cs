using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            if (await _dbContext.Beverages.FindAsync(new object[] {request.BeverageId}) is null)
            {
                throw new EntityIdNotFoundException(nameof(Beverage), request.BeverageId);
            }
            
            if (await _dbContext.Garnishes.FindAsync(new object[] {request.GarnishId}) is null)
            {
                throw new EntityIdNotFoundException(nameof(Garnish), request.GarnishId);
            }
            
            if (await _dbContext.Meats.FindAsync(new object[] {request.MeatId}) is null)
            {
                throw new EntityIdNotFoundException(nameof(Meat), request.MeatId);
            }
            
            if (await _dbContext.Soups.FindAsync(new object[] {request.SoupId}) is null)
            {
                throw new EntityIdNotFoundException(nameof(Soup), request.SoupId);
            }
            #endregion
            
            var order = _mapper.Map<Order>(request);

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}