using System;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.Orders.Queries.GetOrderList
{
    public class OrderLookupDto : IMapFrom<Order>
    {
        public Guid Id { get; set; }
        public bool IsCompleted { get; set; }
    }
}