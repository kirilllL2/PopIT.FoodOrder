using System;
using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Orders.Commands.CreateOrder;

namespace FoodOrder.WebApi.Models
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        public Guid BeverageId { get; set; }
        public Guid GarnishId { get; set; }
        public Guid MeatId { get; set; }
        public Guid SoupId { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>();
        }
    }
}