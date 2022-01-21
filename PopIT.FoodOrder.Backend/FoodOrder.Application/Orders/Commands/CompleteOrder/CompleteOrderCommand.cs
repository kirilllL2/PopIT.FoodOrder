using System;
using MediatR;

namespace FoodOrder.Application.Orders.Commands.CompleteOrder
{
    public class CompleteOrderCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}