using System;
using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Meats.Commands.CreateMeat
{
    public class CreateMeatCommand : IRequest<Guid>, IMapWith<Meat>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
            profile.CreateMap<CreateMeatCommand, Meat>()
                .ForMember(meat => meat.Id,
                    opt => opt.MapFrom(_ => Guid.NewGuid()));
        }
    }
}