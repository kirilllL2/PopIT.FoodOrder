using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<OrderDetailsVm> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .Include(order => order.Beverage)
                .Include(order => order.Garnish)
                .Include(order => order.Meat)
                .Include(order => order.Soup)
                .FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);

            if (order is null || order.UserId != request.UserId)
            {
                throw new EntityIdNotFoundException(nameof(Order), request.Id);
            }

            return _mapper.Map<OrderDetailsVm>(order);
        }
    }
}