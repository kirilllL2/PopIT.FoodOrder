using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using MediatR;
using System;

namespace FoodOrder.Application.Garnishes.Commands.CreateGarnish
{
	public class CreateGarnishCommand : IRequest<Guid>, IMapTo<Garnish>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void MapTo(Profile profile)
		{
			profile.CreateMap<CreateGarnishCommand, Beverage>()
				.ForMember(b => b.Id,
					opt => opt.MapFrom(_ => Guid.NewGuid()));
		}
	}
}
