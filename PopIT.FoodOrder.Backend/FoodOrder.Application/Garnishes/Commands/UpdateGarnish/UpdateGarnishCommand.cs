using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using MediatR;
using System;

namespace FoodOrder.Application.Garnishes.Commands.UpdateGarnish
{
	public class UpdateGarnishCommand : IRequest, IMapWith<Garnish>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateGarnishCommand, Garnish>();
		}
	}
}
