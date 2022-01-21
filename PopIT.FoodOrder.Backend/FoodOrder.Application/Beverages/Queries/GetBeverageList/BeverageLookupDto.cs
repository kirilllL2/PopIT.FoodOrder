﻿using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using System;

namespace FoodOrder.Application.Beverages.Queries.GetBeverageList
{
	public class BeverageLookupDto : IMapWith<Beverage>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Beverage, BeverageLookupDto>();
		}
	}
}