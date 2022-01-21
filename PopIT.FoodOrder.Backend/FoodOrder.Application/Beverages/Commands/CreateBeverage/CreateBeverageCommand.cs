using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using MediatR;
using System;

namespace FoodOrder.Application.Beverages.Commands.CreateBeverage
{
	public class CreateBeverageCommand : IRequest<Guid>, IMapTo<Beverage>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void MapTo(Profile profile)
		{
			profile.CreateMap<CreateBeverageCommand, Beverage>()
				.ForMember(b => b.Id,
					opt => opt.MapFrom(_ => Guid.NewGuid()));
		}
	}
}
