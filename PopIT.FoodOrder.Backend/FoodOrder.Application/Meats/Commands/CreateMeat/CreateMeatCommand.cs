using System;
using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Meats.Commands.CreateMeat
{
    public class CreateMeatCommand : IRequest<Guid>, IMapTo<Meat>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void MapTo(Profile profile)
        {
            profile.CreateMap<CreateMeatCommand, Meat>()
                .ForMember(meat => meat.Id,
                    opt => opt.MapFrom(_ => Guid.NewGuid()));
        }
    }
}