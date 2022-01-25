using System;
using MediatR;

namespace FoodOrder.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<OrderDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}