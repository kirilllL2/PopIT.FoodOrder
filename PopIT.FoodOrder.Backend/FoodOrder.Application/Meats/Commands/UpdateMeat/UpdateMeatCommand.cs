using System;
using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Meats.Commands.UpdateMeat
{
    public class UpdateMeatCommand : IRequest, IMapWith<Meat>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
            profile.CreateMap<UpdateMeatCommand, Meat>();
		}
	}
}