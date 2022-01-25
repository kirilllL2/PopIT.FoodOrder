using System;
using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>, IMapWith<Order>
    {
        public Guid UserId { get; set; }
        public Guid BeverageId { get; set; }
        public Guid GarnishId { get; set; }
        public Guid MeatId { get; set; }
        public Guid SoupId { get; set; }

		public void Mapping(Profile profile)
		{
            profile.CreateMap<CreateOrderCommand, Order>()
                .ForMember(o => o.OrderTime,
                    opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(o => o.IsCompleted,
                    opt => opt.MapFrom(_ => false));
        }
    }
}