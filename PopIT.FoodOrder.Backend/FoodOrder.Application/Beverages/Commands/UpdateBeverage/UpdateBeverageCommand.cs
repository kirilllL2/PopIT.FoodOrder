using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using MediatR;
using System;

namespace FoodOrder.Application.Beverages.Commands.UpdateBeverage
{
	public class UpdateBeverageCommand : IRequest, IMapWith<Beverage>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateBeverageCommand, Beverage>();
		}
	}
}
