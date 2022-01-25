using System;
using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.Orders.Queries.GetOrderList
{
    public class OrderLookupDto : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public bool IsCompleted { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Order, OrderLookupDto>();
		}
	}
}