using System;
using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Soups.Commands.CreateSoup
{
    public class CreateSoupCommand : IRequest<Guid>, IMapTo<Soup>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public void MapTo(Profile profile)
        {
            profile.CreateMap<CreateSoupCommand, Soup>()
                .ForMember(soup => soup.Id,
                    opt => opt.MapFrom(_ => Guid.NewGuid()));
        }
    }
}