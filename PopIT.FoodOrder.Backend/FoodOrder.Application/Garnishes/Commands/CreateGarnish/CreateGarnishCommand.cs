using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using MediatR;
using System;

namespace FoodOrder.Application.Garnishes.Commands.CreateGarnish
{
	public class CreateGarnishCommand : IRequest<Guid>, IMapWith<Garnish>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateGarnishCommand, Garnish>()
				.ForMember(b => b.Id,
					opt => opt.MapFrom(_ => Guid.NewGuid()));
		}
	}
}
