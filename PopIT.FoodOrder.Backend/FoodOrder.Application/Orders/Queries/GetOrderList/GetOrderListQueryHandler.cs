using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodOrder.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<OrderListVm> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.Orders
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderListVm { Orders = orders };
        }
    }
}